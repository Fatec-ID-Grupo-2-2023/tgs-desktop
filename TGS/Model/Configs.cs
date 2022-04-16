namespace TGS.Model {
    public class Configs {
        private static string dbRoute;
        private static int[] reportsList;

        public static string DBRoute {
            get { return dbRoute; }
            set { dbRoute = value; }
        }

        public static int[] ReportsList {
            get { return reportsList; }
            set { reportsList = value; }
        }
    }
}
