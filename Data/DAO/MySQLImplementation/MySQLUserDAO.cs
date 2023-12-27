using MySql.Data.MySqlClient;
using PhoneMysql.Data.DAO.Interface;
using PhoneMysql.Data.DB;
using PhoneMysql.Data.Entities;

namespace PhoneMysql.Data.DAO.MySQLImplementation
{
    public class MySQLUserDAO : UserDAO
    {
        private readonly DBConnection dbConnection;

        public MySQLUserDAO(DBConnection connection)
        {
            dbConnection = connection;
        }

        public int add(User user)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO user (name, email, surname, password, role_fk) VALUES (@name, @email, @surname, @password, @role_fk)", dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@surname", user.Surname);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role_fk", user.RoleId);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to add user: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }

        public int delete(User user)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM Users WHERE Id = @Id", dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@Id", user.Id); 

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to delete user: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }

        public User getUserByEmail(string email)
        {
            User user = null;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE Email = @Email", dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),
                                Email = reader["email"].ToString(),
                                Surname = reader["surname"].ToString(),
                                Password = reader["password"].ToString(),
                                RoleId = Convert.ToInt32(reader["role_fk"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to take user by Email: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return user;
        }

        public int update(User user)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Users SET Name = @name, email = @email, surname = @surname, password = @password, role_fk = @role_fk WHERE id = @Id", dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@surname", user.Surname);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role_fk", user.RoleId);
                    cmd.Parameters.AddWithValue("@id", user.Id); 

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to update user info: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }
    }
}
