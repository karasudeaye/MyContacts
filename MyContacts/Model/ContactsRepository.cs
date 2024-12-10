using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.Model
{
    public class ContactsRepository
    {
        static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo {Id = 1, NameSurname = "Hüseyin Şimşek", Email = "huseyinsimsek@gmail.com", PhoneNumber = "053357252"}
        };
        static int maxId = 2;

        public ContactsRepository()
        {
        }

        public ObservableCollection<ContactInfo> GetContacts()
        {
            return new ObservableCollection<ContactInfo>(contacts);
        }

        public void AddContact(ContactInfo contact)
        {
            contact.Id = maxId++;
            contacts.Add(contact);
        }

        public ContactInfo GetContact(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public async Task Update(ContactInfo updatedContact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.Id == updatedContact.Id);
            if (existingContact != null)
            {
                existingContact.NameSurname = updatedContact.NameSurname;
                existingContact.Email = updatedContact.Email;
                existingContact.PhoneNumber = updatedContact.PhoneNumber;
            }
            else
            {
                throw new Exception("Contact not found.");
            }

            await Task.CompletedTask;
        }
    }
}
