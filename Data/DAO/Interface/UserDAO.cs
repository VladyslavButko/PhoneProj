using PhoneMysql.Data.Entities;
using PhoneMysql.Data.Observer;

namespace PhoneMysql.Data.DAO.Interface
{
    public interface UserDAO : DAO<User>
    {
        User getUserByEmail(string email);
        void userAddedObserver(UserObserver observer);
    }
}
