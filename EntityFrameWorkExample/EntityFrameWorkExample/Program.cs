using System;
using System.Linq;
using EntityFrameWorkExample.OrgModel;

namespace EntityFrameWorkExample
{
    class Program
    {
        public static employeeSalaryContext db = new employeeSalaryContext();
        static void Main(string[] args)
        {
            Employee e1 = AcceptData();
            InsertData(e1);
            Console.WriteLine("Records updated successfully");
            SelectData();

        }
        private static void SelectData()
        {
            var result = db.Employees.ToList();
            foreach (var item in result)
            {
                Console.WriteLine("Employee Name :" + item.Name);
                Console.WriteLine("Employee Id :" + item.EmpId);
                Console.WriteLine("Employee Phone :" + item.Phone);
                Console.WriteLine("Employee Email :" + item.Email);
            }
        }
        private static void InsertData(Employee e1)
        {
            db.Employees.Add(e1);
            db.SaveChanges();
        }
        private static Employee AcceptData()
        {
            Employee e = new Employee();
            Console.WriteLine("Enter your Name");
            e.Name = Console.ReadLine();
            Console.WriteLine("Enter the age");
            e.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Phone number");
            e.Phone = Console.ReadLine();
            Console.WriteLine("Enter your Gender");
            e.Gender = Console.ReadLine();
            Console.WriteLine("Enter your EmailID");
            e.Email = Console.ReadLine();
            return e;
        }
    }
}
