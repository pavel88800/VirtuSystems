using System;
using System.ComponentModel.DataAnnotations;

namespace VirtuSystemsApp.DB.Models
{
    public class User
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     ФИО
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     День рождения
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        /// <summary>
        ///     Телефон
        /// </summary>
        public string Phone { get; set; }
    }
}