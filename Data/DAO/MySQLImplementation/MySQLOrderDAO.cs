using MySql.Data.MySqlClient;
using PhoneMysql.Data.DAO.Interface;
using PhoneMysql.Data.Entities;
using PhoneMysql.Data.DB;
using System;

namespace PhoneMysql.Data.DAO.MySQLImplementation
{
    public class MySQLOrderDAO : OrderDAO
    {
        private readonly DBConnection dbConnection;

        public MySQLOrderDAO(DBConnection connection)
        {
            dbConnection = connection;
        }

        public int add(Order order)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Order (user_fk, order_date) VALUES (@user_fk, @order_date)", dbConnection.GetConnection());
                    
                    cmd.Parameters.AddWithValue("@user_fk", order.userId);
                    cmd.Parameters.AddWithValue("@order_date", order.orderDate);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to add order: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }

        public int delete(Order order)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM order WHERE id = @Id", dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@id", order.Id);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to delete order: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }

        public Order getOrderById(int id)
        {
            Order order = null;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM order WHERE id = @id", dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new Order
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                userId = Convert.ToInt32(reader["user_fk"]),
                                orderDate = Convert.ToDateTime(reader["order_date"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to take order info: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return order;
        }

        public int update(Order order)
        {
            int rowsAffected = 0;

            try
            {
                if (dbConnection.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE order SET user_fk = @User_fk, order_date = @order_date WHERE Id = @Id", dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@user_fk", order.userId);
                    cmd.Parameters.AddWithValue("@order_date", order.orderDate);
                    cmd.Parameters.AddWithValue("@Id", order.Id);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR when try to update order info: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return rowsAffected;
        }
    }
}
