using PhoneMysql.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneMysql.Data.DAO.Interface
{
    public interface UserDAO : DAO<User>
    {
        User getUserByEmail(string email);
    }
}
