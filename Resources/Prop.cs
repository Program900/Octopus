using System;
using Octopus.Data;
using System.Configuration;
using Ganss.Excel;
using System.IO;
using System.Reflection;

namespace Octopus.Resources
{
    static class Prop
    {
        
        private static string GetAssemblysOutputDirectory() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    
        private static string CreateFilePath(string outputDirectory)
           => Path.GetFullPath(Path.Combine(outputDirectory ?? throw new InvalidOperationException(), @"..\..\..\Octopus\Resources\Data.xlsx"));

        public static UserData GetUserType(String userType)
        {
            var outputDirectory = GetAssemblysOutputDirectory();
            var directoryDataFolder = CreateFilePath(outputDirectory);
            if (string.IsNullOrEmpty(directoryDataFolder))
            {
                directoryDataFolder = CreateFilePath(outputDirectory);
            }
            var userExcel = new ExcelMapper(directoryDataFolder).Fetch<UserData>("UserData");
            //  @"..\..\..\Octopus\Resources"
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
            var outputDirectory = GetAssemblysOutputDirectory();
            var directoryDataFolder = CreateFilePath(outputDirectory);

            if (string.IsNullOrEmpty(directoryDataFolder))
            {
                directoryDataFolder = CreateFilePath(outputDirectory);
            }           
            var userExcel = new ExcelMapper(directoryDataFolder).Fetch<SettingsData>("Settings");
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
