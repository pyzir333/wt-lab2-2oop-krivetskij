
namespace wt_lab2_2oop_krivetskij.Models;

public class Appointment : BaseEntity
{
    public Patient Patient { get; set; }

    public Doctor Doctor { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Diagnosis { get; set; }

    public Appointment(
        int id,
        Patient patient,
        Doctor doctor,
        DateTime appointmentDate,
        string diagnosis)
        : base(id)
    {
        Patient = patient;
        Doctor = doctor;
        AppointmentDate = appointmentDate;
        Diagnosis = diagnosis;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("=== Приём ===");
        PrintBaseInfo();
        Console.WriteLine($"Пациент: {Patient.FullName}");
        Console.WriteLine($"Врач: {Doctor.FullName}");
        Console.WriteLine($"Дата приёма: {AppointmentDate:dd.MM.yyyy HH:mm}");
        Console.WriteLine($"Диагноз: {Diagnosis}");
    }
}