using BuyMyHouse.Api.Models;
using System.Collections.Generic;

namespace BuyMyHouse.Api.DAL
{
    public interface IMortgageApplicationDAL
    {
        IEnumerable<MortgageApplication> GetAll();
        MortgageApplication GetById(int id);
        MortgageApplication Create(MortgageApplication application);
        void UpdateStatus(int id, string status);
    }
}
