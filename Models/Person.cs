using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecretCode { get; set; }

        public string Type { get; set; }

        public int NumReports { get; set; }

        public int NumMentions { get; set; }

        public Person(string firstName, string lastName, string SecretCode, string type, int numReport, int numMentios)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SecretCode = SecretCode;
            this.Type = type;
            this.NumReports = numReport;
            this.NumMentions = numMentios;
        }

    }
}
