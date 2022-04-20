using ClarkCodingChallenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.BusinessLogic
{
	public static class ContactsExtensions
	{
		internal static List<ContactViewModel> SortContacts(this List<ContactViewModel> contacts, string lastName, bool ascending)
		{
			if (!string.IsNullOrWhiteSpace(lastName))
			{
				contacts = contacts.FindAll(c => c.LastName == lastName);
			}
			if (ascending)
			{
				contacts = contacts.OrderBy(c => c.LastName).ToList();
			}
			else
			{
				contacts = contacts.OrderByDescending(c => c.LastName).ToList();
			}

			return contacts;
		}
	}
}
