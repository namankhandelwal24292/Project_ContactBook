using ContactBook.Models;
using ContactBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Services.InterFace
{
    public interface IContactService
    {
        List<ContactViewModel> GetContacts();
        ContactViewModel GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int contactId);
        void ActivateContact(int contactId);
        void InActivateContact(int contactId);
    }
}
