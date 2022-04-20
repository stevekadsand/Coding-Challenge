using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.Contexts
{
	public class ContactsContext
	{
		private readonly IMemoryCache memoryCache;

		public ContactsContext (IMemoryCache _memoryCache)
		{
			this.memoryCache = _memoryCache;
		}

		public UploadResponseModel CommitContact(ContactViewModel contact)
		{
			try
			{
				var response = new UploadResponseModel { Contact = contact, Errors = new List<string>() };
				var cachedContacts = new List<ContactViewModel>();
				var cacheExist = this.memoryCache.TryGetValue("Contacts", out cachedContacts);

				if (cacheExist)
				{
					cachedContacts.Add(contact);
				}
				else
				{
					var contacts = new List<ContactViewModel>();
					contacts.Add(contact);
					this.memoryCache.Set("Contacts", contacts);
					var cache = this.memoryCache.Get("Contacts");
					Console.WriteLine(cache);
				}

				return response;
			}
			catch (Exception e)
			{
				var errorResponse = new UploadResponseModel { Errors = new List<string>() };
				errorResponse.Errors.Add(e.Message);

				return errorResponse;
			}
		}

		public List<ContactViewModel> GetContacts()
		{
			var cachedContacts = new List<ContactViewModel>();
			var cacheExist = this.memoryCache.TryGetValue("Contacts", out cachedContacts);

			if (cacheExist)
			{
				return cachedContacts;
			}
			else
			{
				return new List<ContactViewModel>();
			}
		}
	}
}
