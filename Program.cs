using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Station.Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            CashRegister cashRegister = new CashRegister();
            Person person = cashRegister.RegisterPerson("Стас", "Персаев", 19);
            Ticket ticket = cashRegister.GetTicket(person, "Краснодар", "Анапа");
            Console.WriteLine("Ваш билет создан");
            Console.WriteLine(ticket);
        }
    }
}
