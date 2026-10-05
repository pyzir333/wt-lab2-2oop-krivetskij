namespace wt_lab2_2oop_krivetskij.Interfaces;

public interface IItemService<T>
{
    void Add(T item);

    bool Remove(int id);

    T? GetById(int id);

    List<T> GetAll();
}