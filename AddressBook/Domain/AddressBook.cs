using System;
using System.Collections.Generic;

namespace Daxko.Guild.Domain
{
    public class AddressBook
    {
        readonly IList<Contact> contacts;

        public AddressBook() : this(new List<Contact>())
        {
        }

        public AddressBook(IList<Contact> contacts)
        {
            this.contacts = contacts;
        }

        public void add(Contact contact)
        {
            contacts.Add(contact);
        }

        public IList<Contact> all_contacts()
        {
            return contacts;
        }
    }
}
