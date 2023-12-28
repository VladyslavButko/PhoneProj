using PhoneMysql.Data.Entities;

namespace PhoneMysql.Data.Observer
{
    internal class UserAddedNotifier : UserObserver
    {
        void UserObserver.userAdded(User user)
        {
            Console.WriteLine($"OBSERVER. New user added: {user.Name} - {user.Surname}");
        }
    }
}
