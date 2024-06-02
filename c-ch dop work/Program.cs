using System.Xml.Linq;
using System;

using Newtonsoft.Json;

namespace c_ch_dop_work
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Задание 1");
            FilmManager filmManager = new FilmManager();
            filmManager.AddFilm(new Film { Name = "Atlas", Year = 2024, Director = "Брэд Пэйтон", Ganre = "боевик" });
            filmManager.AddFilm(new Film { Name = "Journey 2: The Mysterious Island", Year = 2012, Director = "Брэд Пэйтон", Ganre = "приключения" });
            filmManager.AddFilm(new Film { Name = "Princess Mononoke", Year = 1997, Director = "Хаяо Миядзаки", Ganre = "приключения" });
            filmManager.AddFilm(new Film { Name = "The Lord of the Rings: The Two Towers", Year = 2002, Director = "Питер Джексон", Ganre = "приключения" });
            filmManager.SaveToJson("Films.json");
            filmManager.LoadFromJson("Films.json");
            Console.WriteLine("Films.json");
            foreach (var i in filmManager.Films)
            {
                Console.WriteLine($"Name:{i.Name},  Year:{i.Year},  Director:{i.Director},  Ganre:{i.Ganre}");
            }

            Console.WriteLine();


            filmManager.SaveToXml("Films.xml");
            filmManager.LoadToXml("Films.xml");
            Console.WriteLine("Films.xml");
            foreach (var i in filmManager.Films)
            {
                Console.WriteLine($"Name:{i.Name},  Year:{i.Year},  Director:{i.Director},  Ganre:{i.Ganre}");
            }

            //==============================================================
            Console.WriteLine();
            Console.WriteLine("Задание 2");

            ContactManager<Contact> contactManager = new ContactManager<Contact>();

            contactManager.AddContact(new Contact { Name = "Иванов Иван", PhoneNumber = "4458645645" });
            contactManager.AddContact(new Contact { Name = "Петров Пётр", PhoneNumber = "1445115645" });
            contactManager.AddContact(new Contact { Name = "Сергеев Глеб", PhoneNumber = "8455645245" });
            contactManager.AddContact(new Contact { Name = "Иванова Маша", PhoneNumber = "1455125648" });

            contactManager.SaveToXml("Contactsxml.Xml");
            try
            {
                contactManager.LoadToXml("Contactsxml.Xml");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Неверно указан путь");
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Contactsxml.Xml");
            foreach (var contact in contactManager.Contacts)
            {
                Console.WriteLine($"Name: {contact.Name},   PhoneNumber: {contact.PhoneNumber}");
            }





        }


    }



}
