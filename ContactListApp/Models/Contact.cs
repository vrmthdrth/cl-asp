using System.ComponentModel.DataAnnotations;

namespace ContactListApp.Models
{
    /// <summary>
    /// Модель контакта.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int? ContactId { get; set; } 

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Требуется заполнить поле Surname")]
        [StringLength(50, MinimumLength = 1)]
        public string Surname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Требуется заполнить поле Name")]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [StringLength(50, MinimumLength = 1)]
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string BirthDate { get; set; }

        /// <summary>
        /// Организация.
        /// </summary>
        [StringLength(50, MinimumLength = 1)]
        public string Organization { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [StringLength(50, MinimumLength = 1)]
        public string Position { get; set; }

        /// <summary>
        /// Контактная информация.
        /// </summary>
        public ContactInformation ContactInfo { get; set; }

        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns>Строковое представление модели.</returns>
        public override string ToString()
        {
            return this.Surname + this.Name + this.Patronymic + this.BirthDate + this.Organization + this.Position + this.ContactInfo.ToString();
        }
    }
}