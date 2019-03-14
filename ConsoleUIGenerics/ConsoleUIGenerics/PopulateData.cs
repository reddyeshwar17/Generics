using ConsoleUIGenerics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUIGenerics
{
    public class PopulateData
    {
        public static void PopulateList(List<Person> person, List<Logs> logs)
        {
            person.Add(new Person { FirstName = "Eswar", LastName = "Reddy", Age = 28 });
            person.Add(new Person { FirstName = "Deva", LastName = "Zone", Age = 25 });
            person.Add(new Person { FirstName = "Hemani", LastName = "Reddy", Age = 1 });

            logs.Add(new Logs { ErrorCode = "401", Message = "Un authorized", TimeOfEvent = DateTime.Now });
            logs.Add(new Logs { ErrorCode = "200", Message = "ok no issues", TimeOfEvent = DateTime.Now });
            logs.Add(new Logs { ErrorCode = "400", Message = "Not found", TimeOfEvent = DateTime.Now });
        }
    }
}
