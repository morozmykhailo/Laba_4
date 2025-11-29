using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4.Classes_Laba4
{
    public class FoodCalculator
    {
        // Середня калорійність для фруктів
        public double CalculateAverageCaloriesForFruits(List<FoodProduct> products)
        {
            var fruits = products.OfType<Fruit>().ToList();

            if (!fruits.Any())
                return 0;

            return fruits.Average(f => f.GetCalories());
        }

        // Середня калорійність для овочів
        public double CalculateAverageCaloriesForVegetables(List<FoodProduct> products)
        {
            var vegetables = products.OfType<Vegetable>().ToList();

            if (!vegetables.Any())
                return 0;

            return vegetables.Average(v => v.GetCalories());
        }
    }
}
