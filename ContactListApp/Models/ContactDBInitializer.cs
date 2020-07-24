using System.Data.Entity;

namespace ContactListApp.Models
{
    /// <summary>
    /// Класс-инициализатор базы данных.
    /// </summary>
    public class ContactDBInitializer : CreateDatabaseIfNotExists<ContactContext>
    {
        /// <summary>
        /// Метод первоначальной инициализации бд.
        /// </summary>
        /// <param name="dataBase">Контекст данных.</param>
        protected override void Seed(ContactContext dataBase)
        {
            dataBase.Contacts.Add(new Contact
            {
                Surname = "Александров",
                Name = "Александр",
                Patronymic = "Александрович",
                BirthDate = "1995-03-15",
                Organization = "Random Organization",
                Position = "Director",
                ContactInfo = new ContactInformation
                {
                    Phone = "+7 (3412) 59-61-38",
                    Email = "alexndrv@mail.ru",
                    Skype = "elsalexandrv",
                    Other = "Lorem ipsum"
                }
            });

            dataBase.Contacts.Add(new Contact
            {
                Surname = "Борисов",
                Name = "Борис",
                Patronymic = "Борисович",
                BirthDate = "1997-10-03",
                Organization = "Other Random Organization",
                Position = "Manager",
                ContactInfo = new ContactInformation
                {
                    Phone = "+7 (3412) 59-61-38",
                    Email = "brsv.brsv@gmail.com",
                    Skype = "brsvbrsbrsvch",
                    Other = "Dolor sit amet"
                }
            });

            dataBase.Contacts.Add(new Contact
            {
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                BirthDate = "1901-08-08",
                Organization = "Рандомная организация",
                Position = "Менеджер по клинингу",
                ContactInfo = new ContactInformation
                {
                    Phone = "+7 (951) 928-10-88",
                    Email = "ivanovivanivanovich@yandex.ru",
                    Skype = "ivanovivanivanch",
                    Other = "consectetur adipiscing elit"
                }
            });

            base.Seed(dataBase);
        }
    }
}