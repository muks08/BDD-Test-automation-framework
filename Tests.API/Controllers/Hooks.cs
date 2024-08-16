using Core.Config;
using Core.Utils;
using NUnit.Framework;

namespace Tests.API.Controllers
{
    [SetUpFixture]
    public class Hooks
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            EnvironmentPropertiesHelper.CreateAllureEnvironmentFile();
            AllureReportGenerator.CreateBatchFiles();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() { }
    }
}
