using System;

namespace Practical_03
{
    internal class Program
    {
        // Super Class
        class Employee
        {
            // Data Members
            public int id;
            public string name;
            public double bsal;
            public int leaveDays;

            // Constructor
            public Employee()
            {
                Console.WriteLine("Employee");
            }

            // Accept Employee Details
            public void Accept()
            {
                Console.Write("Enter Employee ID : ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Name : ");
                name = Console.ReadLine();   // Example: Aastha

                Console.Write("Enter Basic Salary : ");
                bsal = Convert.ToDouble(Console.ReadLine());
            }

            // Display Employee Details
            public void DisplayDetails()
            {
                Console.WriteLine("\n----- Employee Details -----");
                Console.WriteLine("Employee ID : " + id);
                Console.WriteLine("Employee Name : " + name);
                Console.WriteLine("Basic Salary : " + bsal);
            }
        }

        // Interface
        interface IPayrollIntr
        {
            void CalSal();
        }

        // Full Time Employee
        class FullTime : Employee, IPayrollIntr
        {
            public void CalSal()
            {
                // Salary Components
                double da = bsal * 0.20;
                double hra = bsal * 0.20;
                double ma = bsal * 0.20;
                double pf = bsal * 0.05;

                // Net Salary before leave deduction
                double netSal = (bsal + da + hra + ma) - pf;

                // Leave Details
                Console.Write("\nEnter Number of Leave Days : ");
                leaveDays = Convert.ToInt32(Console.ReadLine());

                // Per Day Salary
                double perDaySalary = netSal / 30;

                // Leave Deduction
                double leaveDeduction = perDaySalary * leaveDays;

                // Final Salary
                double finalSalary = netSal - leaveDeduction;

                Console.WriteLine("\n------ Payroll Details ------");
                Console.WriteLine("Basic Salary        : " + bsal);
                Console.WriteLine("DA (20%)            : " + da);
                Console.WriteLine("HRA (20%)           : " + hra);
                Console.WriteLine("Medical Allowance   : " + ma);
                Console.WriteLine("PF (5%)             : " + pf);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Net Salary          : " + netSal);
                Console.WriteLine("Per Day Salary      : " + perDaySalary);
                Console.WriteLine("Leave Days          : " + leaveDays);
                Console.WriteLine("Leave Deduction     : " + leaveDeduction);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Final Salary        : " + finalSalary);
            }
        }

        // Part Time Employee
        class PartTime : Employee, IPayrollIntr
        {
            public void CalSal()
            {
                Console.WriteLine("\n------ Payroll Details ------");
                Console.WriteLine("Salary : " + bsal);
                Console.WriteLine("No Leave Deduction for Part-Time Employees.");
                Console.WriteLine("Final Salary : " + bsal);
            }
        }

        // Main Method
        static void Main(string[] args)
        {
            Console.WriteLine("Name : Hrushikesh Gangajadiya");
            Console.WriteLine("Enrollment : 92400120641");

            Console.WriteLine("\nSelect Employee Type");
            Console.WriteLine("1. Full Time");
            Console.WriteLine("2. Part Time");
            Console.Write("Enter your choice : ");

            int ch = Convert.ToInt32(Console.ReadLine());

            Employee e = null;
            IPayrollIntr p = null;

            if (ch == 1)
            {
                Console.WriteLine("\nYou have selected Full Time Employee");
                FullTime ft = new FullTime();
                e = ft;
                p = ft;
            }
            else if (ch == 2)
            {
                Console.WriteLine("\nYou have selected Part Time Employee");
                PartTime pt = new PartTime();
                e = pt;
                p = pt;
            }
            else
            {
                Console.WriteLine("Invalid Choice.");
                return;
            }

            e.Accept();
            e.DisplayDetails();
            p.CalSal();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}