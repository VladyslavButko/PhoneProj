using PhoneMysql.Data.DAO.Interface;
using PhoneMysql.Data.Entities;
using PhoneMysql.Data.DB;

namespace PhoneMysql.Data.DAO.MySQLImplementation
{
        public enum UserRole //Можливі ролі
        {
            Admin = 1,
            User = 2
        }

        public class OrderProxyDAO : OrderDAO
        {

            private readonly DBConnection dbConnection;
            private readonly User currentUser;

            private readonly OrderDAO orderDAO;
            private readonly int userRoleId; // Роль користувача

            public OrderProxyDAO(OrderDAO dao, int userRoleId)
            {
                this.orderDAO = dao;
                this.userRoleId = userRoleId;
            }

            public int add(Order order)
            {
                return orderDAO.add(order);
            }

            public int delete(Order order)
            {
                //Метод тільки для адміна
                if (userRoleId == (int)UserRole.Admin)
                {
                    return orderDAO.delete(order);
                }
                else
                {
                    Console.WriteLine("Access denied. Only admins can delete orders.");
                    return -1;
                }
            }

            public Order getOrderById(int id)
            {
                return orderDAO.getOrderById(id);
            }

            public int update(Order order)
            {
                //Метод тільки для адміна
                if (userRoleId == (int)UserRole.Admin)
                {
                    return orderDAO.update(order);
                }
                else
                {
                    Console.WriteLine("Access denied. Only admins can update orders.");
                    return -1;
                }

            }
        }
}
