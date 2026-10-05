

namespace wt_lab2_2oop_krivetskij.Models;

public class Doctor : BaseEntity
{
    public string FullName { get; set; }

    public string Specialization { get; set; }

    public int Experience { get; set; }

    public Doctor(
        int id,
        string fullName,
        string specialization,
        int experience)
        : base(id)
    {
        FullName = fullName;
        Specialization = specialization;
        Experience = experience;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("=== Врач ===");
        PrintBaseInfo();
        Console.WriteLine($"ФИО: {FullName}");
        Console.WriteLine($"Специализация: {Specialization}");
        Console.WriteLine($"Стаж: {Experience} лет");
    }
}