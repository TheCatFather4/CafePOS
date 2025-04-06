using CafePOS.Core.Enums;

namespace CafePOS.Core.Interfaces.Application
{
    public interface IAppConfiguration
    {
        string GetConnectionString();
        TimeOfDayMode GetTimeOfDayMode();
        TrainingMode GetTrainingMode();
    }
}