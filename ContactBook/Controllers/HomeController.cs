using ContactBook.Models;
using ContactBook.Services.InterFace;
using ContactBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService contactService;
        public HomeController(IContactService iContactService)
        {
            contactService = iContactService;
        }

        public ActionResult Index()
        {
            try
            {
                List<ContactViewModel> contactList = contactService.GetContacts();
                List<ContactViewModel> contactViewModel = new List<ContactViewModel>();

                if (contactList != null)
                {
                    foreach (ContactViewModel contact in contactList)
                    {
                        contactViewModel.Add(contact);
                    }
                }

                ViewBag.contactViewModel = contactViewModel;
                return View(contactViewModel);
            }
            catch (Exception exe)
            {
                return View("Error");
            }
        }

        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContactSubmit(Contact con)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contactService.AddContact(con);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(con);
                }
            }
            catch (Exception exe)
            {
                return View("Error");
            }
        }

        public ActionResult EditContact(int id)
        {
            try
            {
                ContactViewModel contactViewModel = new ContactViewModel();
                Contact contact = new Models.Contact();
                contactViewModel = contactService.GetContactById(id);

                if (contactViewModel != null)
                {
                    contact.ContactId = contactViewModel.ContactId;
                    contact.FirstName = contactViewModel.FirstName;
                    contact.LastName = contactViewModel.LastName;
                    contact.PhoneNumber = contactViewModel.PhoneNumber;
                    contact.EmailID = contactViewModel.EmailId;
                    contact.IsActive = contactViewModel.IsActive;
                }

                return View(contact);
            }
            catch (Exception exe)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EditContactSubit(Contact contact)
        {
            try
            {
                contactService.UpdateContact(contact);
                return RedirectToAction("Index");
            }
            catch (Exception exe)
            {
                return View("Error");
            }
        }
        public ActionResult DeleteContact(int id)
        {
            try
            {
                contactService.DeleteContact(id);
                return RedirectToAction("Index");
            }
            catch (Exception exe)
            {
                return View("Error");
            }
        }

        public bool ActiveInactive(int id)
        {
            try
            {
                ContactViewModel contactViewModel = contactService.GetContactById(id);

                if (contactViewModel.IsActive)
                {
                    contactService.InActivateContact(id);
                    contactViewModel.IsActive = false;
                }
                else
                {
                    contactService.ActivateContact(id);
                    contactViewModel.IsActive = true;
                }
                return contactViewModel.IsActive;
            }
            catch (Exception exe)
            {
                return false;
            }
        }
    }
}