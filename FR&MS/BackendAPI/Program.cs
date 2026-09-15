using BackendAPI.Utils;
using BackendAPI.Utils.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            SqlDBProfile dbProfile = new SqlDBProfile();
            //    "localhost",
            //    "demoFRMS",
            //    "sa",
            //    "12345"
            //);

            SqlDbService dbService = new SqlDbService();
            dbService.SetProfile(dbProfile);

            FRMS application = new(
                WebApplication.CreateBuilder(args),
                dbService
            );

            application.Run();

        }
    }
}
