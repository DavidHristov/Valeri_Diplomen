﻿using System.ComponentModel.DataAnnotations;

namespace MedicalEquipmentApp.Models.Statistic
{
    public class StatisticVM
    {
        [Display(Name="Count Clients")]
        public int CountClients { get; set; }
        [Display(Name = "Count Products")]
        public int CountProducts { get; set; }
        [Display(Name = "Count Orders")]
        public int CountOrders { get; set; }
        [Display(Name = "Total Sum Orders")]
        public int SumOrders { get; set; }
    }
}
