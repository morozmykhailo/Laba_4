using Laba_4.Classes_Laba4;

namespace Laba4_Tests
{
    [TestClass]
    public class FruitTests
    {
        [TestMethod]
        public void GetCalories_FruitAddsFivePercent()
        {
            // Перевірка на коректне збільшення калорійності фруктів на 5%.
            var fruit = new Fruit("Яблуко", 100, DateTime.Now.AddDays(5), "Україна");

            double calories = fruit.GetCalories();

            Assert.AreEqual(105, calories, 0.0001);
        }

        [TestMethod]
        public void CheckAllergy_ReturnsTrueForCitrusAllergenAndOrange()
        {
            // Перевірка того, що при алергії на цитрусові апельсин визначається як алерген.
            var orange = new Fruit("Апельсин", 80, DateTime.Now.AddDays(3), "Іспанія");

            bool hasAllergy = orange.CheckAllergy("цитрус");

            Assert.IsTrue(hasAllergy);
        }

        [TestMethod]
        public void GetNutritionInfo_ContainsNameAndCountry()
        {
            // Перевірка того, що опис фрукту містить назву продукту та країну походження.
            var mango = new Fruit("Манго", 90, DateTime.Now.AddDays(4), "Бразилія");

            string info = mango.GetNutritionInfo();

            Assert.IsTrue(info.Contains("Манго"));
            Assert.IsTrue(info.Contains("Бразилія"));
        }
    }

    [TestClass]
    public class VegetableTests
    {
        [TestMethod]
        public void GetCalories_VegetableReturnsBaseCalories()
        {
            // Перевірка на повернення базової калорійності овочів без модифікацій.
            var tomato = new Vegetable("Помідор", 20, DateTime.Now.AddDays(7), "Тепличний");

            double calories = tomato.GetCalories();

            Assert.AreEqual(20, calories, 0.0001);
        }

        [TestMethod]
        public void GetVitaminContent_ReturnsNonEmptyString()
        {
            // Перевірка того, що метод повертає непорожній рядок з інформацією про вітамінний склад.
            var carrot = new Vegetable("Морква", 30, DateTime.Now.AddDays(10), "Органічний");

            string vitamins = carrot.GetVitaminContent();

            Assert.IsFalse(string.IsNullOrWhiteSpace(vitamins));
        }

        [TestMethod]
        public void GetNutritionInfo_ContainsNameAndCultivationMethod()
        {
            // Перевірка того, що опис овочу містить назву та спосіб вирощування.
            var cucumber = new Vegetable("Огірок", 15, DateTime.Now.AddDays(6), "Поливний");

            string info = cucumber.GetNutritionInfo();

            Assert.IsTrue(info.Contains("Огірок"));
            Assert.IsTrue(info.Contains("Поливний"));
        }
    }

    [TestClass]
    public class FoodCalculatorTests
    {
        [TestMethod]
        public void CalculateAverageCaloriesForFruits_UsesOnlyFruits()
        {
            // Перевірка того, що при обчисленні середньої калорійності фруктів
            // використовуються лише об'єкти типу Fruit.
            var products = new List<FoodProduct>
            {
                new Fruit("Яблуко", 100, DateTime.Now.AddDays(5), "Україна"),
                new Fruit("Груша", 80, DateTime.Now.AddDays(4), "Україна"),
                new Vegetable("Помідор", 20, DateTime.Now.AddDays(7), "Тепличний")
            };

            var calculator = new FoodCalculator();

            double avgCalories = calculator.CalculateAverageCaloriesForFruits(products);

            Assert.AreEqual((100 * 1.05 + 80 * 1.05) / 2, avgCalories, 0.0001);
        }

        [TestMethod]
        public void CalculateAverageCaloriesForVegetables_UsesOnlyVegetables()
        {
            // Перевірка того, що при обчисленні середньої калорійності овочів
            // враховуються тільки об'єкти Vegetable.
            var products = new List<FoodProduct>
            {
                new Fruit("Яблуко", 100, DateTime.Now.AddDays(5), "Україна"),
                new Vegetable("Помідор", 20, DateTime.Now.AddDays(7), "Тепличний"),
                new Vegetable("Морква", 30, DateTime.Now.AddDays(10), "Органічний")
            };

            var calculator = new FoodCalculator();

            double avgCalories = calculator.CalculateAverageCaloriesForVegetables(products);

            Assert.AreEqual(25, avgCalories, 0.0001);
        }

        [TestMethod]
        public void CalculateAverageCaloriesForFruits_NoFruits_ReturnsZero()
        {
            // Перевірка на повернення нульового значення при відсутності фруктів.
            var products = new List<FoodProduct>
            {
                new Vegetable("Помідор", 20, DateTime.Now.AddDays(7), "Тепличний")
            };

            var calculator = new FoodCalculator();

            double avgCalories = calculator.CalculateAverageCaloriesForFruits(products);

            Assert.AreEqual(0, avgCalories, 0.0001);
        }

        [TestMethod]
        public void CalculateAverageCaloriesForVegetables_NoVegetables_ReturnsZero()
        {
            // Перевірка на повернення нульового значення при відсутності овочів.
            var products = new List<FoodProduct>
            {
                new Fruit("Яблуко", 100, DateTime.Now.AddDays(5), "Україна")
            };

            var calculator = new FoodCalculator();

            double avgCalories = calculator.CalculateAverageCaloriesForVegetables(products);

            Assert.AreEqual(0, avgCalories, 0.0001);
        }
    }
}
