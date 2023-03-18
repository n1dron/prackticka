using prackticka.DataSet1TableAdapters;
using System;
using System.Data;
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
            short Price1 = Convert.ToInt16(Price.Text);
            book.InsertQuery(NameTbx.Text, Price1,Author.Text);
            BookGrid.ItemsSource = book.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            int id = (int)(BookGrid.SelectedItem as DataRowView).Row[0];
            book.DeleteQuery(id);
            BookGrid.ItemsSource = book.GetData();
            
        }
    }
}
