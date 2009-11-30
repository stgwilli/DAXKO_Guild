using System.Collections.Generic;
using Daxko.Guild.Domain.extensions;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;

namespace Daxko.Guild.Domain.Tests.Domain
{
    public class AddressBookSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<AddressBook>
        {
        }

        public class concerns_for_searching: concern
        {
            context c = () =>
                {
                    steven = new Contact(){name = "steven"};
                    adam = new Contact(){name = "adam"};

                    contacts = new List<Contact>() { adam, steven };
                    provide_a_basic_sut_constructor_argument(contacts);
                };

            protected static Contact steven;
            protected static Contact adam;
            protected static IList<Contact> contacts;
        }

        [Concern(typeof(AddressBook))]
        public class when_adding_a_contact : concern
        {
            context c = () =>
                {
                    contact = new Contact();
                    contacts = new List<Contact>();

                    provide_a_basic_sut_constructor_argument(contacts);
                };

            because b = () =>
                {
                    sut.add(contact);
                };
        
            it should_store_the_contact = () =>
                {
                    contacts.should_contain(contact);
                };

            static Contact contact;
            static IList<Contact> contacts;
        }

        [Concern(typeof(AddressBook))]
        public class when_asking_for_all_contacts : concern
        {
            context c = () =>
                {
                    steven = new Contact();
                    some_other_guy = new Contact();
                    contacts = new List<Contact>() {steven, some_other_guy};

                    provide_a_basic_sut_constructor_argument(contacts);
                };

            because b = () =>
                {
                    result = sut.all_contacts();
                };

            it should_return_a_set_of_all_contacts_in_the_address_book = () =>
                {
                    result.should_contain(steven, some_other_guy);
                };

            static IList<Contact> result;
            static IList<Contact> contacts;
            static Contact steven;
            static Contact some_other_guy;
        }

        [Concern(typeof (AddressBook))]
        public class when_searching_for_a_contact_based_on_name : concerns_for_searching
        {
            because b = () =>
                {
                    found_contacts = sut.all_contacts().that_match(Where<Contact>(x => x.name).equal_to("adam"));
                };

            it should_return_the_contact_with_the_specified_name = () =>
                {
                    found_contacts.should_contain(adam);
                };

            static IEnumerable<Contact> found_contacts;
        }

        [Concern(typeof (AddressBook))]
        public class when_searching_for_contacts_using_a_predicate : concerns_for_searching
        {
            context c = () =>
                {
                };

            because b = () =>
                {
                    found_contacts = sut.all_contacts().that_match(x => x.name.Equals("adam"));
                };

            it should_return_the_contacts_that_meet_the_predicate = () =>
                {
                    found_contacts.should_contain(adam);
                };

            static IEnumerable<Contact> found_contacts;
        }

    }
}