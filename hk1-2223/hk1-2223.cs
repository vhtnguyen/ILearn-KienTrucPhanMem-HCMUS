using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System;

class MAttribute
{
    public string Name;
    public string Value;
    public int CachedTime;
    public static int DefaultCachedTime = 60;
    public MAttribute(string name, string value, int cachedTime)
    {
        Name = name;
        Value = value;
        CachedTime = cachedTime;
    }
}

class MObject
{
    public int ID;
    protected Dictionary<string, MAttribute> Attributes = new Dictionary<string, MAttribute>();
    public MObject()
    {
        ID = MObjectManager.Register(this);

    }
    public string this[string sAttributeName]
    {
        get
        {
            if (Attributes.ContainsKey(sAttributeName))
            {
                return Attributes[sAttributeName].Value;
            }
            else
            {
                return string.Empty;
            }
        }
        set
        {
            if (Attributes.ContainsKey(sAttributeName) && Attributes[sAttributeName].Value != value)
            {
                Attributes[sAttributeName].Value = value;
            }
            else
            {
                MAttribute newAttr = new MAttribute(sAttributeName, value, MAttribute.DefaultCachedTime);
                Attributes.Add(sAttributeName, newAttr);
            }
        }
    }
    public int getCachedTime(string sAttributeName)
    {
        if (Attributes.ContainsKey(sAttributeName))
        {
            return Attributes[sAttributeName].CachedTime;
        }
        else
        {
            return 0;
        }

    }


}

class MObjectManager
{
    public static Dictionary<int, MObject> objects = new Dictionary<int, MObject>();
    private static int NextAvailableID = 1;
    public static int CreateObject()
    {
        return new MObject().ID;

    }

    internal static int Register(MObject mObject)
    {
        int ID = MObjectManager.NextAvailableID++;
        objects.Add(ID, mObject);
        return ID;
    }
    private static MObject _findObjectByID(int id)
    {
        if (objects.ContainsKey(id))
        {
            return objects[id];
        }
        else
        {
            return null;
        }

    }

    public static bool SetObjectAttributeValue(int id, string sAttributeName, string newValue)
    {
        MObject obj = _findObjectByID(id);
        if (obj != null)
        {
            obj[sAttributeName] = newValue;
            string inputParams = $"{sAttributeName} {newValue}";
            string outputParams = string.Empty;
            RObjectManager.ExecuteObjectsMethod(id, "UpdateAttribute", inputParams, ref outputParams); // notify all client that need to update new value
            return true;
        }
        return false;
    }
    public static string GetObjectAttributeValue(int id, string sAttributeName)
    {
        MObject obj = _findObjectByID(id);
        if (obj != null)
        {
            return obj[sAttributeName];
        }
        return string.Empty;

    }
    public static int GetObjectAttributeCachedTime(int id, string sAttributeName)
    {

        if (objects.ContainsKey(id))
        {
            return objects[id].getCachedTime(sAttributeName);
        }
        return 0;

    }

}

class RAttribute
{
    public string Name;
    private string LastKnownValue;
    public int CachedTime;

    public string LastKnowValue { get; private set; }

    public DateTime LastUpdate;
    public static int DefaultCachedTime = 60;
    public RAttribute(string name, string value, int cachedTime)
    {

    }
    public string Value
    {
        get
        {
            return LastKnownValue;
        }
        set
        {
            LastKnowValue = value;
            LastUpdate = DateTime.Now;

        }
    }
    public bool NeedToRefresh()
    {
        if (LastUpdate.Second - DateTime.Now.Second > CachedTime)
        {
            return true;
        }
        return false;

    }
}

class RObject
{
    protected int ID;
    protected Dictionary<string, RAttribute> Attributes = new Dictionary<string, RAttribute>();

    public RObject()
    {
        ID = RObjectManager.Register(this);
    }
    public RObject(int id)
    {
        ID = RObjectManager.Register(this, id);

    }
    public string this[string sAttributeName]
    {
        get
        {

            if (Attributes.ContainsKey(sAttributeName))
            {
                RAttribute attr = Attributes[sAttributeName];
                if (attr.NeedToRefresh())
                {
                    Attributes[sAttributeName].Value = RObjectManager.GetObjectAttributeValue(ID, sAttributeName);
                }
            }
            else
            {
                string newValue = RObjectManager.GetObjectAttributeValue(ID, sAttributeName);
                int newCachedTime = RObjectManager.GetObjectAttributeCachedTime(ID, sAttributeName);
                AddNewAttribute(sAttributeName, newValue, newCachedTime);
            }
            return Attributes[sAttributeName].Value;
        }
        set
        {
            if (Attributes.ContainsKey(sAttributeName) && Attributes[sAttributeName].Value != value)
            {
                Attributes[sAttributeName].Value = value;
                RObjectManager.SetObjectAttributeValue(ID, sAttributeName, value);
            }
            else
            {
                RObjectManager.SetObjectAttributeValue(ID, sAttributeName, value);
                int newCachedTime = RObjectManager.GetObjectAttributeCachedTime(ID, sAttributeName);
                AddNewAttribute(sAttributeName, value, newCachedTime);
            }
        }
    }
    private void AddNewAttribute(string sAttributeName, string value, int cachedTime)
    {

    }
    protected void clearAllCached()
    {
        foreach (var attr in Attributes)
        {
            attr.Value.Value = string.Empty;
            attr.Value.CachedTime = 0;

        }
    }
    protected void UpdateAttribute(string sAttributeName, string newValue)
    {
        if (Attributes.ContainsKey(sAttributeName))
        {
            Attributes[sAttributeName].Value = newValue;
        }
    }
    public bool ExcuteMethod(string methodName, string inputParams, ref string? outputParams)
    {
        outputParams = String.Empty;

        switch (methodName)
        {
            case "clearAllCached":
                clearAllCached();
                return true;
            case "UpdateAttribute":
                try
                {
                    string sAttributeName = inputParams.Split(' ')[0];
                    string newValue = inputParams.Split(' ')[1];
                    UpdateAttribute(sAttributeName, newValue);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            default:
                return false;
        }


    }


}





class RObjectManager
{
    private static Dictionary<int, List<RObject>> _objects = new Dictionary<int, List<RObject>>();

    public static int Register(RObject rObject)
    {
        int id = MObjectManager.CreateObject();
        _objects[id] = new List<RObject>();
        _objects[id].Append(rObject);
        return id;
    }
    public static int Register(RObject rObject, int mID)
    {
        if (_objects.ContainsKey(mID))
        {
            _objects[mID].Append(rObject);
            return mID;
        }
        else
        {
            return Register(rObject);
        }
    }
    public static string GetObjectAttributeValue(int id, string sAttributeName)
    {
        return MObjectManager.GetObjectAttributeValue(id, sAttributeName);
    }
    public static bool SetObjectAttributeValue(int id, string sAttributeName, string newValue)
    {
        return MObjectManager.SetObjectAttributeValue(id, sAttributeName, newValue);

    }
    public static int GetObjectAttributeCachedTime(int id, string sAttributeName)
    {

        return MObjectManager.GetObjectAttributeCachedTime(id, sAttributeName);
    }
    public static void ExecuteObjectsMethod(int id, string methodName, string inputParams, ref string outputParams)
    {
        if (id == 0) // update all client objects
        {
            foreach (var obj in _objects)
            {
                foreach (var rObject in obj.Value)
                {
                    rObject.ExcuteMethod(methodName, inputParams, ref outputParams);
                }
            }
        }
        else if (id != 0 && _objects.ContainsKey(id)) // only update client objects that reference to server object having ID=id
        {
            foreach (var rObject in _objects[id])
            {
                rObject.ExcuteMethod(methodName, inputParams, ref outputParams);
            }

        }
        else
        {
            return;
        }
    }
}

