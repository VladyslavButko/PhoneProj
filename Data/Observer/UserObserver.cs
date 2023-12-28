using PhoneMysql.Data.Entities;

namespace PhoneMysql.Data.Observer
{
    public interface UserObserver
    {
        void userAdded(User user);
    }
}