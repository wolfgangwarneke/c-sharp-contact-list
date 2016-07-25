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
        return View["addContactForm.cshtml"];
      };
      Post["/contacts/add"] = _ => {
        Contact newContact = new Contact(Request.Form["firstName"], Request.Form["lastName"], Request.Form["email"], Request.Form["phoneNumber"]);
        List<Contact> contactModel = Contact.GetAll();
        return View["contacts.cshtml", contactModel];
      };
      Get["/contacts/edit"] = _ => {
        List<Contact> contactModel = Contact.GetAll();
        return View["editContacts.cshtml", contactModel];
      };
    }
  }
}
