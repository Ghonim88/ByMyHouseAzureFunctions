namespace BuyMyHouse.Api.Models
{
    public class House
    {
            public int Id { get; set; }
            public string Address { get; set; } = null!;
            public decimal Price { get; set; }
            public int Size { get; set; }
            public int NumRooms { get; set; }
     
    }
}
