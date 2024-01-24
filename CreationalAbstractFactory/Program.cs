namespace AbsFactory;

//Abstract Factory
public interface IFashion
{
    IShoe CreateShoe();

    IDress CreateDress();
}

//Abstract Product A
public interface IDress
{
    string GetName();

    string GetModel();
}

//Abstract Product B
public interface IShoe
{
    string GetName();

    string GetModel();
}


//Concrete Factory 1
public class SummerFashion : IFashion
{
    public IShoe CreateShoe()
    {
        return new SummerShoe();
    }

    public IDress CreateDress()
    {
        return new SummerDress();
    }
}

//Concrete Factory 2
public class WinterFashion : IFashion
{
    public IShoe CreateShoe()
    {
        return new WinterShoe();
    }

    public IDress CreateDress()
    {
        return new WinterDress();
    }
}
//Product
public class SummerDress : IDress
{
    public string GetName()
    {
        return "Summber dress";
    }

    public string GetModel()
    {
        return "This is summer dress";
    }
}
public class SummerShoe : IShoe
{
    public string GetName()
    {
        return "Summer shoe";
    }

    public string GetModel()
    {
        return "This is summer shoe";
    }
}


public class WinterDress : IDress
{
    public string GetName()
    {
        return "Winter dress";
    }

    public string GetModel()
    {
        return "This is winter dress";
    }
}


public class WinterShoe : IShoe
{
    public string GetName()
    {
        return "Winter shoe";
    }

    public string GetModel()
    {
        return "This is winter shoe";
    }
}




//Client
public class Client
{
    public void ClientMethod(IFashion factory)
    {
        var shoe = factory.CreateShoe();
        var dress = factory.CreateDress();

        Console.WriteLine(shoe.GetModel());
        Console.WriteLine(shoe.GetName());

        Console.WriteLine(dress.GetModel());
        Console.WriteLine(dress.GetName());

        Console.WriteLine("**********");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Abstract factory demo:");
        Console.WriteLine("**********");

        var client = new Client();

        client.ClientMethod(new SummerFashion());

        client.ClientMethod(new WinterFashion());
    }
}