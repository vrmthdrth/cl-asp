using System.Data.Entity;

namespace ContactListApp.Models
{
    /// <summary>
    /// Класс контекста данных.
    /// </summary>
    public class ContactContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста.
        /// </summary>
        public ContactContext() : base("ContactListConnection")
        {

        }

        /// <summary>
        /// Контакты.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }
    }
}