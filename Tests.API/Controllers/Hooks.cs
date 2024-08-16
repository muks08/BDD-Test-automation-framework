using Core.Config;
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
        }
    }
}
