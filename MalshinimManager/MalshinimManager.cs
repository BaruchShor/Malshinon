using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class MalshinimManager : PeopleManager
    {
        public Person Malshin { get; set; }

        public MalshinimManager(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public void CreateMalshin()
        {
            this.Malshin = new Person(this.FirstName, this.LastName, 1, 0, CreateSecretCode(), "reporter");
            InsertNewPerson(this.Malshin);
        }

        public void UpdateReportsMalshin()
        {
            UpdateReportCount(peopleList[0].Id);
        }

        public void UpdateTypeMalshin()
        {
            if (peopleList[0].NumMentions > 0)
            {
                UpdateType(peopleList[0].Id, "both");
            }else if(peopleList[0].NumReports > 10 && this.ReportsSelected.GetReporterStats() >= 100)
            UpdateType(peopleList[0].Id, "potential_agent");
        }
    }
}
