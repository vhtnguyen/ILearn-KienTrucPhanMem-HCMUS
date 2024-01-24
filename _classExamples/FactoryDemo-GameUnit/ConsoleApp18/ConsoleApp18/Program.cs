using System;

// Define a common interface for all units
public interface IUnit
{
    void Attack();
    void Defend();
    string AttackRange { get; }
    int AttackRangeDistance { get; }
    int Cost { get; }
    int HitPoints { get; }
    int Defense { get; }
    int DamagePointsPerAttack { get; }

    IUnit Clone();
}

// Concrete implementation of a Knight unit
class Knight : IUnit
{
    public string AttackRange => "Short Range";
    public int AttackRangeDistance => 1;
    public int Cost => 10; // Example: Knight costs 10 gold coins
    public int HitPoints => 100; // Example: Knight has 100 hit points
    public int Defense => 20; // Example: Knight has a defense of 20
    public int DamagePointsPerAttack => 30; // Example: Knight deals 30 damage per attack

    public void Attack()
    {
        Console.WriteLine("Knight attacks with a sword.");
    }

    public IUnit Clone()
    {
        return new Knight();
    }

    public void Defend()
    {
        Console.WriteLine("Knight raises a shield for defense.");
    }
    
}

// Concrete implementation of an Archer unit
class Archer : IUnit
{
    public string AttackRange => "Long Range";
    public int AttackRangeDistance => 3; // Example: Archer has a range of 3 distance units
    public int Cost => 15; // Example: Archer costs 15 gold coins
    public int HitPoints => 80; // Example: Archer has 80 hit points
    public int Defense => 10; // Example: Archer has a defense of 10
    public int DamagePointsPerAttack => 40; // Example: Archer deals 40 damage per attack

    public void Attack()
    {
        Console.WriteLine("Archer shoots arrows.");
    }

    public void Defend()
    {
        Console.WriteLine("Archer takes cover behind obstacles.");
    }

    public IUnit Clone()
    {
        return new Archer();
    }
}

// Concrete implementation of a Mage unit
class Mage : IUnit
{
    public string AttackRange => "Long Range";
    public int AttackRangeDistance => 4; // Example: Mage has a range of 4 distance units
    public int Cost => 20; // Example: Mage costs 20 gold coins
    public int HitPoints => 60; // Example: Mage has 60 hit points
    public int Defense => 5; // Example: Mage has a defense of 5
    public int DamagePointsPerAttack => 50; // Example: Mage deals 50 damage per attack

    public void Attack()
    {
        Console.WriteLine("Mage casts spells.");
    }

    public void Defend()
    {
        Console.WriteLine("Mage uses magical wards for defense.");
    }

    public IUnit Clone()
    {
        return new Mage();
    }
}

// Barrack class to create different units
class Barrack
{

    static Barrack()
    {
        prototypes.Add("Knight", new Knight());
        prototypes.Add("Archer", new Archer());
        prototypes.Add("Mage", new Mage());
    }

    public Barrack()
    {

    }
    public IUnit RecruitUnit(string unitType)
    {
        switch (unitType.ToLower())
        {
            case "knight":
                return new Knight();
            case "archer":
                return new Archer();
            case "mage":
                return new Mage();
            default:
                throw new ArgumentException($"Invalid unit type: {unitType}");
        }
    }


    public IUnit RecruitUnitFromClassName(string name)
    {
        return CreateObjectFromClassName(name);
    }

    private static Dictionary<string, IUnit> prototypes = new Dictionary<string, IUnit>();

    public IUnit RecruitUnitFromFlexibleCriteria(UnitRequirement unitRequirement)
    {
        foreach(var unit in prototypes.Values)
        {
          //  if(unit.IsAppropriate(unitRequirement))
                if (unitRequirement.IsOK(unit))
                 //   if (HelperObject.HelpMePlease(unit, unitRequirement))
            {
                return unit.Clone();
            }
        }
        return null;
    }

    private IUnit? CreateObjectFromClassName(string name)
    {

        object? o = Activator.CreateInstance(GetTypeFromClassName(name));
        if (o!=null)
            return (IUnit)o;
        return null;
    }

    private Type GetTypeFromClassName(string name)
    {
        Type t = Type.GetType(name);
        return t;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Barrack barrack = new Barrack();

        // Create different types of units
        IUnit knight = barrack.RecruitUnit("knight");
        IUnit archer = barrack.RecruitUnit("archer");
        IUnit mage = barrack.RecruitUnit("mage");

        // Demonstrate unit attributes
        Console.WriteLine("Knight attributes:");
        Console.WriteLine($"Attack Range: {knight.AttackRange}, Attack Range Distance: {knight.AttackRangeDistance}, Cost: {knight.Cost} gold coins");
        Console.WriteLine($"Hit Points: {knight.HitPoints}, Defense: {knight.Defense}, Damage Points per Attack: {knight.DamagePointsPerAttack}");
        knight.Attack();
        knight.Defend();

        Console.WriteLine("\nArcher attributes:");
        Console.WriteLine($"Attack Range: {archer.AttackRange}, Attack Range Distance: {archer.AttackRangeDistance}, Cost: {archer.Cost} gold coins");
        Console.WriteLine($"Hit Points: {archer.HitPoints}, Defense: {archer.Defense}, Damage Points per Attack: {archer.DamagePointsPerAttack}");
        archer.Attack();
        archer.Defend();

        Console.WriteLine("\nMage attributes:");
        Console.WriteLine($"Attack Range: {mage.AttackRange}, Attack Range Distance: {mage.AttackRangeDistance}, Cost: {mage.Cost} gold coins");
        Console.WriteLine($"Hit Points: {mage.HitPoints}, Defense: {mage.Defense}, Damage Points per Attack: {mage.DamagePointsPerAttack}");
        mage.Attack();
        mage.Defend();
        IUnit u = barrack.RecruitUnitFromClassName("Knight");
        u.Attack();
    }
}
