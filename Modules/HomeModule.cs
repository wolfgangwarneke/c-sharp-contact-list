using Nancy;
using ContactList.Objects;
using System.Collections.Generic;

namespace ContactList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/contacts"] = _ => {
        List<Contact> contactModel = Contact.GetAll();
        return View["contacts.cshtml", contactModel];
      };
      Get["/contacts/new"] = _ => {
        return View["addContact.cshtml"];
      };
      Post["/contacts/add"] = _ => {
        Contact newContact = new Contact(Request.Form["firstName"], Request.Form["lastName"], Request.Form["email"], Request.Form["phoneNumber"]);
        List<Contact> contactModel = Contact.GetAll();
        return View["contacts.cshtml", contactModel];
      };
    }
  }
}
