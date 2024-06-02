using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Linq;
using System.ComponentModel;

namespace c_ch_dop_work
{
    public interface IFilm
    {
        string Name { get; set; }
        int Year { get; set; }
        string Director { get; set; }
        string Ganre { get; set; }


    }

    public class Film: IFilm
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Ganre { get; set; }

    }
    public class FilmManager
    {
        public List<Film> Films =new List<Film>();

        public void AddFilm(Film film)
        {
            Films.Add(film);
        }
        public void RemoveFilm(string name) { Films.RemoveAll(p => p.Name == name); }

        public void SaveToJson(string path)
        {
            string json = JsonConvert.SerializeObject(Films);
            File.WriteAllText(path, json);

        }
        public void LoadFromJson(string path)
        {
            string json = File.ReadAllText(path);
            Films = JsonConvert.DeserializeObject<List<Film>>(json);

        }

        //public void SaveToXml(string path)
        //{
        //    XElement Xml = new XElement("Films", from film in Films
        //                                               select new XElement("Film",
        //                                               new XAttribute("Name", film.Name),
        //                                               new XAttribute("Year", film.Year),
        //                                               new XAttribute("Director", film.Director),
        //                                               new XAttribute("Ganre", film.Ganre)
        //                                               ));
        //    Xml.Save(path);

        //}

        public void SaveToXml(string path)
        {
            XElement Xml = new XElement("Films", from film in Films
                                                 select new XElement("Film",
                                                 new XElement("Name", film.Name),
                                                 new XElement("Year", film.Year),
                                                 new XElement("Director", film.Director),
                                                 new XElement("Ganre", film.Ganre)
                                                 ));
            Xml.Save(path);

        }
        public void LoadToXml(string path)
        {
            XDocument Xml = XDocument.Load(path);
            Films = Xml.Descendants("Film").Select(p => new Film
            {
                Name = p.Element("Name").Value,
                Year = int.Parse(p.Element("Year").Value),
                Director = p.Element("Director").Value,
                Ganre = p.Element("Ganre").Value
            }).ToList();
        }




        public IEnumerable<Film> SortByName()
        {
            return Films.OrderBy(p=>p.Name);
        }
        public IEnumerable<Film> SortByDirector()
        {
            return Films.OrderBy(p => p.Director);
        }




    }
}
