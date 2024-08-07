/*using Core.Configuration.Credentials;
using Core.Configuration.Database;
using Core.Utils;

namespace Core.Configuration
{
    public sealed class EnvSettings
    {
        private static readonly EnvSettings instance = new();

        private readonly JsonReader JsonReader = new();
        private readonly AppSettings appSettings;
        private readonly Credential credential;
        private readonly DBase database;
        private readonly SalesforceVersionSettings salesforceVersionSettings;

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static EnvSettings() { }
        private EnvSettings()
        {
            appSettings = JsonReader.GetFileContent<AppSettings>("Configuration/appConfig.json");
            salesforceVersionSettings = JsonReader.GetFileContent<SalesforceVersionSettings>("Configuration/salesforceVersion.json");
            credential = JsonReader.GetFileContentWithRootObjectName<Credential>("Configuration/Credentials/credential.json", appSettings.Environment);
            database = JsonReader.GetFileContentWithRootObjectName<DBase>("Configuration/Database/database.json", appSettings.Environment);
            appSettings.SalesforceServiceApi += salesforceVersionSettings.Version;
        }

        public static AppSettings AppSettings
        {
            get
            {
                return instance.appSettings;
            }
        }

        public static SalesforceVersionSettings SalesforceVersionSettings
        {
            get
            {
                return instance.salesforceVersionSettings;
            }
        }

        public static Credential Credential
        {
            get
            {
                return instance.credential;
            }
        }
        public static DBase Database
        {
            get
            {
                return instance.database;
            }
        }
    }
}
*/