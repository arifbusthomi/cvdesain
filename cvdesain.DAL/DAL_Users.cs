using System;

namespace cvdesain.DAL
{
    public class DAL_Users
    {
        public IEnumerable<Employee> Employees()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@DeptId", null);   
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.DeptId = Convert.ToInt32(rdr["DeptId"]);
                    employees.Add(employee);
                }
            }
            return employees;
        }
    }
}
