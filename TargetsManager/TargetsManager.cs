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

        public TargetsManager(string firstName, string lastName) : base(firstName, lastName)
        {
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
            if (this.ReportsSelected.GetMinuteDifference() <= 15)
            {
                return true;
            }
            return false;
        }

        public void UpdateTypeTarget()
        {
            if (peopleList[0].NumReports > 0)
            {
                UpdateType(peopleList[0].Id, "both");
            }
        }
    }
}
