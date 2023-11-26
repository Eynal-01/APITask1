namespace APITask1.Services.Abstract
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);  
    }
}
