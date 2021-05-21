using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace AddEmpSpDemo
{

    class EmployeCrud
    {
        SqlConnection con;
        SqlCommand cmd;

        public DataTable ShowData()
        {
            con = ConnectionHelper.GetSqlConnection();
            con.Open();
            cmd = new SqlCommand("prcemployShow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader DR = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(DR);
            con.Close();
            return dt;
        }

        public void InsertValue(string name,int age,string country,string gender,int salary)
        {
            con = ConnectionHelper.GetSqlConnection();
            con.Open();
            cmd = new SqlCommand("prcEmpInsertings", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record Inserted Successfully");
        }

        public Employe SearchEmploye(int empno)
        {
            con = ConnectionHelper.GetSqlConnection();
            con.Open();
            cmd = new SqlCommand("prcemploySearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empno", empno);
            SqlDataReader dr = cmd.ExecuteReader();
            Employe employe = null;
            if (dr.Read())
            {
                employe = new Employe();
             
                Console.WriteLine("**********************");
                Console.WriteLine("Employe ID : " + dr["emp_ID"]);
                Console.WriteLine("Employe Name : " + dr["emp_Name"]);
                Console.WriteLine("Employe Age : " + dr["emp_Age"]);
                Console.WriteLine("Employe Country : " + dr["emp_Nationality"]);
                Console.WriteLine("Employe Gender : " + dr["emp_Gender"]);
                Console.WriteLine("Employe Salary : " + dr["emp_Salary"]);

                Console.WriteLine("*************************");
            }
            else
                Console.WriteLine("Record Not Found.....");

            return employe;
        }

        public void DeleteRecords(int empno)
        {
            con = ConnectionHelper.GetSqlConnection();
            con.Open();
            cmd = new SqlCommand("prcEmpDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empno", empno);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record Deleted Successfully......");
        }

    }
}
