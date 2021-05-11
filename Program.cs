using System;
using System.Collections.Generic;

namespace AddressBookSystem
{   
    public interface IAddressBook
    {
        void AddOrAccessAddressBook();
        void ViewAllAddressBooks();
        void DeleteAddressBook();
    }

    [Serializable]
    public class Program
    {
        // Constants
        public const string TO_ADD_OR_ACCESS = "a";
        public const string TO_VIEW_ALL_ADDRESSBOOKS = "view";
        public const string TO_DELETE_ADDRESS_BOOK = "delete";
        public const string SEARCH_PERSON_IN_CITY = "city";
        public const string SEARCH_PERSON_IN_STATE = "state";
        public const string VIEW_ALL_IN_CITY = "vcity";
        public const string VIEW_ALL_IN_STATE = "vstate";
        public const string COUNT_ALL_IN_CITY = "ccity";
        public const string COUNT_ALL_IN_STATE = "cstate";
        public const string EXIT = "e";

        static void Main(string[] args)
        { /* UC6:- Refactor to add multiple Address Book to the System.
                 Each Address Book has a unique Name 
                 - Use Console to add new Address Book 
                 - Maintain Dictionary of Address Book Name to Address Book
         */
            Console.WriteLine("**** Welcome To Address Book System ****");            
            AddressBookDetails addressBookDetails = AddressBookDetails.ReadFromFile();
            bool flag = true;
            while (flag)
            {
                Console.Write("\n1.Add Address Book System" +                              
                                  "\n2.Show Address Book System Name" +
                                  "\n3.Delete Address Book" +
                                  "\n4.Search Person in City or State " +                                  
                                  "\n5.Show all Record in City or State" +
                                  "\n6.Count of Record City or State" +                                 
                                  "\n7.Exit\nEnter Your Choice: - ");
               
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {                    
                    case 1:
                        addressBookDetails.AddAddressBook(); // add new Address book
                        break;                 
                   
                    case 2:
                        addressBookDetails.ViewAllAddressBooks(); //view all address book names
                        break;
                
                    case 3:
                        addressBookDetails.DeleteAddressBook(); //delete an address book
                        break;
                    
                    case 4:
                        try
                        { /* UC8:- Ability to search Person in a City or State across the multiple AddressBook
                                   - Search Result can show multiple person in the city or state
                          */
                            Console.Write("1.City\n2.State\nEnter Choice:-"); //print 
                        int choice2 = Convert.ToInt32(Console.ReadLine()); //take input and convert int32
                        if (choice2==1) //check condition
                        {
                            addressBookDetails.SearchInCity(); //search city
                        }
                        else if (choice2==2)
                        {
                            addressBookDetails.SearchInState();//search State
                        }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                   
                    case 5:
                        try
                        {/* UC8:- Ability to search Person in a City or State across the multiple AddressBook
                                   - Search Result can show multiple person in the city or state
                          */
                            Console.Write("1.City\n2.State\nEnter Choice:-"); //print
                        int choice3 = Convert.ToInt32(Console.ReadLine()); //take input and convert int32
                        if (choice3 == 1)
                        {
                            addressBookDetails.ViewAllByCity();  //  view all contact in a city
                        }
                        else if (choice3 == 2)
                        {
                            addressBookDetails.ViewAllByState();  // view all contact in a State
                        }                        
                      
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 6:
                        try
                        {     /* UC10:- Ability to get number of contact persons i.e. count by City or State.
                                       - Search Result will show count by city and by state.
                             */
                            Console.Write("1.City\n2.State\nEnter Choice:-"); //print
                        int choice4 = Convert.ToInt32(Console.ReadLine()); //take input and convert int32
                        if (choice4 == 1)
                        {
                            addressBookDetails.CountAllByCity(); //get count of contacts in City
                        }
                        else if (choice4 == 2)
                        {
                            addressBookDetails.CountAllByState(); //get count of contacts in state
                        }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;                   
                   
                    case 7:
                        
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter Valid Option");
                        break;
                }
            }

            // UC 13 Writing to the previously stored records.
            addressBookDetails.WriteToFile();
        }
    }
}