using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class AddingReports : ReportsDAL
    {
        public MalshinimManager Malshin { get; set; }
        public TargetsManager Target { get; set; }
        public IntelReport NewReport { get; set; }
        public string MalshinInput { get; set; }

        public Dictionary<string, string> ReportData = new Dictionary<string, string>();
        public string[] TempData { get; set; }

        public List<string> MalshinData = new List<string>();
        public string PromptFullNameOfMalshin { get; set; }
        public string PromptFullNameOfTarget { get; set; }
        public string PromptFullReport { get; set; }
        public string MalshinFirstNameKey { get; set; }
        public string MalshinLastNameKey { get; set; }
        public string TargetFirstNameKey { get; set; }
        public string TargetLastNameKey { get; set; }
        public string TextKey { get; set; }
        public string[] SystemMesseges { get; set; }
        public string[] DataDictKeywords { get; set; }

        public AddingReports()
        {
            this.PromptFullNameOfMalshin = "Please enter full Malshin name.";
            this.PromptFullNameOfTarget = "Please enter a full target name.";
            this.PromptFullReport = "Please enter the full report.";
            this.MalshinFirstNameKey = "MalshinFirstName";
            this.MalshinLastNameKey = "MalshinLastName";
            this.TargetFirstNameKey = "TargetFirstName";
            this.TargetLastNameKey = "TargetLastName";
            this.TextKey = "Text";
            this.SystemMesseges = new string[] { this.PromptFullNameOfMalshin, this.PromptFullNameOfTarget, this.PromptFullReport };
            this.DataDictKeywords = new string[] { this.MalshinFirstNameKey, this.MalshinLastNameKey, this.TargetFirstNameKey, this.TargetLastNameKey, this.TextKey };
        }

        private List<string> GetDataFromMalshin()
        {
            try
            {
                for (int i = 0; i < this.SystemMesseges.Length; i++)
                {
                    Console.WriteLine($":::::::::::::::::::::::::::::::::::::::::\n" +
                      $"      {this.SystemMesseges[i]}.      \n" +
                      $":::::::::::::::::::::::::::::::::::::::::");
                    this.MalshinInput = Console.ReadLine();
                    if(i != this.SystemMesseges.Length - 1)
                    {
                        this.TempData = this.MalshinInput.Split(' ');
                        if(this.TempData.Length != 2)
                        {
                            i--;
                            Console.WriteLine($"!=== Full name must contain one first name and one last name. ===!");
                            continue;
                        }
                        foreach (string data in TempData)
                        {
                            this.MalshinData.Add(data);
                        }
                    }
                    else
                    {
                        this.MalshinData.Add(this.MalshinInput);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error! : {ex.GetType()} :::: {ex.Message}");
            }

            return this.MalshinData;
        }

        public Dictionary<string,string> MalshinDataOrganizer()
        {
            try
            {
                for(int i = 0; i < this.DataDictKeywords.Length; i++)
                {
                    this.ReportData.Add(this.DataDictKeywords[i], this.MalshinData[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! : { ex.GetType()} :::: { ex.Message}");
            }
            return this.ReportData;
        }

        public void CreateReport()
        {
            this.NewReport = new IntelReport(Malshin.GetIdFromPersonBySecretCode(), Target.GetIdFromPersonBySecretCode(), this.ReportData["Text"]);
            InsertIntelReport(NewReport);
        }

        public void DisplaySystem()
        {
            GetDataFromMalshin();
            MalshinDataOrganizer();
            this.Malshin = new MalshinimManager(this.ReportData["MalshinFirstName"], this.ReportData["MalshinLastName"]);
            this.Malshin.RunManageSystem();
            this.Target = new TargetsManager(this.ReportData["TargetFirstName"], this.ReportData["TargetLastName"]);
            this.Target.RunManageSystem();
            CreateReport();
        }
    }
}
