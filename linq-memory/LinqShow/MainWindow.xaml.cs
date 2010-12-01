using System;
using System.Collections.Generic;
using System.Linq;
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
using boring.bank.dao;

namespace LinqShow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataRepository repo = DataRepository.Instance;

        public MainWindow()
        {
            InitializeComponent();
            lstClients.ItemsSource = repo.Clients;
            lstTransactions.ItemsSource = repo.Transactions;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstClients.ItemsSource = repo.getClientsByName(txtSearch.Text);
        }

        private void lstClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtlsClient.DataContext = lstClients.SelectedItem;
        }

        private void lstTransactions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtlsTrans.DataContext = lstTransactions.SelectedItem;
        }

        private void txtSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstTransactions.ItemsSource = repo.searchForTransactions(txtSearch2.Text);
        }

        private void refreshSearch(object sender, SelectionChangedEventArgs e)
        {
            if(datePickerFrom!= null && datePickerTo!=null && listBox1!=null)
            listBox1.ItemsSource = repo.getTransactionsBetweenDates(datePickerFrom.SelectedDate, datePickerTo.SelectedDate);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var summary = repo.getTransactionSummary();
            lstSummary.ItemsSource = summary;
        }

        


    }
}
