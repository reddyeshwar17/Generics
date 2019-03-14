using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleUIGenerics.WithGenerics
{
    public class OriginalFileProcessor
    {
        public static void SaveData<T>(List<T> entryList, string filePath) where T : class, new()
        {
            List<string> personList = new List<string>();
            StringBuilder builder = new StringBuilder();
            var lines = entryList[0].GetType().GetProperties();

            foreach (var line in lines)
            {
                builder.Append(line.Name);
                builder.Append(",");
            }
            personList.Add(builder.ToString().Substring(0, builder.Length - 1));
            foreach (var row in entryList)
            {
                builder = new StringBuilder();
                foreach (var line in lines)
                {
                    builder.Append(line.GetValue(row));
                    builder.Append(",");
                }
                personList.Add(builder.ToString().Substring(0, builder.Length - 1));
            }
            File.WriteAllLines(filePath, personList);
        }

        public static List<T> LoadData<T>(string filePath) where T : class, new()
        {
            List<T> data = new List<T>();
            var lines = File.ReadAllLines(filePath).ToList();
            T entry = new T();
            var cols = entry.GetType().GetProperties();
            if (lines.Count < 2)
            {
                throw new Exception("No data found to load");
            }
            var header = lines[0].Split(',');
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                entry = new T();
                var vols = line.Split(',');
                for (int i = 0; i < header.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        if (col.Name == header[i])
                        {
                            col.SetValue(entry, Convert.ChangeType(vols[i], col.PropertyType));
                        }
                    }
                }
                data.Add(entry);
            }
            return data;
        }
    }
}