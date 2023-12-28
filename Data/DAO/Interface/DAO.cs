namespace PhoneMysql.Data.DAO.Interface
{
    public interface DAO<T>
    {
        int add(T t);
        int update(T t);
        int delete(T t);
    }
}
