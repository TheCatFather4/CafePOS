using CafePOS.BLL.Services;
using CafePOS.Core.Enums;
using CafePOS.Core.Interfaces.Application;
using CafePOS.Core.Interfaces.Services;
using CafePOS.Core.TimeOfDaySettings;
using CafePOS.DL.Repositories;
using CafePOS.DL.TrainingModeRepositories;

namespace CafePOS.BLL
{
    public class ServiceFactory
    {
        private IAppConfiguration _config;
        private ITimeOfDaySetting _timeOfDaySetting;
        private TrainingMode _trainingMode;

        public ServiceFactory(IAppConfiguration config)
        {
            _config = config;
            _timeOfDaySetting = GetTimeOfDay();
            _trainingMode = _config.GetTrainingMode();
        }

        public ITimeOfDaySetting GetTimeOfDay()
        {
            switch (_config.GetTimeOfDayMode())
            {
                case TimeOfDayMode.Breakfast:
                    return new Breakfast();
                case TimeOfDayMode.Lunch:
                    return new Lunch();
                case TimeOfDayMode.HappyHour:
                    return new HappyHour();
                case TimeOfDayMode.Dinner:
                    return new Dinner();
                case TimeOfDayMode.Seasonal:
                    return new Seasonal();
                default:
                    return new RealTime();
            }
        }

        public INewOrderService CreateNewOrderService()
        {
            if (_trainingMode != TrainingMode.Activated)
            {
                return new NewOrderService(
                new EFNewOrderRepository(_config.GetConnectionString()));
            }
            else
            {
                return new NewOrderService(new TMNewOrderRepository());
            }
            
        }

        public IOrderUpdateService CreateOrderUpdateService()
        {
            if (_trainingMode != TrainingMode.Activated)
            {
                return new OrderUpdateService(
                new EFOrderUpdateRepository(_config.GetConnectionString()), _timeOfDaySetting);
            }
            else
            {
                return new OrderUpdateService(
                    new TMOrderUpdateRepository(), _timeOfDaySetting);
            }
        }

        public ISalesReportService CreateSalesReportService()
        {
            if (_trainingMode != TrainingMode.Activated)
            {
                return new SalesReportService(
                new EFSalesReportRepository(_config.GetConnectionString()));
            }
            else
            {
                return new SalesReportService(new TMSalesReportRepository());
            }
            
        }
    }
}