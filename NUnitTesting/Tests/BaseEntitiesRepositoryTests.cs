using AutoMapper;
using BLL.Mappings;
using BLL.Repository;
using DomainLayer.Models;
using Moq;
using System.Linq.Expressions;

namespace NUnitTesting
{
    public abstract class BaseEntitiesRepositoryTest<TEntity> where TEntity : class, IBaseEntity
    {
        private protected IMapper mapper;
        private protected Mock<IRepository<TEntity>> repository;
        private protected readonly List<TEntity> _defaultItemsList;
        private protected readonly TEntity _defaultItem;

        public abstract IEnumerable<TEntity> GetTestItems();
        public abstract TEntity GetTestItem();

        public BaseEntitiesRepositoryTest()
        {
            _defaultItemsList = GetTestItems().ToList();
            _defaultItem = GetTestItem();
        }

        [SetUp]
        public void SetupRepository()
        {
            repository = new Mock<IRepository<TEntity>>();
            repository.Setup(mr => mr.GetAll()).Returns(_defaultItemsList);

            repository.Setup(mr => mr.GetById(
                It.IsAny<Guid>())).Returns((Guid i) => _defaultItemsList.Where(
                x => x.Id == i).FirstOrDefault());

            repository.Setup(mr => mr.FirstOrDefault(
                It.IsAny<Expression<Func<TEntity, bool>>>())).Returns((Expression<Func<TEntity, bool>> i) => _defaultItemsList.FirstOrDefault(
                i.Compile()));

            repository.Setup(mr => mr.GetByIdAsync(
                It.IsAny<Guid>())).ReturnsAsync((Guid i) => _defaultItemsList.Find(
                x => x.Id == i));

            repository.Setup(mr => mr.FirstOrDefaultAsync(
                It.IsAny<Expression<Func<TEntity, bool>>>())).ReturnsAsync((Expression<Func<TEntity, bool>> i) => _defaultItemsList.FirstOrDefault(
                i.Compile()));
        }

        [SetUp]
        public void SetupMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = mockMapper.CreateMapper();
        }

        [Test]
        public void Repository_GetAll()
        {
            repository.Object.GetAll();
            repository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void Repository_Create()
        {
            repository.Object.Create(_defaultItem);
            repository.Verify(x => x.Create(_defaultItem), Times.Once);
        }

        [Test]
        public void Repository_Delete()
        {
            repository.Object.Delete(_defaultItem.Id);
            repository.Verify(x => x.Delete(_defaultItem.Id), Times.Once);
        }

        [Test]
        public void Repository_Any()
        {
            repository.Object.Any(x => x.Id == new Guid());
            repository.Verify(x => x.Any(x => x.Id == new Guid()), Times.Once);
        }

        [Test]
        public void Repository_Update()
        {
            repository.Object.Update(_defaultItem);
            repository.Verify(x => x.Update(_defaultItem), Times.Once);
        }

        [Test]
        public void Repository_GetById()
        {
            repository.Object.GetById(_defaultItem.Id);
            repository.Verify(x => x.GetById(_defaultItem.Id), Times.Once);
        }

        [Test]
        public async Task Repository_GetByIdAsync()
        {
            var id = new Guid();
            await repository.Object.GetByIdAsync(id);
            repository.Verify(x => x.GetByIdAsync(id), Times.Once);
        }
    }
}