using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Asn1.Cmp;
using PhoneMysql.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneMysql.Data.DAO.Interface
{
    public interface DAO<T>
    {
        int add(T t);
        int update(T t);
        int delete(T t);
    }
}
