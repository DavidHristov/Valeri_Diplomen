using MedicalEquipmentApp.Core.Contracts;
using MedicalEquipmentApp.Models.Statistic;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentApp.Controllers
{
    public class StatisticController:Controller
    {
        private readonly IStatisticService statisticsService;
        public StatisticController(IStatisticService statisticService)
        {
            this.statisticsService = statisticService;
        }
        public IActionResult Index()
        {
            StatisticVM statistics = new StatisticVM();

            statistics.CountClients = statisticsService.CountClients();
            statistics.CountProducts = statisticsService.CountProducts();
            statistics.CountOrders = statisticsService.CountOrders();
            statistics.SumOrders = (int)statisticsService.SumOrders();

            return View(statistics);
        }
    }
}
