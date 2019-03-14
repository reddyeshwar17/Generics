using ConsoleUIGenerics.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleUIGenerics.WithoutGenerics
{
    public class OriginalFileProcessor
    {
        public static void SavePeople(List<Person> person, string filePath)
        {
            List<string> lines = new List<string>();
            //add header
            lines.Add($"FirstName,LastName,Age");
            foreach (var p in person)
            {
                lines.Add($"{p.FirstName},{p.LastName},{p.Age}");
            }
            File.WriteAllLines(filePath, lines);
        }

        public static List<Person> LoadPeople(string filePath)
        {
            Person p;
            List<Person> person = new List<Person>();
            var lines = File.ReadAllLines(filePath).ToList();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                var vals = line.Split(',');
                p = new Person();
                p.FirstName = vals[0];
                p.LastName = vals[1];
                p.Age = int.Parse(vals[2]);
                person.Add(p);
            }
            return person;
        }

        public static void SaveLog(List<Logs> logs, string logPath)
        {
            List<string> lines = new List<string>();
            lines.Add($"ErrorCode,Message,TimeOfEvent");
            foreach (var log in logs)
            {
                lines.Add($"{log.ErrorCode},{log.Message},{log.TimeOfEvent}");
            }
            File.WriteAllLines(logPath, lines);
        }
    }
}