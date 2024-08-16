using Core.Configuration;

namespace Core.Utils
{
    public static class AllureReportGenerator
    {
        public static void CreateBatchFile()
        {
            string env = ConfigManager.AppSettings.Environment;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string apiPath = Path.GetFullPath(Path.Combine(basePath, @$"..\..\..\..\Tests.API\bin\{env}\net6.0\allure-results"));
            string uiPath = Path.GetFullPath(Path.Combine(basePath, @$"..\..\..\..\Tests.UI\bin\{env}\net6.0\allure-results"));
            string batPath = Path.Combine(basePath, @"generate_allure_report.bat");
            string resultsDirPath = Path.Combine(basePath, @"results\");
            string allureReportPath = Path.Combine(basePath, @"allure-report\");

            if (!Directory.Exists(resultsDirPath))
            {
                Directory.CreateDirectory(resultsDirPath);
            }

            string batchContent =
                $@"@echo off
                rmdir /s /q ""{allureReportPath}""
                xcopy /s /e /y ""{apiPath}\*"" ""{resultsDirPath}""
                xcopy /s /e /y ""{uiPath}\*"" ""{resultsDirPath}""
                echo Generating Allure report...
                allure generate --single-file results
                pause
                ";

            File.WriteAllText(batPath, batchContent);
            Console.WriteLine($"Batch file created at: {batPath}");
        }
    }
}
