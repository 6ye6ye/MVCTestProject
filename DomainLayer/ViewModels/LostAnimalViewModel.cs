using DomainLayer.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DomainLayer.ViewModels;

public class LostAnimalViewModelGetFull
{
    public LostAnimalDtoGetFull LostAnimal { get; set; }

    public LostAnimalViewModelGetFull(LostAnimalDtoGetFull lostAnimal)
    {
        LostAnimal = lostAnimal;
    }
}

public class LostAnimalViewModelAdd
{
    public LostAnimalDtoAdd LostAnimal { get; set; }

    public SelectList? AnimalTypeList { get; set; }
    public SelectList? DistrictList { get; set; }

    public LostAnimalViewModelAdd(LostAnimalDtoAdd lostAnimal)
    {
        LostAnimal = lostAnimal;
    }

    public LostAnimalViewModelAdd()
    {
    }
}