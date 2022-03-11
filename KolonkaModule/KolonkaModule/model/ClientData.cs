using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolonkaModule.model
{
    public class ClientData
    {
        int id;
        string cardholder;
        int balance;
        string card;

        public int Id { get => id; set => id = value; }
        public string Cardholder { get => cardholder; set => cardholder = value; }
        public int Balance { get => balance; set => balance = value; }
        public string Card { get => card; set => card = value; }

        public override string ToString()
        {
            return Cardholder;
        }
    }
}
