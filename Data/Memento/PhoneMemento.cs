using PhoneMysql.Data.Entities;

namespace PhoneMysql.Data.Memento
{
    public class PhoneMemento
    {
        public MobilePhone State { get; private set; }

        public PhoneMemento(MobilePhone state)
        {
            State = state;
        }
    }
}
