using System.Data;
using Microsoft.Data.SqlClient;

namespace ModelBinding.Models
{
    public class Employee
    {

        public int EmpNo { get; set; }
        public string? Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }



        public static List<Employee> GetAllEmployees()
        {

            List<Employee> list = new List<Employee>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True;";

            try
            {
                con.Open();
                SqlCommand cmd =new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * from Employee";

                SqlDataReader reader = cmd.ExecuteReader();
               

                while (reader.Read())
                {
                    Employee emp = new Employee();
                    /* emp.EmpNo = (int)reader["EmpNo"];
                     emp.Name = (string)reader["Name"];
                     emp.Basic = (decimal)reader["Basic"];
                     emp.DeptNo = (int)reader["DeptNo"];
                    */

                    emp.EmpNo = reader.GetInt32("EmpNo");
                    emp.Name = reader.GetString("Name");
                    emp.Basic =reader.GetDecimal("Basic");
                    emp.DeptNo = reader.GetInt32("DeptNo");
                    list.Add(emp);

                }
                reader.Close();


            }catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return list;


        } 

        public static Employee GetSingleEmployee(int? EmpNo)
        {
            Employee emp = new Employee();
            SqlConnection con  = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                con.Open();
                SqlCommand cmd =new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Employee where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNO", EmpNo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    emp.EmpNo = reader.GetInt32("EmpNo");
                    emp.Name = reader.GetString("Name");
                    emp.Basic = reader.GetDecimal("Basic");
                    emp.DeptNo = reader.GetInt32("DeptNo");
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally { con.Close(); }
            return emp;
        }

        public static void Update(Employee obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                con.Open();

                // SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Employee set Name=@Name,Basic=@Basic,DeptNo=@DeptNo where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }


        }

        public static void Delete(int EmpNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                // SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Employee where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }


        public static void Insert(Employee obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                con.Open();

                // SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Employee values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }


        }

    }
}
