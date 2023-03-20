using prackticka.DataSet1TableAdapters;
using System;
using System.Data;
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
            short Book = Convert.ToInt16(AllBooks_buy.Text);
            buy.InsertQueryy(NameTbx.Text,Library,Book, id);
            BuyersGrid.ItemsSource = buy.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(BuyersGrid.SelectedItem as DataRowView).Row[0];
            buy.DeleteQueryy(id);
            BuyersGrid.ItemsSource= buy.GetData();
        }
        private void BuyersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuyersGrid.SelectedItem != null)
            {
                var item = BuyersGrid.SelectedItem as DataRowView;
                NameTbx.Text = (string)item.Row[1];
                BuyersCombobox.SelectedValue = (Convert.ToInt16(item.Row[2]));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (BuyersGrid.SelectedItem != null)
            {
                short Library = Convert.ToInt16(Library_visits.Text);
                short Book = Convert.ToInt16(AllBooks_buy.Text);
                var item = BuyersGrid.SelectedItem as DataRowView;
                buy.UpdateQuery(NameTbx.Text,Library,Book,(int) BuyersCombobox.SelectedValue, (int)item.Row[0]);
                BuyersGrid.ItemsSource = buy.GetData();
            }
        }
    }
}
