using BuyMyHouse.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace BuyMyHouse.Api.DAL
{
    public class MortgageApplicationDAL : IMortgageApplicationDAL
    {
        private readonly List<MortgageApplication> _applications;

        public MortgageApplicationDAL()
        {
            _applications = new List<MortgageApplication>
    {
        new MortgageApplication
        {
            Id = 1,
            ApplicantName = "Abdelrahman Ghonim",
            Income = 60000,
            LoanAmount = 150000,
            SubmittedOn = DateTime.UtcNow,
            Status = "Pending"
        },
        new MortgageApplication
        {
            Id = 2,
            ApplicantName = "Alice Johnson",
            Income = 75000,
            LoanAmount = 200000,
            SubmittedOn = DateTime.UtcNow,
            Status = "Pending"
        },
        new MortgageApplication
        {
            Id = 3,
            ApplicantName = "Bob Smith",
            Income = 50000,
            LoanAmount = 120000,
            SubmittedOn = DateTime.UtcNow,
            Status = "Pending"
        },
        new MortgageApplication
        {
            Id = 4,
            ApplicantName = "Carol White",
            Income = 90000,
            LoanAmount = 250000,
            SubmittedOn = DateTime.UtcNow,
            Status = "Pending"
        }
    };
        }

        public IEnumerable<MortgageApplication> GetAll() => _applications;

        public MortgageApplication? GetById(int id) => _applications.FirstOrDefault(a => a.Id == id);

        public MortgageApplication Create(MortgageApplication application)
        {
            application.Id = _applications.Count + 1;
            application.SubmittedOn = DateTime.UtcNow;
            application.Status = "Pending";
            _applications.Add(application);
            return application;
        }

        public void UpdateStatus(int id, string status)
        {
            var app = _applications.FirstOrDefault(a => a.Id == id);
            if (app != null) app.Status = status;
        }
    }
}