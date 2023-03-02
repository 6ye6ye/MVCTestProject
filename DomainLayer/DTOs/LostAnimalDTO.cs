using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DomainLayer.Models;

namespace DomainLayer.Dtos
{
    public class LostAnimalDtoGetShort
    {
        public Guid Id { get; set; }

        [Display(Name = "Вид животного")]
        public AnimalTypeEnum AnimalType { get; set; }

        [Required]
        [Display(Name = "Кличка")]
        public string? AnimalName { get; set; }

        [Display(Name = "Подробная информация")]
        public string? Info { get; set; }

        [Display(Name = "Район")]
        public DistrictDtoGet District { get; set; }

        [Display(Name = "Дата потери")]
        [DataType(DataType.Date)]
        public DateTime LostDate { get; set; }
    }

    public class LostAnimalDtoGetFull : LostAnimalDtoGetShort
    {
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }

    public class LostAnimalDtoAdd
    {
        public Guid Id { get; set; }

        [Display(Name = "Вид животного")]
        public AnimalTypeEnum AnimalType { get; set; }

        [Required]
        [Display(Name = "Кличка")]
        public string? AnimalName { get; set; }

        [Display(Name = "Подробная информация")]
        public string? Info { get; set; }

        [Display(Name = "Район")]
        public Guid? DistrictId { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Дата потери")]
        [DataType(DataType.Date)]
        public DateTime LostDate { get; set; }
    }
}
