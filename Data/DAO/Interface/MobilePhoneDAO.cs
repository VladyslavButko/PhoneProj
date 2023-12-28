using PhoneMysql.Data.Entities;
namespace PhoneMysql.Data.DAO.Interface
{
    public interface MobilePhoneDAO : DAO<MobilePhone>
    {
        MobilePhone getPhoneByModel(string model);
        
    }
}
