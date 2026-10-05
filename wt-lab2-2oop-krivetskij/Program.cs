using wt_lab2_2oop_krivetskij.Interfaces;
using wt_lab2_2oop_krivetskij.Models;
using wt_lab2_2oop_krivetskij.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("======================================");
Console.WriteLine("        МЕДИЦИНСКИЙ ЦЕНТР");
Console.WriteLine("        Лабораторная работа N2");
Console.WriteLine("======================================");

Console.WriteLine();


// СОЗДАНИЕ ОБЪЕКТОВ


Doctor doctor = new Doctor(
    1,
    "Иванов Иван Иванович",
    "Терапевт",
    12);

Patient patient = new Patient(
    1,
    "Петров Пётр Петрович",
    35,
    "+375 29 123-45-67");

Appointment appointment = new Appointment(
    1,
    patient,
    doctor,
    DateTime.Now.AddDays(1),
    "ОРВИ");

MedicalRecord medicalRecord = new MedicalRecord(
    1,
    patient,
    "Повышенная температура, кашель",
    "Покой, обильное питьё, назначенные препараты");



// ВЫВОД ИНФОРМАЦИИ


doctor.PrintInfo();

Console.WriteLine();

patient.PrintInfo();

Console.WriteLine();

appointment.PrintInfo();

Console.WriteLine();

medicalRecord.PrintInfo();



// ИНИЦИАЛИЗАТОР ОБЪЕКТА


Console.WriteLine();
Console.WriteLine("=== Создание объекта через инициализатор ===");

Patient patient2 = new Patient(
    2,
    "Сидорова Анна Сергеевна",
    28,
    "+375 33 987-65-43")
{
    Phone = "+375 33 111-22-33"
};

patient2.PrintInfo();


// ПРОВЕРКА ИНКАПСУЛЯЦИИ


Console.WriteLine();
Console.WriteLine("=== Изменение возраста пациента ===");

bool ageUpdated = patient.UpdateAge(36);

Console.WriteLine(
    ageUpdated
        ? "Возраст успешно изменён."
        : "Некорректный возраст.");

patient.PrintInfo();



// ПОЛИМОРФИЗМ


Console.WriteLine();
Console.WriteLine("=== Полиморфизм ===");

BaseEntity[] entities =
{
    doctor,
    patient,
    appointment,
    medicalRecord
};

foreach (BaseEntity entity in entities)
{
    entity.PrintInfo();
    Console.WriteLine();
}



// РАБОТА С СЕРВИСОМ


Console.WriteLine();
Console.WriteLine("=== Сервис медицинского центра ===");

IItemService<Patient> service =
    new MedicalCenterService();

service.Add(patient);
service.Add(patient2);

service.Add(
    new Patient(
        3,
        "Смирнов Алексей Викторович",
        42,
        "+375 44 555-66-77"));

foreach (Patient p in service.GetAll())
{
    p.PrintInfo();
    Console.WriteLine();
}



// ПОИСК ПО ID


Console.WriteLine("=== Поиск пациента ===");

Patient? foundPatient = service.GetById(2);

if (foundPatient != null)
{
    Console.WriteLine("Пациент найден:");
    foundPatient.PrintInfo();
}
else
{
    Console.WriteLine("Пациент не найден.");
}



// LIST<T>


Console.WriteLine();
Console.WriteLine("=== LIST ПАЦИЕНТОВ ===");

List<Patient> patientList = new()
{
    new Patient(
        101,
        "Иванов Иван",
        30,
        "+375 29 111-11-11"),

    new Patient(
        102,
        "Петров Пётр",
        45,
        "+375 29 222-22-22"),

    new Patient(
        103,
        "Сидорова Анна",
        27,
        "+375 29 333-33-33"),

    new Patient(
        104,
        "Козлов Алексей",
        52,
        "+375 29 444-44-44"),

    new Patient(
        105,
        "Орлова Мария",
        36,
        "+375 29 555-55-55"),

    new Patient(
        106,
        "Смирнов Дмитрий",
        41,
        "+375 29 666-66-66")
};

foreach (Patient p in patientList)
{
    Console.WriteLine(
        $"{p.Id} | {p.FullName} | {p.Age} лет");
}



// DICTIONARY


Console.WriteLine();
Console.WriteLine("=== DICTIONARY ===");

Dictionary<int, Patient> patientDictionary =
    patientList.ToDictionary(p => p.Id);

int searchId = 103;

if (patientDictionary.TryGetValue(
        searchId,
        out Patient? dictionaryPatient))
{
    Console.WriteLine("Пациент найден:");

    dictionaryPatient.PrintInfo();
}
else
{
    Console.WriteLine(
        $"Пациент с ID {searchId} не найден.");
}


//  LINQ — WHERE


Console.WriteLine();
Console.WriteLine("=== LINQ: пациенты старше 40 лет ===");

List<Patient> olderPatients = patientList
    .Where(p => p.Age > 40)
    .ToList();

foreach (Patient p in olderPatients)
{
    Console.WriteLine(
        $"{p.FullName} — {p.Age} лет");
}



//  LINQ — ORDER BY
Console.WriteLine();
Console.WriteLine("=== LINQ: сортировка по возрасту ===");

List<Patient> sortedPatients = patientList
    .OrderByDescending(p => p.Age)
    .ToList();

foreach (Patient p in sortedPatients)
{
    Console.WriteLine(
        $"{p.FullName} — {p.Age} лет");
}



// LINQ — SELECT


Console.WriteLine();
Console.WriteLine("=== LINQ: SELECT ===");

List<string> patientNames = patientList
    .Select(p => p.FullName)
    .ToList();

foreach (string name in patientNames)
{
    Console.WriteLine(name);
}



// СТАТИСТИКА

Console.WriteLine();
Console.WriteLine("=== СТАТИСТИКА ===");

int count = patientList.Count;

int sumAge = patientList.Sum(
    p => p.Age);

double averageAge = patientList.Average(
    p => p.Age);

int minAge = patientList.Min(
    p => p.Age);

int maxAge = patientList.Max(
    p => p.Age);

Console.WriteLine(
    $"Количество пациентов: {count}");

Console.WriteLine(
    $"Суммарный возраст: {sumAge}");

Console.WriteLine(
    $"Средний возраст: {averageAge:F2}");

Console.WriteLine(
    $"Минимальный возраст: {minAge}");

Console.WriteLine(
    $"Максимальный возраст: {maxAge}");



//  GROUP BY


Console.WriteLine();
Console.WriteLine("=== GROUP BY ===");

var groups = patientList
    .GroupBy(p =>
        p.Age < 30
            ? "До 30 лет"
            : p.Age < 50
                ? "30-49 лет"
                : "50 лет и старше");

foreach (var group in groups)
{
    Console.WriteLine(
        $"{group.Key}: {group.Count()} пациентов");
}



// АСИНХРОННАЯ ЗАГРУЗКА ДАННЫХ


Console.WriteLine();
Console.WriteLine("=== Асинхронная загрузка данных ===");

List<Patient> loadedPatients =
    await LoadPatientsAsync();

Console.WriteLine(
    $"Загружено пациентов: {loadedPatients.Count}");

foreach (Patient p in loadedPatients)
{
    Console.WriteLine(
        $"{p.Id}. {p.FullName}, {p.Age} лет");
}



// TASK.WHENALL


Console.WriteLine();
Console.WriteLine("=== TASK.WHENALL ===");

Task<List<Patient>> task1 =
    LoadPatientsAsync();

Task<List<Patient>> task2 =
    LoadPatientsAsync();

Task<List<Patient>> task3 =
    LoadPatientsAsync();

List<Patient>[] results =
    await Task.WhenAll(
        task1,
        task2,
        task3);

int totalLoaded =
    results.Sum(list => list.Count);

Console.WriteLine(
    $"Всего загружено из трёх источников: {totalLoaded}");


// CANCELLATION TOKEN


Console.WriteLine();
Console.WriteLine("=== CANCELLATION TOKEN ===");

using CancellationTokenSource cts =
    new CancellationTokenSource();

Task<List<Patient>> cancellationTask =
    LoadPatientsWithCancellationAsync(
        cts.Token);

await Task.Delay(1000);

cts.Cancel();

await cancellationTask;



// ЗАВЕРШЕНИЕ


Console.WriteLine();
Console.WriteLine("Работа программы завершена.");



// АСИНХРОННЫЙ МЕТОД ЗАГРУЗКИ


static async Task<List<Patient>> LoadPatientsAsync()
{
    try
    {
        Console.WriteLine(
            "Получение данных из внешней системы...");

        await Task.Delay(1000);

        List<Patient> patients = new()
        {
            new Patient(
                10,
                "Орлов Максим Сергеевич",
                31,
                "+375 25 111-22-33"),

            new Patient(
                11,
                "Козлова Мария Андреевна",
                26,
                "+375 29 444-55-66"),

            new Patient(
                12,
                "Волков Дмитрий Олегович",
                54,
                "+375 33 777-88-99")
        };

        return patients;
    }
    catch (Exception ex)
    {
        Console.WriteLine(
            $"Ошибка загрузки данных: {ex.Message}");

        return new List<Patient>();
    }
    finally
    {
        Console.WriteLine(
            "Асинхронная операция завершена.");
    }
}



//  МЕТОД С CANCELLATION TOKEN


static async Task<List<Patient>> LoadPatientsWithCancellationAsync(
    CancellationToken cancellationToken)
{
    try
    {
        Console.WriteLine(
            "Начата длительная загрузка...");

        await Task.Delay(
            5000,
            cancellationToken);

        return new List<Patient>
        {
            new Patient(
                201,
                "Тестовый Пациент",
                40,
                "+375 29 000-00-00")
        };
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine(
            "Операция была отменена.");

        return new List<Patient>();
    }
}