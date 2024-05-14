var p1 = new Person("John", "Doe", new DateOnly(1980, 1, 1));
var p2 = new Person("Jane", "Doe", new DateOnly(1980, 1, 1)); 

p1.Pets.Add(new Cat("Fluffy"));	
p1.Pets.Add(new Dog("Spot"));

p2.Pets.Add(new Cat("Whiskers"));
p2.Pets.Add(new Dog("Rover"));

List<Person> people = new List<Person> { p1, p2 };

foreach (var person in people)
{
    Console.WriteLine($"{person}");
    foreach(var pet in person.Pets)
    {
        Console.WriteLine($"     {pet}");
    }
}

foreach (var person in people)
{
    Console.WriteLine($"{person.FirstName} {person.LastName} was born on {person.BirthDate}");
    foreach(var pet in person.Pets)
    {
        Console.WriteLine($"{person.FirstName} {person.LastName} has a pet {pet.GetType().Name} named {pet.FirstName} that says {pet.MakeNoise()}");
    }
}

public class Person
{
    public Person(string firstName, string lastName, DateOnly birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly BirthDate { get; }
    public List<Pet> Pets { get; set; } = new List<Pet>(); 
    public override string ToString() {
        return $"{FirstName} {LastName}";
    }
}

public abstract class Pet{
    public string FirstName { get; private set; }
    public Pet(string firstName)
    {
        FirstName = firstName;
    }
    public abstract string MakeNoise();

    public override string ToString() 
    {
        return $"{FirstName} and I am a {GetType().Name}";
    }
}

public class Cat : Pet {
    public Cat(string firstName) : base(firstName) { }
    public override string MakeNoise() => "Meow!";
}

public class Dog : Pet {
    public Dog(string firstName) : base(firstName) { }
    public override string MakeNoise() => "Woof!";
}

