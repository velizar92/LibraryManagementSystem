using System.Configuration;

namespace LibraryManagementSystem.UI
{
    public static class ConnectionStrings
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
    }
}
