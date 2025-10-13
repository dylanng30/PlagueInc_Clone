using Refactor_01.Domain.Entities;
using Refactor_01.Data.StaticData;

namespace Refactor_01.Domain.Factories
{
    public class CountryFactory
    {
        public CountryModel Create(CountrySO data)
        {
            return new CountryModel(data.Img, data.ID, data.Name, data.Population);
        }
    }

}
