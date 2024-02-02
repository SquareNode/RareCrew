using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RareCrew
{
    internal class View
    {
        public static void createHTML(SortedList<int, string> data)
        {

            var firstPart = "<html><head><title> Employees </title> </head><body>";

            var table = "<table><tr><th>Name</th><th>Hours</th></tr>";

            foreach (var emp in data)
            {
                table += "<tr" + (emp.Key / 60 < 100 ? " style = \"background-color: coral\">" : ">") + 
                    "<td>" + emp.Value + "</td><td>" + emp.Key / 60 + "</td></tr>";
            }

            table += "</table>";

            var lastPart = "</body></html>";

            var html = firstPart + table + lastPart;

            try
            {
                File.WriteAllText("../../../emps.html", html);

            }catch(Exception e)
            {
                Console.Error.WriteLine("EXCEPTION while writing to the .html file! " + e.Message);
                throw e;
            }

        }
    }
}
