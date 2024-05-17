using System;
using System.Collections.Generic;
using System.Linq;

// Abstract class for contact components
public abstract class ContactComponent
{
    public string PhoneNumber { get; set; } 

    // Abstract method for displaying contact details
    public abstract void ShowContact(int contactNumber);
}

// Phone class, inherits from ContactComponent
public class Phone : ContactComponent
{
    // Implement the abstract method
    public override void ShowContact(int contactNumber)
    {
        Console.WriteLine($"Phone Number: {PhoneNumber}");
    }
}

// User class, inherits from Phone
public class User : Phone
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Polymorphism: Overrides the abstract method to provide specific behavior for users.
    public override void ShowContact(int contactNumber)
    {
        Console.WriteLine($"Contact {contactNumber}: {FirstName} {LastName}");
        base.ShowContact(contactNumber); // Calls the base class method
    }
}

// Contact class
public class Contact
{
    private List<User> contacts = new List<User>();

    // Encapsulation: The contacts list is private, and access is controlled through methods.

    // Polymorphism: Accepts any object that is a subclass of ContactComponent, allowing flexibility.
    public void AddContact(User contact)
    {
        contacts.Add(contact);
    }

    // Polymorphism: Accepts any object that is a subclass of ContactComponent, allowing flexibility.
    public void EditContactByPhoneNumber(string phoneNumber, User updatedContact)
    {
        User contact = contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);

        if (contact != null)
        {
            // Update contact details
            contact.PhoneNumber = updatedContact.PhoneNumber;
            
          
            contact.FirstName= updatedContact.FirstName;
            contact.LastName= updatedContact.LastName;

            Console.WriteLine("Contact edited successfully!");
            Console.WriteLine("=================================");
        }
        else
        {
            Console.WriteLine("Contact not found with the provided phone number.");
            Console.WriteLine("=================================");
        }
    }

    // Polymorphism: Accepts any object that is a subclass of ContactComponent, allowing flexibility.
    public void DeleteContactByPhoneNumber(string phoneNumber)
    {
        User contact = contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);

        if (contact != null)
        {
            contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully!");
            Console.WriteLine("=================================");
        }
        else
        {
            Console.WriteLine("Contact not found with the provided phone number.");
            Console.WriteLine("=================================");
        }
    }

    // Polymorphism: Accepts any object that is a subclass of ContactComponent, allowing flexibility.
    public void ShowAllContacts()
    {
        Console.WriteLine("All Contacts:");

        for (int i = 0; i < contacts.Count; i++)
        {
            contacts[i].ShowContact(i + 1);
            Console.WriteLine("=================================");
        }
    }
}

// Demo class containing the main method
class Demo
{
    // Main method
    static void Main()
    {
        // Create a new Contact object
        Contact contact = new Contact();

        int choice;
        // Display a menu until the user chooses to exit
        do
        {
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Show All Contacts");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Add Contact
                        Console.WriteLine("Enter contact details:");
                        User newContact = GetContactDetailsFromUser();
                        contact.AddContact(newContact);
                        Console.WriteLine("Contact added successfully!");
                        Console.WriteLine("=================================");
                        break;

                    case 2:
                        // Edit Contact
                        Console.Write("Enter the phone number to search for the contact: ");
                        string phoneNumberToSearch = Console.ReadLine();
                        User updatedContact = GetContactDetailsFromUser();
                        contact.EditContactByPhoneNumber(phoneNumberToSearch, updatedContact);
                        break;

                    case 3:
                        // Delete Contact
                        Console.Write("Enter the phone number to search for the contact: ");
                        string phoneNumberToDelete = Console.ReadLine();
                        contact.DeleteContactByPhoneNumber(phoneNumberToDelete);
                        break;

                    case 4:
                        // Show All Contacts
                        contact.ShowAllContacts();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid menu option.");
                Console.WriteLine("=================================");
            }

        } while (choice != 5);
    }

    // Helper method to get contact details from the user
    public static User GetContactDetailsFromUser()
    {
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Is this a user? (Y/N): ");
        string isUserInput = Console.ReadLine();

        if (isUserInput.ToUpper() == "Y")
        {
            User user = new User();
            Console.Write("First Name: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            user.LastName = Console.ReadLine();

            user.PhoneNumber = phoneNumber;
            return user;
        }
        else
        {
            User phone = new User();
            phone.PhoneNumber = phoneNumber;
            return phone;
        }
    }
}
