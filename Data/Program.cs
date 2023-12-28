using MySql.Data.MySqlClient;
using PhoneMysql.Data.DAO.Interface;
using PhoneMysql.Data.DAO.MySQLImplementation;
using PhoneMysql.Data.DB;
using PhoneMysql.Data.Entities;
using PhoneMysql.Data.FactoryMethode;
using PhoneMysql.Data.Memento;
using PhoneMysql.Data.Observer;

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

            UserObserver userAddedNotifier = new UserAddedNotifier();
            ((MySQLUserDAO)userDAO).userAddedObserver(userAddedNotifier);

            //Додавання користувача за допомогою фабрики та білдера
            User newUser = new User.Builder("John@example.com", 2, "password123")
                .setName("John")
                .setSurname("Doe")
                .Build();

            //Додавання до БД
            userDAO.add(newUser);

            User foundUser = ((MySQLUserDAO)userDAO).getUserByEmail("John@example.com");

            if (foundUser != null)
            {
                Console.WriteLine($"User found: Id: {foundUser.Id}, Name: {foundUser.Name} Email: {foundUser.Email}");
            }
            else
            {
                Console.WriteLine("User not found.");

            }


            MobilePhone phone = new MobilePhone.Builder("Apple", "iPhone 13", "128 GB", 
                "4 GB", 6.1, "12 + 12", 2815, 799.0).Build(); //Створення телефону за допомогою Builder

            // Створення списку для змін
            List<PhoneMemento> changes = new List<PhoneMemento>();

            //Збереження зміни
            changes.Add(phone.SaveState());

            // Змінюємо значення поля
            phone.price = 999.0;

            // Зберегаємо стан
            changes.Add(phone.SaveState());

            // Відміна стану
            if (changes.Count > 1)
            {
                phone.RestoreState(changes[changes.Count - 2]);
                changes.RemoveAt(changes.Count - 1);
            }



        }
    }
}