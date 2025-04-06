using CafePOS.Core.Enums;
using CafePOS.Core.Interfaces.Application;
using Microsoft.Extensions.Configuration;

namespace CafePOS.PL
{
    public class AppConfiguration : IAppConfiguration
    {
        private IConfiguration _configuration;

        public AppConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .AddUserSecrets<Program>()
                .Build();
        }

        public string GetConnectionString()
        {
            return _configuration["CafeDb"] ?? "";
        }

        public TimeOfDayMode GetTimeOfDayMode()
        {
            switch (_configuration["TimeOfDayMode"])
            {
                case "Breakfast":
                    return TimeOfDayMode.Breakfast;
                case "Lunch":
                    return TimeOfDayMode.Lunch;
                case "HappyHour":
                    return TimeOfDayMode.HappyHour;
                case "Dinner":
                    return TimeOfDayMode.Dinner;
                case "Seasonal":
                    return TimeOfDayMode.Seasonal;
                case "RealTime":
                    return TimeOfDayMode.RealTime;
                case "":
                    throw new Exception("TimeOfDayMode configuration key is missing.");
                default:
                    throw new Exception("TimeOfDayMode configuration is invalid.");
            }
        }

        public TrainingMode GetTrainingMode()
        {
            switch (_configuration["TrainingMode"])
            {
                case "Activated":
                    return TrainingMode.Activated;
                case "Deactivated":
                    return TrainingMode.Deactivated;
                case "":
                    throw new Exception("TrainingMode configuration key is missing.");
                default:
                    throw new Exception("TrainingMode configuration is invalid.");
            }
        }
    }
}