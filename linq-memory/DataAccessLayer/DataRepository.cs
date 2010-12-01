using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using boring.bank.datasource;

namespace boring.bank.dao
{
    /// <summary>
    /// This class holds the data access logic - all queries live here. The goal of this demo is to
    /// show that we can change datasource implementations without making changes to this class.
    ///
    /// You can analyze queries defined here and try to translate them to SQL, XPath, XQuery or explicit
    /// native collection access code, to see what LINQ does for you. 
    /// </summary>
    public class DataRepository
    {
        // The Ugly Singleton Design Pattern :)
        private static DataRepository _me = new DataRepository();
        public static DataRepository Instance { get { return _me; } }

        private DataRepository() { }

        private DataContext context = new DataContext();

        public List<Client> Clients { get { return context.Clients.ToList<Client>(); } }

        public List<Transaction> Transactions { get { return context.Transactions.ToList<Transaction>(); } }

        public Client getClientById(int id)
        {
            return (from c in context.Clients where c.Id == id select c).FirstOrDefault<Client>();
        }

        public Transaction getTransactionById(int id)
        {
            return (from t in context.Transactions 
                        where t.Id == id select t).FirstOrDefault<Transaction>();
        }

        /// <summary>
        /// This method simply grabs all transactions done between given dates. Please note that in
        /// the LINQ query we use strict C# constructs to test the data - we call static method Compare
        /// from DateTime. You can use the debugger and/or database profiler to check if this method
        /// will be called in case of using Entity Framework backend. 
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns></returns>
        public List<Transaction> getTransactionsBetweenDates(DateTime? dateFrom, DateTime? dateTo)
        {
            return (from t in context.Transactions
                    where dateFrom != null ? DateTime.Compare(t.ValueDate, (DateTime)dateFrom) >= 0 : true
                    && dateTo != null ? DateTime.Compare(t.ValueDate, (DateTime)dateTo) <= 0 : true
                    select t).ToList<Transaction>();
        }

        /// <summary>
        /// This method looks for clients that have theirs name similar to given one. This test is done
        /// simply by utilizing stanadard Contains method from the String class. You can verify if this 
        /// method gets called when we use Entity Framework data backend.  
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public List<Client> getClientsByName(string name)
        {
            return (from c in context.Clients
                    where c.Name.ToLower().Contains(name.ToLower()) 
                    select c).ToList<Client>();
        }


        /// <summary>
        /// Searches for transactions containing given text in title or in debit/credit client name.
        /// The search is not case sensitive.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public List<Transaction> searchForTransactions(string text)
        {
            text = text.ToLower();
            return (from t in context.Transactions
                    where t.Title.ToLower().Contains(text)
                        || t.DebitClient.Name.ToLower().Contains(text) 
                        || t.CreditClient.Name.ToLower().Contains(text)
                    select t).ToList<Transaction>();
        }

        /// <summary>
        /// Resulting map will have client as a key, and the value is the total sum of transactions 
        /// that have this client as a DebitClient. What we see here is a LINQ grouping query, gathered with
        /// anonymous class declaration, and ToDictionatry projection. 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Client, decimal> getTransactionSummary()
        {
            return (from t in context.Transactions 
                    group t by t.DebitClient into g 
                    select new { DebitClient = g.Key, Total = g.Sum(t => t.Amount) })
                    .ToDictionary(r => r.DebitClient, r => r.Total);
        }

    


    }
}
