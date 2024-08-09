using Bogus;

namespace Core.Utils
{
    public class DataGenerator
    {
        private static readonly Faker Faker = new(locale: "en_US");
        private static Randomizer Randomizer => new();

        public static class PersonalInfo
        {
            public static string GenerateEmail(string? firstName = null, string? lastName = null, string? provider = null, string? uniqueSuffix = null)
            {
                return Faker.Internet.Email(firstName, lastName, provider, uniqueSuffix);
            }

            public static string GenerateUserName(string? firstName = null, string? lastName = null)
            {
                return Faker.Internet.UserName(firstName, lastName);
            }

            public static string GeneratePassword(int length = 10)
            {
                return Faker.Internet.Password(length, regexPattern: "[\\x20-\\x26\\x28-\\x7E]");
            }

            public static string GenerateFirstName()
            {
                return Faker.Name.FirstName();
            }

            public static string GenerateLastName()
            {
                return Faker.Name.LastName();
            }

            public static string GeneratePhoneNumber(bool useFormatting = false)
            {
                return useFormatting ? Faker.Phone.PhoneNumber("(###) ###-####") : Faker.Phone.PhoneNumber("##########");
            }
        }

        public static class AddressInfo
        {
            public static string GenerateCity()
            {
                return Faker.Address.City();
            }

            public static string GenerateZipCode()
            {
                return Faker.Address.ZipCode("#####");
            }

            public static string GenerateState(bool useAbbreviature = false)
            {
                return useAbbreviature ? Faker.Address.StateAbbr() : Faker.Address.State();
            }

            public static string GenerateStreet()
            {
                return Faker.Address.StreetAddress();
            }

            public static string GenerateSecondaryAddress()
            {
                return Faker.Address.SecondaryAddress();
            }
        }

        public static class CompanyInfo
        {
            public static string GenerateCompanyName()
            {
                return Faker.Company.CompanyName();
            }
        }

        public static class TextInfo
        {
            public static string GenerateWord()
            {
                return Faker.Random.Word();
            }

            public static string GenerateSentence(int wordCount = 3)
            {
                return Faker.Lorem.Sentence(wordCount: wordCount);
            }
        }

        public static class NumericInfo
        {
            public static int GenerateRandomInteger(int maxValue, int minValue = 0)
            {
                return Randomizer.Int(minValue, maxValue);
            }

            public static string GenerateRandomNumericString(int length)
            {
                return string.Join("", Randomizer.Digits(length));
            }
        }
    }
}
