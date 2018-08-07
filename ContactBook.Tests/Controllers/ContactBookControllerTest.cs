using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using ContactBook.Services.InterFace;
using ContactBook.ViewModel;
using ContactBook.Models;
using ContactBook.Controllers;
using System.Web.Mvc;

namespace ContactBook.Tests.Controllers
{
    [TestFixture]
    public class ContactBookControllerTest
    {
        private Mock<IContactService> contactService;

        [TestFixtureSetUp]
        public void EnvrnmentSetup()
        {
            contactService = new Mock<IContactService>();
            List<ContactViewModel> viewModelList = new List<ContactViewModel>();
            ContactViewModel viewModel = new ContactViewModel
            {
                ContactId=1,
                FirstName="Naman",
                LastName="Khandelwal",
                PhoneNumber="9158937389",
                EmailId="naman.khandelwal24292@gmail.com",
                IsActive=true
            };
            viewModelList.Add(viewModel);
            

            contactService.Setup(data => data.GetContacts()).Returns(viewModelList);
            contactService.Setup(data => data.GetContactById(1)).Returns(viewModel);
        }

        [Test]
        public void Index_Notnull()
        {            
            ContactBookController controller = new ContactBookController(contactService.Object);

            var result = controller.Index();

            Assert.IsNotNull(result);            
        }

        [Test]
        public void AddContact_ReturnView()
        {
            ContactBookController controller = new ContactBookController(contactService.Object);

            var result = controller.AddContact() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void AdContactSubmit_NotNull()
        {
            Contact contact = new Models.Contact
            {
                FirstName = "Naman",
                LastName = "Khandelwal",
                PhoneNumber = "9158937389",
                EmailID = "naman.khandelwal24292@gmail.com"
            };
            ContactBookController controller = new ContactBookController(contactService.Object);

            var result = controller.AddContactSubmit(contact);

            Assert.IsNotNull(result);
        }

        [Test]
        public void EditContact_NotNull()
        {
            ContactBookController controller = new ContactBookController(contactService.Object);

            var result=controller.EditContact(1);

            Assert.IsNotNull(result);
        }

        [Test]
        public void AvtiveInactive_Isfalse()
        {
            ContactBookController controller = new ContactBookController(contactService.Object);

            var result=controller.ActiveInactive(1);

            Assert.IsFalse(result);
        }
        

        
    }
}
