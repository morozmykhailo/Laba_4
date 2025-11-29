using Laba_4.Classes_Laba4;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        // Колекція продуктів для відображення в інтерфейсі
        private readonly ObservableCollection<FoodProduct> _products;

        public MainWindow()
        {
            InitializeComponent();

            // Ініціалізація колекції продуктів
            _products = new ObservableCollection<FoodProduct>();

            // Прив'язка списку до елементу ListBox
            ProductsListBox.ItemsSource = _products;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Отримання типу продукту з комбобоксу
                var selectedTypeItem = ProductTypeComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem;
                var selectedType = selectedTypeItem?.Content?.ToString();

                // Перевірка на заповненість назви
                if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                {
                    MessageBox.Show("Необхідно вказати назву продукту.");
                    return;
                }

                // Спроба перетворення калорій в числовий формат
                if (!double.TryParse(CaloriesTextBox.Text, out double calories))
                {
                    MessageBox.Show("Некоректне значення калорій. Потрібно ввести число.");
                    return;
                }

                // Отримання дати придатності
                var expiration = ExpirationDatePicker.SelectedDate ?? DateTime.Now;

                // Отримання додаткового поля
                var extra = ExtraFieldTextBox.Text;

                FoodProduct product;

                // Створення відповідного об'єкта в залежності від типу
                if (selectedType == "Fruit")
                {
                    product = new Fruit(NameTextBox.Text, calories, expiration, extra);
                }
                else
                {
                    product = new Vegetable(NameTextBox.Text, calories, expiration, extra);
                }

                // Додавання продукту в колекцію
                _products.Add(product);

                // Оновлення відображення елементів у списку
                UpdateProductsListBoxItems();

                // Очищення полів введення після додавання
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при додаванні продукту: {ex.Message}");
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var calculator = new FoodCalculator();

                // Перетворення колекції ObservableCollection у звичайний список
                var list = _products.ToList();

                // Обчислення середньої калорійності для фруктів
                double avgFruits = calculator.CalculateAverageCaloriesForFruits(list);

                // Обчислення середньої калорійності для овочів
                double avgVegetables = calculator.CalculateAverageCaloriesForVegetables(list);

                // Виведення результатів на форму
                AvgFruitsTextBlock.Text = avgFruits.ToString("F2");
                AvgVegetablesTextBlock.Text = avgVegetables.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при обчисленнях: {ex.Message}");
            }
        }

        private void ClearInputFields()
        {
            NameTextBox.Clear();
            CaloriesTextBox.Clear();
            ExtraFieldTextBox.Clear();
            ExpirationDatePicker.SelectedDate = DateTime.Now;
        }

        private void UpdateProductsListBoxItems()
        {
            // Оновлення представлення елементів у списку на основі інформації про продукт
            ProductsListBox.Items.Refresh();

            // Встановлення власного тексту відображення через перетворення в рядок
            ProductsListBox.DisplayMemberPath = null;
        }
    }
}