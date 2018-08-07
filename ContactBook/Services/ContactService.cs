using ContactBook.Models;
using ContactBook.Services.InterFace;
using ContactBook.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ContactBook.Services
{
    public class ContactService : IContactService
    {
        public List<ContactViewModel> GetContacts()
        {
            List<ContactViewModel> contacts = new List<ContactViewModel>();

            try
            {
                string sql = "SELECT * FROM Contact";

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactBook"].ConnectionString))
                {
                    contacts = connection.Query<ContactViewModel>(sql).ToList();
                }

                return contacts;
            }
            catch (Exception exe)
            {
                return null;
            }
        }


        public void AddContact(Contact contact)
        {
            try
            {
                string sql = @"INSERT INTO Contact(FirstName, LastName, PhoneNumber, EmailId, IsActive)
                            VALUES(@FirstName, @LastName, @PhoneNumber, @EmailId, 1)";
                List<Contact> contacts = new List<Contact>();
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactBook"].ConnectionString))
                {
                    connection.Query<Contact>(sql, contact).SingleOrDefault();
                }
            }
            catch (Exception exe)
            {

            }
        }

        public ContactViewModel GetContactById(int contactID)
        {
            try
            {
                string sql = "SELECT * FROM Contact Where ContactID=@ContactID";

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactBook"].ConnectionString))
                {
                    return connection.Query<ContactViewModel>(sql, new { @ContactID = contactID }).SingleOrDefault();
                }
            }
            catch (Exception exe)
            {
                return null;
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                string sql = @"UPDATE Contact
                        set FirstName = @FirstName,LastName = @LastName,PhoneNumber = @PhoneNumber,EmailId = @EmailId
                        Where ContactID = @ContactID";
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactBook"].ConnectionString))
                {
                    connection.Query<Contact>(sql, contact).SingleOrDefault();
                }
            }
            catch (Exception exe)
            {

            }
        }

        public void DeleteContact(int contactId)
        {
            try
            {
                string sql = @"DELETE from Contact WHERE ContactID=@contactId";
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactBook"].ConnectionString))
                {
                    connection.Query<Contact>(sql, new { ContactID = @contactId }).SingleOrDefault();
                }
            }
            catch (Exception exe)
            {

            }

        }

        public void ActivateContact(int contactId)
        {
            try
            {
                string sql = @"UPDATE Contact
                        set IsActive=1
                        Where ContactID = @ContactID";
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactBook"].ConnectionString))
                {
                    connection.Query<Contact>(sql, new { ContactID = @contactId }).SingleOrDefault();
                }
            }
            catch (Exception exe)
            {

            }

        }

        public void InActivateContact(int contactId)
        {
            try
            {
                string sql = @"UPDATE Contact
                        set IsActive=0
                        Where ContactID = @ContactID";
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactBook"].ConnectionString))
                {
                    connection.Query<Contact>(sql, new { ContactID = @contactId }).SingleOrDefault();
                }
            }
            catch (Exception exe)
            {

            }

        }
    }
}