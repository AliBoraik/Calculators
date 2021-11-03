using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using HW7.Models;

namespace HW7.Data
{
    public class PersonContext : DbContext
    {
        private readonly string _filePath;
        public List<Person> List;

        public PersonContext()
        {
            _filePath = Path.Combine("wwwroot", "Data.txt");
            SetDataDefault();
        }

        public void Add(Person p)
        {
            using (var sw = File.AppendText(_filePath))
            {
                sw.WriteLine();
                sw.Write(p.Age + "," + p.Name + "," + p.Gender);
                sw.Close();
            }
        }

        public void SetDataDefault()
        {
            List = new List<Person>();
            var filePath = Path.Combine("wwwroot", "Data.txt");
            var p = File.ReadAllLines(filePath);
            foreach (var per in p)
            {
                var s = per.Split(",");
                List.Add(new Person {Age = Convert.ToInt32(s[0]), Name = s[1], Gender = getGender(s[2])});
            }
        }

        private Gender getGender(string s)
        {
            return s switch
            {
                "Male" => Gender.Male,
                "Female" => Gender.Female,
                _ => Gender.Unknown
            };
        }
    }
}