using System;
using System.Collections.Generic;

namespace ContactList.Objects
{
  public class Contact
  {
    private static List<Contact> contactInstances = new List<Contact> {};
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phoneNumber;
    private int _id;
    //phone number is string so user can choose formatting

    public Contact(string firstName, string lastName, string email, string phoneNumber)
    {
      _firstName = firstName;
      _lastName = lastName;
      _email = email;
      _phoneNumber = phoneNumber;
      _id = contactInstances.Count;
      contactInstances.Add(this);
    }

    public static List<Contact> GetAll()
    {
      return contactInstances;
    }
    public static void DeleteAll()
    {
      contactInstances.Clear();
    }

    public int GetId()
    {
      return _id;
    }
    public void SetId(int id)
    {
      _id = id;
    }

    public static Contact Find(int id)
    {
      return contactInstances[id];
    }
    public static void DeleteById(int id)
    {
      contactInstances.RemoveAt(id);
    }

    public static void RefreshIds()
    {
      List<Contact> contactsToUpdateId = Contact.GetAll();
      for (var i = 0; i < contactsToUpdateId.Count; i ++)
      {
        contactsToUpdateId[i].SetId(i);
      }
    }

    public string GetFullName()
    {
      return this.GetFirstName() + " " + this.GetLastName();
    }

    public void SetFullName(string firstName, string lastName)
    {
      this.SetFirstName(firstName);
      this.SetLastName(lastName);
    }

    public string GetFirstName()
    {
      return _firstName;
    }
    public void SetFirstName(string firstName)
    {
      _firstName = firstName;
    }
    public string GetLastName()
    {
      return _lastName;
    }
    public void SetLastName(string lastName)
    {
      _lastName = lastName;
    }
    public string GetEmail()
    {
      return _email;
    }
    public void SetEmail(string email)
    {
      _email = email;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber(string phoneNumber)
    {
      _phoneNumber = phoneNumber;
    }
  }
}
