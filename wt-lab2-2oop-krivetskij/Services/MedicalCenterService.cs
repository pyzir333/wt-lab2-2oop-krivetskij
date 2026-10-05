using wt_lab2_2oop_krivetskij.Interfaces;
using wt_lab2_2oop_krivetskij.Models;

namespace wt_lab2_2oop_krivetskij.Services;

public class MedicalCenterService : IItemService<Patient>
{
    private readonly List<Patient> patients = new();

    public void Add(Patient patient)
    {
        patients.Add(patient);
    }

    public bool Remove(int id)
    {
        Patient? patient = patients.FirstOrDefault(p => p.Id == id);

        if (patient == null)
        {
            return false;
        }

        patients.Remove(patient);
        return true;
    }

    public Patient? GetById(int id)
    {
        return patients.FirstOrDefault(p => p.Id == id);
    }

    public List<Patient> GetAll()
    {
        return patients;
    }

    // Перегрузка метода Add
    public void Add(
        int id,
        string fullName,
        int age,
        string phone)
    {
        Patient patient = new Patient(
            id,
            fullName,
            age,
            phone);

        patients.Add(patient);
    }
}