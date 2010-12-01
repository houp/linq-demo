using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace boring.bank.datasource
{

    public class ClientList : List<Client>
    {
        public new Client Add(Client c) {
            if (Contains(c)) return c;
 
            if (c.Id == null)
            {
                c.Id = this.Max(client => client.Id) + 1;
            }

            base.Add(c);
            return c;
        }
    }

    public class TransactionList : List<Transaction>
    {
        public new Transaction Add(Transaction t)
        {
            if (Contains(t)) return t;

            if (t.Id == null)
            {
                t.Id = this.Max(trns => trns.Id) + 1;
            }

            base.Add(t);
            return t;
        }
    }

    
    /// <summary>
    /// Class holding references to all my entites.
    /// </summary>
    public class DataContext
    {
        public ClientList Clients { get; private set; }
        public TransactionList Transactions { get; private set; }

        public void SaveChanges()
        {
            // do nothing since we operate on memory only!
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// We put explicit values of test clients and transactions here.
        /// </summary>
        public DataContext()
        {
            Client c1 = new Client() { Id = 1, Name = "Jan Kowalski" };
            Client c2 = new Client() { Id = 2, Name = "Wincenty Nowak" };
            Client c3 = new Client() { Id = 3, Name = "Juliusz Nowobogacki" };

            c1.Beneficiaries = new List<Client>() { c2, c3 };
            c2.Beneficiaries = new List<Client>() { c3 };
            c3.Beneficiaries = new List<Client>() { c1 };

            Clients = new ClientList() { c1, c2, c3 };

            Transaction t1 = new Transaction() { Id = 1, Amount = 100, ValueDate = DateTime.Parse("2010-11-11"), Title = "Przelew testowy", CreditClient = c3, DebitClient = c1, Currency="PLN" };
            Transaction t2 = new Transaction() { Id = 2, Amount = 20, ValueDate = DateTime.Parse("2010-11-12"), Title = "Za obiad", CreditClient = c2, DebitClient = c3, Currency = "PLN" };
            Transaction t3 = new Transaction() { Id = 3, Amount = 600, ValueDate = DateTime.Parse("2010-11-15"), Title = "Faktura 4432432", CreditClient = c3, DebitClient = c1, Currency = "EUR" };
            Transaction t4 = new Transaction() { Id = 4, Amount = 50, ValueDate = DateTime.Parse("2010-11-17"), Title = "Oddaje", CreditClient = c2, DebitClient = c3, Currency = "PLN" };
            Transaction t5 = new Transaction() { Id = 5, Amount = 20, ValueDate = DateTime.Parse("2010-11-12"), Title = "Fa/43243/2/1020/2", CreditClient = c3, DebitClient = c1, Currency = "USD" };
            Transaction t6 = new Transaction() { Id = 6, Amount = 10, ValueDate = DateTime.Parse("2010-11-11"), Title = "Kieszonkowe", CreditClient = c1, DebitClient = c2, Currency = "EEK" };

            Transactions = new TransactionList() { t1, t2, t3, t4, t5, t6 };

            c1.Transactions = (from t in Transactions where t.DebitClient.Id == c1.Id select t).ToList<Transaction>();
            c2.Transactions = (from t in Transactions where t.DebitClient.Id == c2.Id select t).ToList<Transaction>();
            c3.Transactions = (from t in Transactions where t.DebitClient.Id == c3.Id select t).ToList<Transaction>();


        }

    }
}
