using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace c_ch_dop_work
{

    public interface IContact
    {
        string Name { get; }
        string PhoneNumber { get; }
    }

    public class Contact: IContact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        
    }

    public class ContactManager<T> where T : IContact
    {
        public List<Contact> Contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            Contacts.Remove(contact);
        }

        public IEnumerable<Contact> GetContactByNumber(string number)
        {
            return Contacts.Where(p => p.PhoneNumber == number);
        }
        public IEnumerable<Contact> GetContactByName(string name)
        {
            return Contacts.Where(p => p.Name == name);
        }

       public void SaveFileToJson(string path)
        {
            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(path, json);
        }
        public void LoadJson(string path)
        {
            string json = File.ReadAllText(path);
            Contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
        }

        public void SaveToXml(string path)
        {
            XElement Xml = new XElement("Contacts", from Contact in Contacts
                                                    select new XElement("Contact",
                                                    new XAttribute("Name", Contact.Name),
                                                    new XElement("Phone", Contact.PhoneNumber)
                                                    
                                                   ));
            Xml.Save(path);
        }
        public void LoadToXml(string path)
        {
            XDocument Xml = XDocument.Load(path);
            Contacts = Xml.Descendants("Contact").Select(p => new Contact
            {
                Name = p.Attribute("Name").Value,
                PhoneNumber=p.Element("Phone").Value


            }).ToList();
        }



                

        




    }

}
