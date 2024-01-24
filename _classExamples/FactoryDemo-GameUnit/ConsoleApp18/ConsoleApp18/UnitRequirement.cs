public class UnitRequirement
{
    public virtual bool IsOK(IUnit unit)
    {
        return true;
        //throw new NotImplementedException();
    }
}


public class UnitRequirement_MaximumCost: UnitRequirement
{
    private int MaxCost;

    public UnitRequirement_MaximumCost(int MaxCost)
    {
        this.MaxCost = MaxCost;
    }

    public override bool IsOK(IUnit unit)
    {
        return unit.Cost <= MaxCost;
    }

}