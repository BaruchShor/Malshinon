using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class AddingReports
    {
        public MalshinimManager Malshin { get; set; }
        public TargetsManager Target { get; set; }
        public IntelReport NewReport { get; set; }
        public string MalshinInput { get; set; }

        public Dictionary<string, string> ReportData = new Dictionary<string, string>();
        public string[] TempData { get; set; }

        public List<string> MalshinData = new List<string>();

        public string[] SystemMesseges = { "Please enter full Malshin name.", "Please enter a full target name.", "Please enter the full report." };

        public string[] Keywords = { "MalshinFirstName", "MalshinLastName", "TargetFirstName", "TargetlastName", "Text" };

        public AddingReports()
        {
        }

        private List<string> GetDataFromMalshin()
        {
            try
            {
                for (int i = 0; i < this.SystemMesseges.Length; i++)
                {
                    Console.WriteLine($":::::::::::::::::::::::::::::::::::::::::\n" +
                      $"::::: {this.SystemMesseges[i]}. :::::\n" +
                      $":::::::::::::::::::::::::::::::::::::::::");
                    this.MalshinInput = Console.ReadLine();
                    if(i != this.SystemMesseges.Length - 1)
                    {
                        this.TempData = this.MalshinInput.Split(' ');
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
                Console.WriteLine($"Error! : {ex.GetType()} 1:::: {ex.Message}");
            }

            return this.MalshinData;
        }

        public Dictionary<string,string> MalshinDataOrganizer()
        {
            try
            {
                for(int i = 0; i < this.Keywords.Length; i++)
                {
                    this.ReportData.Add(this.Keywords[i], this.MalshinData[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! : { ex.GetType()} 2:::: { ex.Message}");
            }
            return this.ReportData;
        }

        public IntelReport CreateReport()
        {
            this.NewReport = new IntelReport(Malshin.GetIdFromPersonBySecretCode(), Target.GetIdFromPersonBySecretCode(), this.ReportData["Text"]);
            return this.NewReport;
        }

        public void DisplaySystem()
        {
            GetDataFromMalshin();
            MalshinDataOrganizer();
            Malshin = new MalshinimManager(this.ReportData["MalshinFirstName"], this.ReportData["MalshinLastName"]);
            this.Malshin.RunManageSystem();
            Target = new TargetsManager(this.ReportData["TargetFirstName"], this.ReportData["TargetLastName"]);
            this.Target.RunManageSystem();
            CreateReport();
        }
    }
}
