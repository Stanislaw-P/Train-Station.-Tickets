using System;
using System.Linq;

namespace Train_Station.Tickets
{
    // Класс человека
    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }

    // Класс кассы
    public class CashRegister
    {
        public Train Train;
        public Ticket Ticket;
        string[] routes = new string[] { "Москва", "Владикавказ", "Краснодар", "Анапа" }; // Доступные муршруты
        Random rnd = new Random();
       
        // Регистрация пользователя
        public Person RegisterPerson(string firstName, string lastName, int age)
        {
            if(age < 18)
            {
                throw new Exception("Слишком маленький для билетов");
            }
            return new Person(firstName, lastName, age);
        }

        // Оформление билета
        public Ticket GetTicket(Person person, string departureCity, string arrivalCity)
        {
            if (!routes.Contains(departureCity) || !routes.Contains(arrivalCity))
                throw new Exception("Такие города не обслуживаем");
            int numberTicket = _getNumberTicket();
            return new Ticket(person, departureCity, arrivalCity, numberTicket);
        }

        // В данном методе должна быть нормальная логика генерации номера билета, но пока только так(
        private int _getNumberTicket()
        {
            return new Random().Next(10000, 20000);
        }
    }

    // Класс билета
    public class Ticket
    {
        public int NumberTicket;
        public string DepartureCity;
        public string ArrivalCity;
        public Person Person;
        public Ticket(Person person, string departureCity, string arrivalCity, int numberTicket)
        {
            Person = person;
            NumberTicket = numberTicket;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
        }

        public override string ToString()
        {
            return $"Билет # {NumberTicket}\nВладелец: {Person}\nОткуда: {DepartureCity}\nКуда: {ArrivalCity}";
        }
    }

    // Класс поезда, ктоторый критически не готов и пока нигде не используется
    public class Train
    {
        public string DepartureCity; // город убития
        public string ArrivalCity; // город прибытия
        public string DepartureTime;
        public int NumberTrains;
        public int[] Carriages = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // Вагоны
        Random rnd = new Random();

        public Train(string departureCity, string arrivalCity)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            NumberTrains = rnd.Next(1, 20);
        }
    }


}
