using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_ST10393673_PROG6221.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public double OriginalQuantity { get; }
        public int OriginalCalories { get; }

        public Ingredient()
        {
            // Default constructor
        }

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;

            OriginalQuantity = quantity;
            OriginalCalories = calories;
        }
    }
}
