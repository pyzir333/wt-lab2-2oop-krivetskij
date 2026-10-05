namespace wt_lab2_2oop_krivetskij.Models;

public class MedicalRecord : BaseEntity
{
    public Patient Patient { get; set; }

    public string Description { get; set; }

    public string Treatment { get; set; }

    public MedicalRecord(
        int id,
        Patient patient,
        string description,
        string treatment)
        : base(id)
    {
        Patient = patient;
        Description = description;
        Treatment = treatment;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("=== Медицинская карта ===");
        PrintBaseInfo();
        Console.WriteLine($"Пациент: {Patient.FullName}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Лечение: {Treatment}");
    }
}