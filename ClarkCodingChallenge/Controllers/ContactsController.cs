using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Http;
using ClarkCodingChallenge.BusinessLogic;
using System.Collections.Generic;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactsService contactsService;

        public ContactsController(ContactsService _contactsService)
        {
            contactsService = _contactsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SubmitContact")]
        public IActionResult SubmitContact(ContactViewModel contact)
        {
            ValidationResponse validationResponse = contactsService.ValidateContact(contact);
            UploadResponseModel uploadResponse = new UploadResponseModel { Contact = contact };

            if (validationResponse.IsValid)
            {
                uploadResponse = contactsService.ProcessContact(contact);
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Errors = validationResponse.ErrorMessages });
            }

            return View(uploadResponse);
        }

        [HttpGet]
        [Route("Contacts")]
        public List<ContactViewModel> GetContacts(string lastName = null, bool ascending = true)
        {
            return contactsService.GetContacts(lastName, ascending);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
