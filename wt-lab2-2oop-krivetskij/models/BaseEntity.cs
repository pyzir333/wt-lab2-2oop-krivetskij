namespace wt_lab2_2oop_krivetskij.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    protected BaseEntity(int id)
    {
        Id = id;
        CreatedAt = DateTime.Now;
    }

    public abstract void PrintInfo();

    protected void PrintBaseInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Дата создания: {CreatedAt:dd.MM.yyyy HH:mm}");
    }
}