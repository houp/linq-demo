using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace boring.bank.datasource
{
    public partial class Client

    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public List<Client> Beneficiaries { get; set; }
        public List<Transaction> Transactions { get; set; }


        public override bool Equals(Object o)
        {
            if (o == null) return false;
            if (o is Client)
            {
                Client c = o as Client;
                return c.Id == Id;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return Id != null ? (int)Id : 0;
        }

   


    }
}
