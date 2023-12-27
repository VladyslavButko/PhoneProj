using PhoneMysql.Data.DAO.Interface;
using PhoneMysql.Data.DAO.MySQLImplementation;
using PhoneMysql.Data.DB;
using PhoneMysql.Data.Entities;
using System;

namespace PhoneMysql.Data.FactoryMethode
{
    public class DAOFactory
    {
        public enum DAOType
        {
            MobilePhone,
            Order,
            User
        }

        public static DAO<T> GetDAO<T>(DAOType daoType, DBConnection connection)
        {
            switch (daoType)
            {
                case DAOType.MobilePhone:
                    return (DAO<T>)new MySQLMobilePhoneDAO(connection);
                case DAOType.Order:
                    if (typeof(T) == typeof(Order))
                    {
                        return (DAO<T>)new MySQLOrderDAO(connection);
                    }
                    else
                    {
                        throw new ArgumentException("Unsupported DAO Type for Order");
                    }
                case DAOType.User:
                    if (typeof(T) == typeof(User))
                    {
                        return (DAO<T>)new MySQLUserDAO(connection);
                    }
                    else
                    {
                        throw new ArgumentException("Unsupported DAO Type for User");
                    }
                default:
                    throw new ArgumentException("Unsupported DAO Type");
            }
        }
    }
}
