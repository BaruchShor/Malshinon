using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class MenuSystem : AddingReports
    {
        public PersonDAL Person { get; set; }
        public TargetsManager Targets { get; set; }
        public RealThreatsManager RealThreats { get; set; }
        public int UserCode { get; set; }
        public int ManageCode { get; set; }
        public string[] Choices { get; set; }
        public string Choice { get; set; }
        public int finalChoos { get; set; }
        public string Massege { get; set; }
        public int Id { get; set; }
        public MenuSystem(int userCode)
        {
            this.UserCode = userCode;
            this.ManageCode = 12345;
            this.Massege = $"\n!!!--- No data was found for this request. ---!!!\n";
            this.Choices = new string[] {"\nPress :: 1 :: To show list of targets",
                                           "Press :: 2 :: To Show list of dangerous targets",
                                           "Press :: 3 :: To Show list of malshinim",
                                           "Press :: 4 :: To Show list of potential malshinim",
                                           "Press :: 5 :: To Show malshin by ID number",
                                           "Press :: 6 :: To Show target by ID number",
                                           "Press :: 7 :: To show dangerous target by target ID",
                                           "Press :: 8 :: To Show list of reports",
                                           "Press :: 9 :: To Show list of reports by malshin ID",
                                           "Press :: 10 : To Show list of reports by target ID"
            };
            this.Person = new PersonDAL();
            this.RealThreats = new RealThreatsManager();
        }

        public void ManagerMenu()
        {
            foreach(string prompt in this.Choices)
            {
                Console.WriteLine(prompt);
            }
            GetChoiceFromManager();
            switch (this.finalChoos)
            {
                case 1:
                    this.Person.GetAllTargets();
                    showResoultsOfPeople();
                    break;
                case 2:
                    this.RealThreats.GetAllRealThreats();
                    showResoultsOfPeople();
                    break;
                case 3:
                    this.Person.GetAllMalshinim();
                    showResoultsOfPeople();
                    break;
                case 4:
                    this.Person.GetAllPotentialAgents();
                    showResoultsOfPeople();
                    break;
                case 5:
                    this.Person.GetMalshinById(GetId());
                    showResoultsOfPeople();
                    break;
                case 6:
                    this.Person.GetTargetById(GetId());
                    showResoultsOfPeople();
                    break;
                case 7:
                    this.RealThreats.GetRealThreatsByTargetId(GetId());
                    showResoultsOfRealThreats();
                    break;
                case 8:
                    GetAllReports();
                    showResoultsOfReports();
                    break;
                case 9:
                    GetReportsByMalshinId(GetId());
                    showResoultsOfReports();
                    break;
                case 10:
                    GetReportsByTargetId(GetId());
                    showResoultsOfReports();
                    break;
                default:
                    Console.WriteLine(this.Massege);
                    break;
            }
        }

        public void DisplayManageMenu()
        {
            do
            {
                ManagerMenu();
            } while (this.Choice != "exit");
        }

        public void showResoultsOfPeople()
        {
            if(this.Person.peopleList.Count() > 0)
            {
                foreach (Person person in this.Person.peopleList)
                {
                    person.ShowPerson();
                }
            }
            else
            {
                Console.WriteLine(this.Massege);
            }

        }

        public void showResoultsOfReports()
        {
            if(this.reportsList.Count > 0)
            {
                foreach (IntelReport report in this.reportsList)
                {
                    report.ShowReport();
                }
            }
            else
            {
                Console.WriteLine(this.Massege);
            }
        }

        public void showResoultsOfRealThreats()
        {
            if(this.RealThreats.realThreatsList.Count() > 0)
            {
                foreach (RealThreats realThreats in this.RealThreats.realThreatsList)
                {
                    realThreats.ShowRealThreats();
                }
            }
            else
            {
                Console.WriteLine("The list is empty");
            }

        }
        public int GetChoiceFromManager()
        {
            do
            {
                Console.WriteLine($"\n!--- Please enter a number from the list. ---!\n");
                this.Choice = Console.ReadLine();
                if (int.TryParse(this.Choice, out int resoult))
                {
                    this.finalChoos = Convert.ToInt32(this.Choice);
                }
                else if (this.Choice == "exit")
                {
                    this.finalChoos = 0;
                    break;
                }
            } while (this.finalChoos < 0 || this.finalChoos > this.Choices.Length);
            return this.finalChoos;
        }

        public int GetId()
        {
            int secsses = 0;
            do
            {
                Console.WriteLine($"\n!--- Please enter an ID number . ---!\n");
                this.Choice = Console.ReadLine();
                if (int.TryParse(this.Choice, out int resoult))
                {
                    this.Id = Convert.ToInt32(this.Choice);
                    secsses = 1;
                }
            } while (secsses == 0);
            return this.Id;
        }

        public void MalshinMenu()
        {
            DisplayAddReportSystem();
        }

        public void ControlMenu()
        {
            if(this.UserCode == this.ManageCode)
            {
                DisplayManageMenu();
            }
            else
            {
                MalshinMenu();
            }

        }
    }
}
