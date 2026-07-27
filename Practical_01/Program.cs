using System;
using System.Collections.Generic;

namespace StudentAdmissionSystem
{
    public class Applicant
    {
        private static int nextAdmissionNo = 1000;

        public int AdmissionNo { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public double Percentage { get; set; }

        public Applicant(string name, int age, string course, double percentage)
        {
            AdmissionNo = ++nextAdmissionNo;
            Name = name;
            Age = age;
            Course = course;
            Percentage = percentage;
        }

        public bool IsEligible()
        {
            return Percentage >= 50;
        }

        public void DisplayApplicant()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Admission No : " + AdmissionNo);
            Console.WriteLine("Name         : " + Name);
            Console.WriteLine("Age          : " + Age);
            Console.WriteLine("Course       : " + Course);
            Console.WriteLine("Percentage   : " + Percentage);
            Console.WriteLine("Status       : " + (IsEligible() ? "Admission Granted" : "Admission Rejected"));
        }
    }

    public class AdmissionManager
    {
        private List<Applicant> applicantList = new List<Applicant>();

        public void AddApplicant(string name, int age, string course, double percentage)
        {
            Applicant student = new Applicant(name, age, course, percentage);
            applicantList.Add(student);

            Console.WriteLine(name + " has been registered successfully.");
        }

        public void ShowApplicants()
        {
            Console.WriteLine("\n===== Applicant List =====");

            foreach (Applicant student in applicantList)
            {
                student.DisplayApplicant();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AdmissionManager manager = new AdmissionManager();

            manager.AddApplicant("Hrushikesh Gangajadiya", 20, "B.Tech CSE", 86.5);
            manager.AddApplicant("Aastha Valani", 19, "BCA", 72.4);
            manager.AddApplicant("Amit Shah", 18, "BBA", 45.0);

            manager.ShowApplicants();

            Console.ReadLine();
        }
    }
}