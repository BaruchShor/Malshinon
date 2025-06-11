using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal abstract class PeopleManager : PersonDAL
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SicretCode { get; set; }
        public int NumReports { get; set; }
        public int NumMentions { get; set; }
        public string SecretCode { get; set; }
        public string Type { get; set; }

        public ReportsManager ReportsSelected = new ReportsManager();


        public PeopleManager(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SecretCode = CreateSecretCode();
            GetPersonByFullName(this.FirstName, this.LastName);
            this.ReportsSelected.GetReportsByTargetId(peopleList[0].Id);
        }

        public bool IsExsist()
        {
            if (this.peopleList.Count() == 1)
            {
                return true;
            }
            return false;
        }

        public string CreateSecretCode()
        {
            Random random = new Random();
            int randomNum = 0;
            do
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        randomNum = random.Next(65, 90);
                        this.SicretCode += (char)randomNum;
                    }
                    else
                    {
                        randomNum = random.Next(97, 122);
                        this.SicretCode += (char)randomNum;
                    }
                }
                GetPersonBySecretCode(this.SicretCode);
            } while (peopleList.Count() != 0);
            return this.SicretCode;
        }

        public int GetIdFromPersonBySecretCode()
        {
            GetPersonBySecretCode(this.SecretCode);
            return this.peopleList[0].Id;
        }

        public void ShowPeopleList()
        {
            foreach (Person person in this.peopleList)
            {
                person.ShowPerson();
            }
        }

        public abstract void RunManageSystem();

    } 
}
