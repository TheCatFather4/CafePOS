using CafePOS.Core.Interfaces.Application;

namespace CafePOS.Core.TimeOfDaySettings
{
    public class Seasonal : ITimeOfDaySetting
    {
        public int GetTimeOfDaySetting()
        {
            return 5;
        }
    }
}