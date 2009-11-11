 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;

namespace Daxko.Guild.Domain.Tests.Utility
 {   
     public class AddressBookSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<AddressBook>
         {
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
         public class when_asking_for_all_movies : concern
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

             it should_return_a_set_of_all_movies_in_the_address_book = () =>
             {
                 result.should_contain(steven, some_other_guy);
             };

             static IList<Contact> result;
             static IList<Contact> contacts;
             static Contact steven;
             static Contact some_other_guy;
         } 
     }
 }
