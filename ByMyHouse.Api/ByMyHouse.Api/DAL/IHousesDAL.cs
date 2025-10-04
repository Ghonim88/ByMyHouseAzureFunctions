using BuyMyHouse.Api.Models;

namespace BuyMyHouse.Api.DAL
{
    public interface IHousesDAL
    {
        IEnumerable<House> GetAll();
        House GetById(int id);
        House Create(House house);
    }
}
