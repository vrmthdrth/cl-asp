using ContactListApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ContactListApp.Controllers
{
    /// <summary>
    /// Главный контроллер.
    /// </summary>
    public class HomeController : Controller
    {
        ContactContext db = new ContactContext();

        /// <summary>
        /// Действие, возвращающее представление главной страницы.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Contacts = db.Contacts;
            return View();
        }

        /// <summary>
        /// Get-версия метода изменения данных контакта.
        /// </summary>
        /// <param name="parameter">Идентификатор контакта.</param>
        /// <returns>Представление изменения данных контакта,
        /// или представление главной страницы,
        /// если идентификтор не определен.</returns>
        [HttpGet]
        public ActionResult Change(int? parameter)
        {
            return parameter != null 
                ? (ActionResult)View(db.Contacts.Find(parameter)) 
                : RedirectToAction("Index");
        }

        /// <summary>
        /// Post-версия метода изменения данных контакта.
        /// </summary>
        /// <param name="contact">Модель контакта.</param>
        /// <returns>Представление главной страницы,
        /// или представление изменения контакта,
        /// если модель не прошла валидацию.</returns>
        [HttpPost]
        public ActionResult Change(Contact contact)
        {
            if (ModelState.IsValid) 
            {
                db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        /// <summary>
        /// Get-версия метода добавления нового контакта.
        /// </summary>
        /// <returns>Представление добавления контакта.</returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View(new Contact());
        }

        /// <summary>
        /// Post-версия метода добавления нового контакта.
        /// </summary>
        /// <param name="contact">Модель контакта.</param>
        /// <returns>Представление главной страницы,
        /// или представление добавления контакта,
        /// если модель не прошла валидацию.</returns>
        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        /// <summary>
        /// Действие удаления контакта из базы данных.
        /// </summary>
        /// <param name="parameter">Идентификатор контакта.</param>
        /// <returns>Представление главной страницы.</returns>
        public ActionResult Delete(int? parameter)
        {
            Contact contact = db.Contacts.Find(parameter);
            if(contact != null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// Действие поиска контактов.
        /// </summary>
        /// <param name="parameter">Строка-запрос.</param>
        /// <param name="searchCriterion">Критерий поиска.</param>
        /// <returns>Представление со списком найденных контактов.</returns>
        [HttpGet]
        public ActionResult Search(string parameter, string searchCriterion = null)
        {
            ViewBag.SearchedContacts = SearchByCriterion(parameter, searchCriterion);
            return View();
        }

        /// <summary>
        /// Приватный вспомогательный метод поиска контактов по заданному запросу и критерию в базе данных.
        /// </summary>
        /// <param name="parameter">Строка-запрос.</param>
        /// <param name="searchCriterion">Критерий поиска.</param>
        /// <returns>Список найденных контактов по запросу.</returns>
        private List<Contact> SearchByCriterion(string parameter, string searchCriterion)
        {
            List<Contact> searchList = new List<Contact>();

            if (parameter == string.Empty || parameter == null)
            {
                foreach (Contact contact in db.Contacts)
                {
                    searchList.Add(contact);
                }
                return searchList;
            }

            parameter = parameter.ToLower();

            switch (searchCriterion)
            {
                case "":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "byDefault":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "surname":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.Surname.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "name":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.Name.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "patronymic":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.Patronymic.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "birthDate":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.BirthDate.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "organization":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.Organization.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "position":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.Position.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "phone":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.ContactInfo.Phone.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "email":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.ContactInfo.Email.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "skype":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.ContactInfo.Skype.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
                case "other":
                    foreach (Contact contact in db.Contacts)
                    {
                        if (contact.ContactInfo.Other.ToString().ToLower().Contains(parameter))
                        {
                            searchList.Add(contact);
                        }
                    };
                    break;
            }

            return searchList;
        }
    }
}