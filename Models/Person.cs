using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumReports { get; set; }
        public int NumMentions { get; set; }
        public string SecretCode { get; set; }
        public string Type { get; set; }

        public Person(int id, string firstName, string lastName, int numMentios, int numReport, string SecretCode, string type)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NumMentions = numMentios;
            this.NumReports = numReport;
            this.SecretCode = SecretCode;
            this.Type = type;
        }

        public Person(string firstName, string lastName, int numReport, int numMentios, string SecretCode, string type)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NumReports = numReport;
            this.NumMentions = numMentios;
            this.SecretCode = SecretCode;
            this.Type = type;
        }

        public void ShowPerson()
        {
            Console.WriteLine($"First name : {this.FirstName}:\n" +
                              $"Last name : {this.LastName}\n" +
                              $"Num mentions : {this.NumMentions}\n" +
                              $"Num reports : {this.NumReports}\n" +
                              $"Secret code : {this.SecretCode}\n" +
                              $"Type : {this.Type}");
        }
    }
}
