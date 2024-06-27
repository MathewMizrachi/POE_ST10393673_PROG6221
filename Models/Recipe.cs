using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_ST10393673_PROG6221.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Instructions { get; set; }

        public Recipe(string name, List<Ingredient> ingredients, List<string> instructions)
        {
        }

        public Recipe(string name, List<Ingredient> ingredients, List<string> instructions)
        {
            Name = name;
            Ingredients = ingredients;
            Instructions = instructions;
        }

        public void ScaleRecipe(double scalingFactor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= scalingFactor;
                ingredient.Calories = (int)(ingredient.Calories * scalingFactor);
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
                ingredient.Calories = ingredient.OriginalCalories;
            }
        }

        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }
}
