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
using boring.bank.datasource;


namespace LinqShow
{
    /// <summary>
    /// Interaction logic for ClientDetails.xaml
    /// </summary>
    public partial class TransactionDetails : UserControl
    {
        private DataRepository repo = DataRepository.Instance;

        public TransactionDetails()
        {
            InitializeComponent();
        }

 
    }
}
