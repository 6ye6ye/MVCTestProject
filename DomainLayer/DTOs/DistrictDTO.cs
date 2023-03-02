using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Dtos
{
    public class DistrictDtoGet
    {
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
