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
            this.NumReports = 1;
            this.NumMentions = 0;
            this.Type = "reporter";
        }

        public void CreateMalshin()
        {
            this.Malshin = new Person(this.FirstName, this.LastName, this.NumReports, this.NumMentions, this.SecretCode, this.Type);
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
                this.Type = "both";
                UpdateType(peopleList[0].Id, this.Type);
            }else if(peopleList[0].NumReports > 10 && this.ReportsSelected.GetReporterStats() >= 100)
            {
                this.Type = "potential_agent";
                UpdateType(peopleList[0].Id, this.Type);
            }
        }

        public override void RunManageLocalSystem()
        {
            if (IsExsist())
            {
                UpdateReportsMalshin();
                UpdateTypeMalshin();
            }
            else
            {
                CreateMalshin();
            }
        }
    }
}
