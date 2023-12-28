using PhoneMysql.Data.Entities;
namespace PhoneMysql.Data.DAO.Interface
{
    public interface OrderDAO : DAO<Order>
    {
        Order getOrderById(int id);
    }
}
