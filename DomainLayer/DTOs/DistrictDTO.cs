using DomainLayer.Enums;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomainLayer.Dtos
{
    public class DistrictDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
