using System.IO;
using TGS.Model;

namespace TGS.Controllers.Main {
    class LoadConfigsController {
        public void Load() {
            string configs = File.ReadAllText(@"./Configs/configs.txt");
            Configs.DBRoute = configs.Substring(configs.IndexOf("<DB_ROUTE>") + 10, configs.IndexOf("</DB_ROUTE>") - configs.IndexOf("<DB_ROUTE>") - 10);


            string reportsListConfig = configs.Substring(configs.IndexOf("<REPORTS_LIST>") + 14, configs.IndexOf("</REPORTS_LIST>") - configs.IndexOf("<REPORTS_LIST>") - 14);
            string[] reportsList = reportsListConfig.Split(',');
            int[] reportsListConverted = new int[reportsList.Length];

            for (int i = 0; i < reportsList.Length; i++) {
                reportsListConverted[i] = int.Parse(reportsList[i]);
            }

            Configs.ReportsList = reportsListConverted;
        }
    }
}
