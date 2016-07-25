using System;
using System.Collections.Generic;

namespace ContactList.Objects
{
  public class Contact
  {
    private static List<Contact> contactInstances;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phoneNumber;
    //phone number is string so user can choose formatting

    public Contact(string firstName, string lastName, string email, string phoneNumber)
    {
      _firstName = firstName;
      _lastName = lastName;
      _email = email;
      _phoneNumber = phoneNumber;
    }
  }
}
