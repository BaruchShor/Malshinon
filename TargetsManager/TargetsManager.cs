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
        public string ManyReportsReason { get; set; }
        public string ALotInShortTimeReason { get; set; }
        public Person Target { get; set; }
        public RealThreatsManager RealThreats { get; set; }

        public TargetsManager(string firstName, string lastName) : base(firstName, lastName)
        {
            this.NumReports = 0;
            this.NumMentions = 1;
            this.Type = "target";
            this.ManyReportsReason = "";
            this.ALotInShortTimeReason = "";
            this.RealThreats = new RealThreatsManager();
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

        public void GetTargetStats() { }

        public bool IsTheTargetDangerous()
        {
            if (this.ReportsSelected.GetMinuteDifference() <= 15 && GetNumMention() >= 3)
            {
                this.RealThreats.CreateReport(this.Target.Id, this.ManyReportsReason);
                return this.IsDangerous = true;
            }else if (this.peopleList[0].NumMentions == 20)
            {
                this.RealThreats.CreateReport(this.Target.Id, this.ALotInShortTimeReason);
                return this.IsDangerous = true;
            }
            return this.IsDangerous = false;
        }

        public override void RunManageLocalSystem()
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
