//using KlingsKlipp.Data;
//using KlingsKlipp.Data.Models;
//using Microsoft.EntityFrameworkCore;

//namespace KlingsKlipp.Data.Services
//{
//    public class CRUDService<T> : ICRUDService<T> where T : class, new()
//    {
//        protected readonly Database database;
//        public T Model => new();
//        public CRUDService(Database database)
//        {
//            this.database = database;
//        }
//        public T Create(T entity)
//        {
//            database.Add(entity);
//            database.SaveChanges();
//            return entity;
//        }

//        public T Get(int id)
//        {
//            return (T)database.Find(typeof(T), id);
//        }

//        public void Delete(int id)
//        {
//            database.Remove(database.Find(typeof(T), id));
//            database.SaveChanges();
//        }

//        public void Update(T entity)
//        {
//            database.Update(entity).CurrentValues.SetValues(entity);
//            database.SaveChanges();
//        }

//        public IEnumerable<T> GetAll()
//        {
//            return database.Set<T>().ToList();
//        }
//    }
//}
