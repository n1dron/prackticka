using prackticka.DataSet1TableAdapters;
using System;
using System.Windows;
using System.Windows.Controls;

namespace prackticka
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        Book1TableAdapter book = new Book1TableAdapter();
        public Page2()
        {
            InitializeComponent();
            BookGrid.ItemsSource = book.GetData();
            BooksCombobox.ItemsSource = book.GetData();
            BooksCombobox.DisplayMemberPath = "Name";
            BooksCombobox.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = (string)BooksCombobox.SelectedValue;
            short Price1 = Convert.ToInt16(Price.Text);
            book.InsertQuery(NameTbx.Text, Price1, id);
            BookGrid.ItemsSource = book.GetData();
        }

    }
}
