using DomainLayer.Models;

namespace NUnitTesting.Tests
{
    public class DistrictTests : BaseEntitiesRepositoryTest<District>
    {
        public override District GetTestItem()
        {
            return new District()
            {
                Id = new Guid("AAAAAAAA-1111-1111-1111-111111111111"),
                Name = "Test",
            };
        }

        public override IEnumerable<District> GetTestItems()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new District { Name = "Test District " + i };
            }
        }
    }
}