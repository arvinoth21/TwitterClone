using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string SayHello(string name)
        {
            string wish = "";
            if (DateTime.Now.Hour < 12)
            {
                wish = "Good Morning";
            }
            else if (DateTime.Now.Hour < 17)
            {
                wish = "Good Afternoon";
            }
            else
            {
                wish = "Good Evening";
            }

            return "Hello  " + name + "    Wish You..  " + wish;

        }

        public string TodayProgram(string name)
        {
            if (DateTime.Now.DayOfWeek.ToString() == "Sunday" || DateTime.Now.DayOfWeek.ToString() == "Sataurday")
            {
                return "Hi-  " + name + "  Happy Weekend";
            }
            else
            {
                return "Hi-  " + name + "   Enjoy Workday";
            }
        }

        public List<string> OpeningJobs()
        {
            List<string> objjob = new List<string>() { "IT", "Mechanic", "Civil", "Tailoring" };

            return objjob;

        }

        public string OpeningJobsByRole(int id)
        {
            List<string> objjob = new List<string>() { "IT", "Mechanic", "Civil", "Tailoring" };

            if (id <= 3)
            {
                return objjob[id];
            }
            else
            {
                return "Job not found";
            }

        }
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
