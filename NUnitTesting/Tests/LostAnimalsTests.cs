using Microsoft.AspNetCore.Mvc;
using AnimalFinder.Controllers;
using DomainLayer.Dtos;
using DomainLayer.Models;
using DomainLayer.ViewModels;
using BLL.UnitOfWorks;
using Moq;

namespace NUnitTesting.Tests
{
    public class LostAnimalTesting : BaseEntitiesRepositoryTest<LostAnimal>
    {
        private protected Mock<IUnitOfWork> unitOfWork;

        public override LostAnimal GetTestItem()
        {
            return new LostAnimal()
            {
                Id = new Guid("AAAAAAAA-1111-1111-1111-111111111111"),
                AnimalName = "Test",
                AnimalType = DomainLayer.Enums.AnimalTypeEnum.Cat,
                LostDate = DateTime.Now,
                Phone = "0555555",
                PhotoPath = "",
                DistrictId = new Guid(),
                Info = " info "
            };
        }

        public override IEnumerable<LostAnimal> GetTestItems()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new LostAnimal {
                    Id = new Guid("AAAAAAAA-0000-0000-0000-00000000000" + i),
                    AnimalName = "Test Animal " + i 
                };
            }
        }

        [SetUp]
        public void Setup_UnitOfWork()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.LostAnimals).Returns(repository.Object);
        }

        [Test]
        public void Controller_Index()
        {
            var controller = new LostAnimalsController(unitOfWork.Object, mapper);
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<LostAnimalListViewModel>(result.Model);

            var model = result.Model as LostAnimalListViewModel;

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.LostAnimals);
            Assert.That(model.LostAnimals.Count(), Is.EqualTo(_defaultItemsList.Count()));
        }

        [Test]
        public void Controller_Details_NotFound()
        {
            var orderController = new LostAnimalsController(unitOfWork.Object, mapper);
            var result = orderController.Details(_defaultItem.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
            var statusCodeResult = result.Result as NotFoundResult;
            Assert.That(statusCodeResult?.StatusCode, Is.EqualTo(404));
        }

        [Test]
        public void Controller_Details()
        {
            var controller = new LostAnimalsController(unitOfWork.Object, mapper);
            var expectedLostAnimal = _defaultItemsList[0];
            var viewModel = new LostAnimalViewModelGetFull(mapper.Map<LostAnimalDtoGetFull>(expectedLostAnimal));
            
            var taskActionResult = controller.Details(expectedLostAnimal.Id);
            Assert.IsNotNull(taskActionResult);
            var viewResult = taskActionResult.Result as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOf<LostAnimalViewModelGetFull>(viewResult.Model);

            var actualLostAnimalViewModel = viewResult.Model as LostAnimalViewModelGetFull;

            Assert.IsNotNull(actualLostAnimalViewModel);
            Assert.Multiple(() =>
            {
                Assert.That(actualLostAnimalViewModel.LostAnimal.Id, Is.EqualTo(viewModel.LostAnimal.Id));
                Assert.That(actualLostAnimalViewModel.LostAnimal.AnimalName, Is.EqualTo(viewModel.LostAnimal.AnimalName));
                Assert.That(actualLostAnimalViewModel.LostAnimal.AnimalType, Is.EqualTo(viewModel.LostAnimal.AnimalType));
                Assert.That(actualLostAnimalViewModel.LostAnimal.LostDate, Is.EqualTo(viewModel.LostAnimal.LostDate));
                Assert.That(actualLostAnimalViewModel.LostAnimal.Phone, Is.EqualTo(viewModel.LostAnimal.Phone));
                Assert.That(actualLostAnimalViewModel.LostAnimal.District, Is.EqualTo(viewModel.LostAnimal.District));
            });
        }

        [Test]
        public void Controller_Create()
        {
            var controller = new LostAnimalsController(unitOfWork.Object, mapper);
            var expectedLostAnimal = _defaultItem;
            var viewModel = mapper.Map<LostAnimalViewModelAdd>(expectedLostAnimal);

            var result = controller.Create(viewModel);
            var viewResult = result.Result as RedirectToActionResult;

            Assert.IsNotNull(viewResult);
            Assert.That(viewResult.ActionName, Is.EqualTo("Index"));
        }
    }
}