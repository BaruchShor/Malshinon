using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class TargetsManager : PeopleManager
    {
        public bool IsDangerous { get; set; }
        public Person Target { get; set; }

        public TargetsManager(string firstName, string lastName) : base(firstName, lastName)
        {
            this.NumReports = 0;
            this.NumMentions = 1;
            this.Type = "target";
        }

        public void CreateTarget()
        {
            this.Target = new Person(this.FirstName, this.LastName, this.NumReports, this.NumMentions, this.SecretCode, this.Type);
            InsertNewPerson(this.Target);
        }

        public void UpdateMentionTarget()
        {
            UpdateMentionCount(peopleList[0].Id);
        }

        public void UpdateTypeTarget()
        {
            if (peopleList[0].NumReports > 0)
            {
                this.Type = "both";
                UpdateType(peopleList[0].Id, this.Type);
            }
        }

        public int GetNumMention()
        {
            return peopleList.Count();
        }

        public bool IsTheTargetDangerous()
        {
            if (this.ReportsSelected.GetMinuteDifference() <= 15 && GetNumMention() >= 3)
            {
                this.IsDangerous = true;
                return this.IsDangerous;
            }
            this.IsDangerous = false;
            return this.IsDangerous;
        }

        public override void RunManageSystem()
        {
            if (IsExsist())
            {
                UpdateMentionTarget();
                UpdateTypeTarget();
                IsTheTargetDangerous();
            }
            else
            {
                CreateTarget();
            }
        }
    }
}
