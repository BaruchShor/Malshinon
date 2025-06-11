using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class TargetsManager : PeopleManager
    {
        public Person Target { get; set; }

        public ReportsDAL ReportsSelected = new ReportsDAL();

        public TargetsManager(string firstName, string lastName) : base(firstName, lastName)
        {
            this.ReportsSelected.GetReportsByTargetId(peopleList[0].Id);
        }

        public void CreateTarget()
        {
            this.Target = new Person(this.FirstName, this.LastName, 0, 1, CreateSecretCode(), "target");
            InsertNewPerson(this.Target);
        }

        public void UpdateMentionTarget()
        {
            UpdateMentionCount(peopleList[0].Id);
        }

        public bool IsTheTargetDangerous()
        {
            TimeSpan disdans = ReportsSelected.reportsList[0].DateTime - ReportsSelected.reportsList[ReportsSelected.reportsList.Count() - 1].DateTime;
            if (disdans.TotalMinutes <= 15)
            {
                return true;
            }
            return false;
        }

        public void UpdateTypeMalshin()
        {
            if (peopleList[0].NumReports > 0)
            {
                UpdateType(peopleList[0].Id, "both");
            }
        }
    }
}
