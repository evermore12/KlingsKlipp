namespace KlingsKlipp.Data.Services
{
    public interface ICRUDService<T> 
    {
        T Model { get; }
        T Create(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(int id);
    }
}
