using ContactBook.Models;
using ContactBook.ViewModel;
using System.Collections.Generic;

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
