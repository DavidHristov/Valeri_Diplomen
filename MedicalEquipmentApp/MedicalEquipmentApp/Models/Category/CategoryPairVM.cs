﻿using System.ComponentModel.DataAnnotations;

namespace MedicalEquipmentApp.Models.Category
{
    public class CategoryPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; } = null!;
    }
}