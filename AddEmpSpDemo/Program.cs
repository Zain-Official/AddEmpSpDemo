using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AddEmpSpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch;
            do
            {
                Console.WriteLine("OPTIONS");
                Console.WriteLine("0. Clear Screen");
                Console.WriteLine("1. Show Records");
                Console.WriteLine("2. Insert Records");
                Console.WriteLine("3. Update Records");
                Console.WriteLine("4. Delete Records");
                Console.WriteLine("5. Search Records");
                Console.WriteLine("6. Exist");

                ch = Convert.ToInt32(Console.ReadLine());

                if(ch == 1)
                {
                    EmployeCrud employeCrud = new EmployeCrud();
                    DataTable dt = employeCrud.ShowData();

                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine("Employe ID : " + dr["emp_ID"]);
                        Console.WriteLine("Employe Name : " + dr["emp_Name"]);
                        Console.WriteLine("Employe Age : " + dr["emp_Age"]);
                        Console.WriteLine("Employe Country : " + dr["emp_Nationality"]);
                        Console.WriteLine("Employe Gender : " + dr["emp_Gender"]);
                        Console.WriteLine("Employe Salary : " + dr["emp_Salary"]);

                        Console.WriteLine("\n**************************\n");
                    }          

                }

                else if (ch == 2)
                {
                    Employe emplo = new Employe();
                    Console.WriteLine("Enter Employe Name");
                    emplo.Name = Console.ReadLine();

                    Console.WriteLine("Enter Employe Age");
                    emplo.Age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Employe Country Name");
                    emplo.Country = Console.ReadLine();

                    Console.WriteLine("Enter Employe Gender");
                    emplo.Gender = Console.ReadLine();

                    Console.WriteLine("Enter Employe Salary");
                    emplo.Salary = Convert.ToInt32(Console.ReadLine());

                    EmployeCrud employeCrud = new EmployeCrud();
                    employeCrud.InsertValue(emplo.Name, emplo.Age, emplo.Country, emplo.Gender, emplo.Salary);

                }

                

                else if (ch == 3)
                {
                    Console.WriteLine("Updated Soon ......!");
                }
                else if (ch == 4)
                {
                    Employe employe = new Employe();
                    Console.WriteLine("Enter Employe ID");
                    employe.Empno = Convert.ToInt32(Console.ReadLine());
                    EmployeCrud employeCrud = new EmployeCrud();
                   employeCrud.DeleteRecords(employe.Empno);
                }
                else if (ch == 5)
                {
                    //Search Employe Method

                    Employe employe = new Employe();       
                    Console.WriteLine("Enter Employe ID");
                     employe.Empno = Convert.ToInt32(Console.ReadLine());
                    EmployeCrud employeCrud = new EmployeCrud();
                    Employe result = employeCrud.SearchEmploye(employe.Empno);
                    if (result != null)
                    {
                        Console.WriteLine(result);
                    }
                   
                }

                else if (ch == 6)
                {
                    Environment.Exit(0);
                   
                }
                else if (ch == 0)
                {
                    Console.Clear();
                }
               
                else
                {
                    Console.WriteLine("Please Enter Correct Option");
                }


            } while (ch != 6);


        
            }
        }
    }

