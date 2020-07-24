using System.ComponentModel.DataAnnotations;

namespace ContactListApp.Models
{
    /// <summary>
    /// Модель контактной информации.
    /// </summary>
    public class ContactInformation
    {
        /// <summary>
        /// Телефон.
        /// </summary>
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Скайп.
        /// </summary>
        [StringLength(32, MinimumLength = 6)]
        public string Skype { get; set; }

        /// <summary>
        /// Другое.
        /// </summary>
        [StringLength(100, MinimumLength = 1)]
        public string Other { get; set; }

        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns>Строковое представление модели контактной информации.</returns>
        public override string ToString()
        {
            return this.Phone + this.Email + this.Skype + this.Other;
        }
    }
}