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
      Get["/contacts/edit/form/name/{id}"] = parameters => {
        Contact contactToEdit = Contact.Find(parameters.id);
        return View["editNameForm.cshtml", contactToEdit];
      };
      Post["/contacts/edit/name/{id}"] = parameters => {
        Contact contactToEdit = Contact.Find(parameters.id);
        contactToEdit.SetFullName(Request.Form["firstName"], Request.Form["lastName"]);
        List<Contact> contactModel = Contact.GetAll();
        return View["contacts.cshtml", contactModel];
      };
      Get["/contacts/edit/form/email/{id}"] = parameters => {
        Contact contactToEdit = Contact.Find(parameters.id);
        return View["editEmailForm.cshtml", contactToEdit];
      };
      Post["/contacts/edit/email/{id}"] = parameters => {
        Contact contactToEdit = Contact.Find(parameters.id);
        contactToEdit.SetEmail(Request.Form["email"]);
        List<Contact> contactModel = Contact.GetAll();
        return View["contacts.cshtml", contactModel];
      };
      Get["/contacts/edit/form/phone/{id}"] = parameters => {
        Contact contactToEdit = Contact.Find(parameters.id);
        return View["editPhoneForm.cshtml", contactToEdit];
      };
      Post["/contacts/edit/phone/{id}"] = parameters => {
        Contact contactToEdit = Contact.Find(parameters.id);
        contactToEdit.SetPhoneNumber(Request.Form["phoneNumber"]);
        List<Contact> contactModel = Contact.GetAll();
        return View["contacts.cshtml", contactModel];
      };
      Get["/contacts/delete/all/confirmation"] = _ => {
        return View["deleteAllConfirmation.cshtml"];
      };
      Post["/contacts/delete/all"] = _ => {
        if (Request.Form["confirmation"] == "yes") Contact.DeleteAll();
        List<Contact> contactModel = Contact.GetAll();
        return View["contacts.cshtml", contactModel];
      };
      Get["/contacts/delete/one-or-more"] = _ => {
        List<Contact> contactModel = Contact.GetAll();
        return View["deleteOneOrMoreContacts.cshtml", contactModel];
      };
    }
  }
}
