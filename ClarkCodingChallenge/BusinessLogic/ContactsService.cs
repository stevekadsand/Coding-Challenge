using ClarkCodingChallenge.Contexts;
using ClarkCodingChallenge.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService
    {
        private readonly ContactsContext contactContext;

        public ContactsService(ContactsContext _contactContext)
        {
            this.contactContext = _contactContext;
        }

        public List<ContactViewModel> GetContacts (string lastName, bool ascending)
        {
            var contacts = this.contactContext.GetContacts();
            contacts.SortContacts(lastName, ascending);            

            return contacts;
        }

        public UploadResponseModel ProcessContact(ContactViewModel contact)
        {
            UploadResponseModel response = this.contactContext.CommitContact(contact);

            return response;
        }

        public ValidationResponse ValidateContact(ContactViewModel contact)
        {
            ValidationResponse validator = new ValidationResponse { ErrorMessages = new List<string>() };
            if (!this.ValidateName(contact.FirstName))
            {
                validator.ErrorMessages.Add("First Name is null or empty");
            }
            if (!this.ValidateName(contact.LastName))
            {
                validator.ErrorMessages.Add("Last Name is null or empty");
            }
            if (!string.IsNullOrWhiteSpace(contact.Email) && !this.ValidateEmail(contact.Email))
            {
                validator.ErrorMessages.Add("Email is not a valid format");
            }

            validator.IsValid = validator.ErrorMessages.Count == 0 ? true : false;

            return validator;
        }

        private bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        private bool ValidateEmail(string email)
        {
            Regex rx = new Regex("/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:/.[a-zA-Z0-9-]+)*$/");

            //return rx.IsMatch(email);
            return true;
        }
    }
}
