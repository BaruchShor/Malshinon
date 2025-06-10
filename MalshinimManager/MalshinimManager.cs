using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class MalshinimManager : PersonDAL
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SicretCode { get; set; }
        public Person Malshin { get; set; }
        public Person Target { get; set; }

        public MalshinimManager(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            GetPersonByName(this.FirstName);
        }

        public bool IsExsist()
        {
            if (this.peopleList.Count() == 1)
            {
                return true;
            }
            return false;
        }

        public void CreateMalshin()
        {
            this.Malshin = new Person(this.FirstName, this.LastName, 1, 0, CreateSecretCode(), "reporter");
            InsertNewPerson(this.Malshin);
        }

        public void CreateTarget()
        {
            this.Target = new Person(this.FirstName, this.LastName, 0, 1, CreateSecretCode(), "target");
            InsertNewPerson(this.Target);
        }

        public void UpdateMalshin()
        {
            UpdateReportCount(peopleList[1].Id);
        }

        public void UpdateTarget()
        {
            UpdateMentionCount(peopleList[1].Id);
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

        public void ShowPeopleList()
        {
            foreach (Person person in this.peopleList)
            {
                person.ShowPerson();
            }
        }
    }
}
