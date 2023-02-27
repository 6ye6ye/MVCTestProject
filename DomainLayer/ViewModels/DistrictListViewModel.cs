using DomainLayer.Dtos;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomainLayer.ViewModels
{
    public class DistrictListViewModel 
    {
        [Display(Name = "Наименование")]
        public IEnumerable<District> Districts { get; set; }
    }
}
