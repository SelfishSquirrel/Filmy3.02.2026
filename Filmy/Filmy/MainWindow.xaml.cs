using System;
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
using Microsoft.VisualBasic;

namespace Filmy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _addedCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string input = Interaction.InputBox("Podaj nazwę filmu:", "Dodaj film", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                MovieListBox.Items.Add(input);
                _addedCount++;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MovieListBox.SelectedItem != null)
            {
                MovieListBox.Items.Remove(MovieListBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Wybierz element do usunięcia.", "Usun", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string filter = Interaction.InputBox("Filtruj listę (puste = usuń filtr):", "Filtr", "");
            var view = CollectionViewSource.GetDefaultView(MovieListBox.Items);
            if (string.IsNullOrWhiteSpace(filter))
            {
                view.Filter = null;
            }
            else
            {
                view.Filter = o => (o?.ToString() ?? "").IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }
    }
}