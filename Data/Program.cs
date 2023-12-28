using PhoneMysql.Data.DAO.Interface;
using PhoneMysql.Data.DAO.MySQLImplementation;
using PhoneMysql.Data.DB;
using PhoneMysql.Data.Entities;

namespace PhoneMysql.Data
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string server = "localhost";
            string database = "mydb";
            string userId = "root";
            string password = "M8Y7C2ndwNM7V";

            DBConnection dbConnection = DBConnection.GetInstance(server, database, userId, password);

            Order orderToDelete = new Order { Id = 123 };
            OrderDAO orderDAO = new MySQLOrderDAO(dbConnection);


            int userRoleId = 2; //додамо роль, для прикладу

            //створення прокси OrderDAO
            OrderDAO orderProxyDAO = new OrderProxyDAO(orderDAO, userRoleId);

            orderProxyDAO.delete(orderToDelete);
        }
    }
}