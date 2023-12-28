using MySql.Data.MySqlClient;
using PhoneMysql.Data.DAO.Interface;
using PhoneMysql.Data.Entities;
using PhoneMysql.Data.DB;

namespace PhoneMysql.Data.DAO.MySQLImplementation
{
    public class MySQLMobilePhoneDAO : MobilePhoneDAO
    {
        private readonly DBConnection dbConnection;
        
        public MySQLMobilePhoneDAO(DBConnection connection)
        {
            dbConnection = connection;
        }

        public int add(MobilePhone mobilePhone)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO mobile_phones (brand, model, storage, RAM, screenSize, camera, batteryCapacity, price) VALUES (@Brand, @Model, @Storage, @RAM, @ScreenSize, @Camera, @BatteryCapacity, @Price)", dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@Brand", mobilePhone.brand);
                    cmd.Parameters.AddWithValue("@Model", mobilePhone.model);
                    cmd.Parameters.AddWithValue("@Storage", mobilePhone.storage);
                    cmd.Parameters.AddWithValue("@RAM", mobilePhone.RAM);
                    cmd.Parameters.AddWithValue("@ScreenSize", mobilePhone.screenSize);
                    cmd.Parameters.AddWithValue("@Camera", mobilePhone.camera);
                    cmd.Parameters.AddWithValue("@BatteryCapacity", mobilePhone.batteryCapacity);
                    cmd.Parameters.AddWithValue("@Price", mobilePhone.price);

                    rowsAffected = cmd.ExecuteNonQuery();

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to add phone: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }

        public int delete(MobilePhone mobilePhone)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM mobile_phones WHERE Id = @Id", dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", mobilePhone.Id);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERORR when try to delete phone: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }

        public MobilePhone getPhoneByModel(string model)
        {
            MobilePhone mobilePhone = null;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM mobile_phone WHERE model = @Model", dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@Model", model);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mobilePhone = new MobilePhone
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                brand = reader["brand"].ToString(),
                                model = reader["model"].ToString(),
                                storage = reader["storage"].ToString(),
                                RAM = reader["RAM"].ToString(),
                                screenSize = Convert.ToDouble(reader["screenSize"]),
                                camera = reader["camera"].ToString(),
                                batteryCapacity = Convert.ToInt32(reader["batteryCapacity"]),
                                price = Convert.ToDouble(reader["price"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to take mobile info: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return mobilePhone;
        }

        public int update(MobilePhone mobilePhone)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE mobile_phones SET brand = @Brand, storage = @Storage, RAM = @RAM, screenSize = @ScreenSize, camera = @Camera, batteryCapacity = @BatteryCapacity, price = @Price WHERE model = @Model", dbConnection.GetConnection());

                    // Передача параметров запроса
                    cmd.Parameters.AddWithValue("@Brand", mobilePhone.brand);
                    cmd.Parameters.AddWithValue("@Storage", mobilePhone.storage);
                    cmd.Parameters.AddWithValue("@RAM", mobilePhone.RAM);
                    cmd.Parameters.AddWithValue("@ScreenSize", mobilePhone.screenSize);
                    cmd.Parameters.AddWithValue("@Camera", mobilePhone.camera);
                    cmd.Parameters.AddWithValue("@BatteryCapacity", mobilePhone.batteryCapacity);
                    cmd.Parameters.AddWithValue("@Price", mobilePhone.price);
                    cmd.Parameters.AddWithValue("@Model", mobilePhone.model);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to update mobile info: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }
    }
}