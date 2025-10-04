using BuyMyHouse.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace BuyMyHouse.Api.DAL
{
    public class HousesDAL : IHousesDAL
    {
        private readonly List<House> _houses;

        public HousesDAL()
        {
            _houses = new List<House>();
            _houses.Add(new House { Id = 1, Address = "123 Main St", Price = 250000, Size = 120, NumRooms = 3 });
        }

        public IEnumerable<House> GetAll() => _houses;

        public House GetById(int id) => _houses.FirstOrDefault(h => h.Id == id)!;

        public House Create(House house)
        {
            house.Id = _houses.Count + 1;
            _houses.Add(house);
            return house;
        }
    }
}
