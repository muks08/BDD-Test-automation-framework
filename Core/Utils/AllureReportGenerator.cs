using Core.Configuration;

namespace Core.Utils
{
    public static class AllureReportGenerator
    {
        public static void CreateBatchFiles()
        {
            string env = ConfigManager.AppSettings.Environment;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string apiPath = Path.GetFullPath(Path.Combine(basePath, @$"..\..\..\..\Tests.API\bin\{env}\net6.0\allure-results"));
            string uiPath = Path.GetFullPath(Path.Combine(basePath, @$"..\..\..\..\Tests.UI\bin\{env}\net6.0\allure-results"));
            string generateBatPath = Path.Combine(basePath, @"generate_allure_report.bat");
            string cleanBatPath = Path.Combine(basePath, @"clean_allure_report.bat");
            string resultsDirPath = Path.Combine(basePath, @"all-tests-allure-results\");
            string allureReportPath = Path.Combine(basePath, @"allure-report\");
            string screenshotsPath = Path.Combine(basePath, @"screenshots\");

            if (!Directory.Exists(resultsDirPath))
            {
                Directory.CreateDirectory(resultsDirPath);
            }

            string generateReportBatchContent =
                $@"@echo off
rmdir /s /q ""{allureReportPath}""
xcopy /s /e /y ""{apiPath}\*"" ""{resultsDirPath}""
xcopy /s /e /y ""{uiPath}\*"" ""{resultsDirPath}""
echo Generating Allure report...
allure generate --single-file all-tests-allure-results
pause
                ";

            File.WriteAllText(generateBatPath, generateReportBatchContent);
            Console.WriteLine($"Batch file created at: {generateBatPath}");

            string cleanReportBatchContent =
                $@"@echo off
rmdir /s /q ""{allureReportPath}""
rmdir /s /q ""{apiPath}""
rmdir /s /q ""{uiPath}""
rmdir /s /q ""{resultsDirPath}""
rmdir /s /q ""{screenshotsPath}""
pause
                ";

            File.WriteAllText(cleanBatPath, cleanReportBatchContent);
            Console.WriteLine($"Batch file created at: {cleanBatPath}");
        }
    }
}
