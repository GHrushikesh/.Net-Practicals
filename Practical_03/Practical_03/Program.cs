using System;
using System.Collections.Generic;

namespace Practical_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ch;
            List<Expense> expenses = new List<Expense>();

            do
            {
                Console.WriteLine("\n*************************");
                Console.WriteLine("Expense Tracker Module");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View All Expense");
                Console.WriteLine("3. View Total Expense");
                Console.WriteLine("4. Exit");
                Console.WriteLine("*************************");

                try
                {
                    Console.Write("Enter Your Choice: ");
                    ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            try
                            {
                                Expense exp = new Expense();
                                exp.accDetaild();
                                expenses.Add(exp);

                                Console.WriteLine("Expense Added Successfully.");
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Error: Invalid Input. " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Expense Processing Completed.");
                            }
                            break;

                        case 2:
                            if (expenses.Count == 0)
                            {
                                Console.WriteLine("No Expenses Found.");
                            }
                            else
                            {
                                Console.WriteLine("\nAll Expense List");
                                Console.WriteLine("Total Expenses Found: " + expenses.Count);

                                foreach (Expense expense in expenses)
                                {
                                    expense.distDet();
                                }
                            }
                            break;

                        case 3:
                            double t = 0;

                            foreach (Expense expense in expenses)
                            {
                                t = t + expense.amt;
                            }

                            Console.WriteLine("Total Expense = Rs. " + t);
                            break;

                        case 4:
                            {
                                Console.WriteLine("Thank You! Broo For Using Expense Tracker");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Choice.");
                                break;
                            }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                    ch = 0;
                }
            } while (ch != 4);
        }
    }

    class Expense
    {
        public int expenseID;
        public string catagory;
        public double amt;
        public string paymentmode;
        public DateTime expDate;

        // Method to accept expense details
        public void accDetaild()
        {
            Console.Write("Enter Expense ID: ");
            expenseID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Expense Category: ");
            catagory = Console.ReadLine();

            Console.Write("Enter Expense Amount: ");
            amt = Convert.ToDouble(Console.ReadLine());

            if (amt <= 0)
            {
                throw new Exception("Expense Amount should be greater than 0.");
            }

            Console.Write("Enter Payment Mode (Cash/UPI/Card): ");
            paymentmode = Console.ReadLine();

            expDate = DateTime.Now;
        }

        // Method to display expense details
        public void distDet()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Expense ID      : " + expenseID);
            Console.WriteLine("Category        : " + catagory);
            Console.WriteLine("Amount          : " + amt);
            Console.WriteLine("Payment Mode    : " + paymentmode);
            Console.WriteLine("Expense Date    : " + expDate);
            Console.WriteLine("--------------------------------");
        }
    }
}