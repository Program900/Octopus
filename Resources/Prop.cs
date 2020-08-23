using System;
using Octopus.Data;
using System.Configuration;
using Ganss.Excel;

namespace Octopus.Resources
{
    static class Prop
    {

        public static UserData GetUserType(String userType)
        {
            var userExcel = new ExcelMapper(@"C:\Users\rache\source\repos\Octopus\Resources\Data.xls").Fetch<UserData>("UserData");
            var userExcelData = userExcel.GetEnumerator();
            while (userExcelData.MoveNext())
            {
                if (userExcelData.Current.UserType.Equals(ConfigurationManager.AppSettings["environment"] + userType))
                {
                    UserData current = userExcelData.Current;
                    Console.Write("Data " + ConfigurationManager.AppSettings["environment"] + userType);
                    return current;
                }

            }
            Console.Write("Error Data not found" + userType + " #######");

            return null;
        }


        public static SettingsData Settings(String property)
        {
            var userExcel = new ExcelMapper(@"C:\Users\rache\source\repos\Octopus\Resources\Data.xlsx").Fetch<SettingsData>("Settings");
            var userExcelData = userExcel.GetEnumerator();
            while (userExcelData.MoveNext())
            {
                if (userExcelData.Current.Property.Equals(ConfigurationManager.AppSettings["environment"] + property))
                {
                    SettingsData current = userExcelData.Current;
                    return current;

                }

            }
            Console.Write("Error Data not found for " + property + " #######");

            return null;
        }


    }
}
