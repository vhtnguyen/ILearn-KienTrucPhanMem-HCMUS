using System;

// Define a common interface for all units
interface IUnit
{
    void Attack();
    void Defend();
    string AttackRange { get; }
    int AttackRangeDistance { get; }
}

// Concrete implementation of a Knight unit
class Knight : IUnit
{
    public string AttackRange => "Short Range";
    public int AttackRangeDistance => 1;

    public void Attack()
    {
        Console.WriteLine("Knight attacks with a sword.");
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

    public void Attack()
    {
        Console.WriteLine("Archer shoots arrows.");
    }

    public void Defend()
    {
        Console.WriteLine("Archer takes cover behind obstacles.");
    }
}

// Concrete implementation of a Mage unit
class Mage : IUnit
{
    public string AttackRange => "Long Range";
    public int AttackRangeDistance => 4; // Example: Mage has a range of 4 distance units

    public void Attack()
    {
        Console.WriteLine("Mage casts spells.");
    }

    public void Defend()
    {
        Console.WriteLine("Mage uses magical wards for defense.");
    }
}

// Barrack class to create different units
// This is the factory
class Barrack
{
    public IUnit CreateUnit(string unitType)
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
}

class Program
{
    static void Main(string[] args)
    {
        Barrack barrack = new Barrack();

        // Create different types of units
        IUnit knight = barrack.CreateUnit("knight");
        IUnit archer = barrack.CreateUnit("archer");
        IUnit mage = barrack.CreateUnit("mage");

        // Demonstrate unit actions and attack range
        Console.WriteLine("Knight actions:");
        Console.WriteLine($"Attack Range: {knight.AttackRange}, Attack Range Distance: {knight.AttackRangeDistance}");
        knight.Attack();
        knight.Defend();

        Console.WriteLine("\nArcher actions:");
        Console.WriteLine($"Attack Range: {archer.AttackRange}, Attack Range Distance: {archer.AttackRangeDistance}");
        archer.Attack();
        archer.Defend();

        Console.WriteLine("\nMage actions:");
        Console.WriteLine($"Attack Range: {mage.AttackRange}, Attack Range Distance: {mage.AttackRangeDistance}");
        mage.Attack();
        mage.Defend();
    }
}
