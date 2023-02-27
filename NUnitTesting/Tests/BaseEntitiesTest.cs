using AutoMapper;
using BLL.Mappings;
using BLL.Repository;
using BLL.UnitOfWorks;
using DomainLayer.Models;
using Moq;
using System.Linq;
using System.Linq.Expressions;

namespace NUnitTesting
{
    public abstract class BaseEntitiesTest<TEntity> where TEntity : BaseEntity
    {
        private protected IMapper mapper;
        private protected Mock<IUnitOfWork> unitOfWork;
        private protected Mock<IRepository<TEntity>> repository;
        private protected readonly List<TEntity> _defaultItemsList;
        private protected readonly TEntity _defaultItem;

        public abstract IEnumerable<TEntity> GetTestItems();
        public abstract TEntity GetTestItem();

        public BaseEntitiesTest()
        {
            _defaultItemsList = GetTestItems().ToList();
            _defaultItem = GetTestItem();
        }

        [SetUp]
        public void Setup()
        {
            repository = new Mock<IRepository<TEntity>>();
            unitOfWork = new Mock<IUnitOfWork>();

            repository.Setup(mr => mr.GetAll()).Returns(_defaultItemsList);

            repository.Setup(mr => mr.GetById(
                It.IsAny<Guid>())).Returns((Guid i) => _defaultItemsList.Where(
                x => x.Id == i).FirstOrDefault());

            repository.Setup(mr => mr.FirstOrDefault(
                It.IsAny<Expression<Func<TEntity, bool>>>())).Returns((Expression<Func<TEntity, bool>> i) => _defaultItemsList.FirstOrDefault(
                i.Compile()) as TEntity);

            repository.Setup(mr => mr.GetByIdAsync(
                It.IsAny<Guid>())).ReturnsAsync((Guid i) => _defaultItemsList.Find(
                x => x.Id == i) as TEntity);

            repository.Setup(mr => mr.FirstOrDefaultAsync(
                It.IsAny<Expression<Func<TEntity, bool>>>())).ReturnsAsync((Expression<Func<TEntity, bool>> i) => _defaultItemsList.FirstOrDefault(
                i.Compile()) as TEntity);


            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = mockMapper.CreateMapper();

            SetupCustom();
        }

        public virtual void SetupCustom(){}

        [Test]
        public void GetAll()
        {
            repository.Object.GetAll();
            repository.Verify(x => x.GetAll(), Times.Once);
        }

        //[Test]
        //public void FirstOrDefault_Contains()
        //{
        //    var id = new Guid();
        //    var item = repository.Object.FirstOrDefault(d => d.Id == id);

        //    Assert.IsNotNull(item);
        //    Assert.That(item.Id, Is.EqualTo(_defaultItemsList[0].Id));
        //    Assert.That(item.Id, Is.EqualTo(id));
        //}

        //[Test]
        //public void FirstOrDefault_NotContains()
        //{
        //    var id = Guid.NewGuid();
        //    var item = repository.Object.FirstOrDefault(d => d.Id == id);

        //    Assert.IsNull(item);
        //}

        [Test]
        public void Create()
        {
            repository.Object.Create(_defaultItem);
            repository.Verify(x => x.Create(_defaultItem), Times.Once);
        }

        [Test]
        public void Delete()
        {
            repository.Object.Delete(_defaultItem.Id);
            repository.Verify(x => x.Delete(_defaultItem.Id), Times.Once);
        }

        [Test]
        public void Any()
        {
            repository.Object.Any(x => x.Id == new Guid());
            repository.Verify(x => x.Any(x => x.Id == new Guid()), Times.Once);
        }

        [Test]
        public void Update()
        {
            repository.Object.Update(_defaultItem);
            repository.Verify(x => x.Update(_defaultItem), Times.Once);
        }

        [Test]
        public void GetById()
        {
            repository.Object.GetById(_defaultItem.Id);
            repository.Verify(x => x.GetById(_defaultItem.Id), Times.Once);
        }

        [Test]
        public async Task GetByIdAsync()
        {
            var id = new Guid();
            await repository.Object.GetByIdAsync(id);
            repository.Verify(x => x.GetByIdAsync(id), Times.Once);
        }
    }
}