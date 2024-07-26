
using System.Data;
using System.Drawing;


namespace SalesProject.Classes
{
    class VariablesClass
    {
        public static int userId, updateInvoiceId;
        public static string userName, userPassword, userJob, phoneNum;
        public static Point pos;
        public static bool backupProcess;
        public static bool sw;
        public static bool mainActive;
        public static int Save = -1;
        public static DataTable dtUserPermissions = new DataTable();
    }
}
