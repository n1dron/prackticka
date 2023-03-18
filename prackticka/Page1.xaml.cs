using prackticka.DataSet1TableAdapters;
using System;
using System.Windows;
using System.Windows.Controls;

namespace prackticka
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        BuyersTableAdapter buy = new BuyersTableAdapter();
        public Page1()
        {
            InitializeComponent();
            BuyersGrid.ItemsSource = buy.GetData();
            BuyersCombobox.ItemsSource = buy.GetData();
            BuyersCombobox.DisplayMemberPath = "Name";
            BuyersCombobox.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)BuyersCombobox.SelectedValue;
            short Library = Convert.ToInt16(Library_visits.Text);
            short Book = Convert.ToInt16(Library_visits.Text);
            buy.InsertQueryy(NameTbx.Text,Library,Book, id);
            BuyersGrid.ItemsSource = buy.GetData();
        }
    }
}
