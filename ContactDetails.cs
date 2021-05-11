using System;
using System.Collections.Generic;
using System.Text;
namespace AddressBookSystem
{
    [Serializable]
    public class ContactDetails
    {/*     UC2:-Ability to add a new Contact to Address Book - Use Console to add person details from AddressBookMain class
            - Use Object Oriented Concepts to manage relationship between AddressBook and Contact Person
    */
        // Variables
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NameOfAddressBook { get; set; }       
        
        public ContactDetails(string firstName, string lastName, string address, string city, string state, string zip,
                               string phoneNumber, string email, string nameOfAddressBook)
        {
            this.FirstName = firstName.ToLower();
            this.LastName = lastName.ToLower();
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.NameOfAddressBook = nameOfAddressBook;
        }

        public override bool Equals(Object obj)
        {
            // if the list is null
            if (obj == null)
                return false;
            try
            {               
                var duplicates = ((List<ContactDetails>)obj).Find(contact => ((contact.FirstName).ToLower() == (FirstName).ToLower()
                                                                        && (contact.LastName).ToLower() == (LastName).ToLower()
                                                                        && contact.NameOfAddressBook == NameOfAddressBook)); // Get the contacts from list with same name              
                if (duplicates != null)// Return true if duplicate is found else false
                    return true;
                else
                    return false;
            }
            catch
            {             
                var contact = ((ContactDetails)obj);  // Get the contacts from list with same name
                return ((contact.FirstName).ToLower() == (FirstName).ToLower()
                        && (contact.LastName).ToLower() == (LastName).ToLower()
                        && contact.NameOfAddressBook == NameOfAddressBook);
            }
        }
        
        public void Display() //Create method to Display record
        {
            // For null contact
            if (NameOfAddressBook == null)
            {
                Console.WriteLine("No record found");
                return;
            }
            // Display all Record
            Console.WriteLine($"Name of contact is {FirstName} {LastName}"); //print 
            Console.WriteLine($"First Name:- {FirstName}");
            Console.WriteLine($"Last Name:- {LastName}");
            Console.WriteLine($"Address:- {Address}");
            Console.WriteLine($"City:- {City}");
            Console.WriteLine($"State:- {State}");
            Console.WriteLine($"Zip:- {Zip}");
            Console.WriteLine($"Phone Number:- {PhoneNumber}");
            Console.WriteLine($"Email:- {Email}");
        }
    }
}
