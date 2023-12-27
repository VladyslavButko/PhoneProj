using MySql.Data.MySqlClient;
using PhoneMysql.Data.DAO.Interface;
using PhoneMysql.Data.DAO.MySQLImplementation;
using PhoneMysql.Data.DB;
using PhoneMysql.Data.Entities;
using PhoneMysql.Data.FactoryMethode;

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

            // DAO для MobilePhone
            DAO<MobilePhone> mobilePhoneDAO = DAOFactory.GetDAO<MobilePhone>(DAOFactory.DAOType.MobilePhone, dbConnection);

            // DAO для Order
            DAO<Order> orderDAO = DAOFactory.GetDAO<Order>(DAOFactory.DAOType.Order, dbConnection);

            //DAO для User
            DAO<User> userDAO = DAOFactory.GetDAO<User>(DAOFactory.DAOType.User, dbConnection);

            //Додавання користувача за допомогою фабрики та білдера
            User newUser = new User.Builder("John3@example.com", 2, "432fgsdf")
                .setName("Name1")
                .setSurname("surname").Build();

            //Додавання до БД
            userDAO.add(newUser);

            User foundUser = ((MySQLUserDAO)userDAO).getUserByEmail("John3@example.com");

            if (foundUser != null)
            {
                Console.WriteLine($"User found: Id: {foundUser.Id}, Name: {foundUser.Name} Email: {foundUser.Email}");
            }
            else
            {
                Console.WriteLine("User not found.");

            }

        }
    }
}