namespace wt_lab2_2oop_krivetskij.Models;

public class Patient : BaseEntity
{
    public string FullName { get; set; }

    public int Age { get; private set; }

    public string Phone { get; set; }

    public Patient(
        int id,
        string fullName,
        int age,
        string phone)
        : base(id)
    {
        FullName = fullName;
        Age = age;
        Phone = phone;
    }

    public bool UpdateAge(int newAge)
    {
        if (newAge <= 0 || newAge > 120)
        {
            return false;
        }

        Age = newAge;
        return true;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("=== Пациент ===");
        PrintBaseInfo();
        Console.WriteLine($"ФИО: {FullName}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Телефон: {Phone}");
    }
}