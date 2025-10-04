using BuyMyHouse.Api.DTOs;
using BuyMyHouse.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuyMyHouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MortgageController : ControllerBase
    {
        // In-memory store for demo purposes
        private static readonly List<MortgageApplication> Applications = new();

        [HttpPost("apply")]
        public IActionResult Apply([FromBody] MortgageApplication application)
        {
            application.Id = Applications.Count + 1;
            application.SubmittedOn = DateTime.UtcNow;

            Applications.Add(application);

            return Ok(new ApplicationResponse
            {
                Message = "Application received",
                ApplicationId = application.Id
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Applications);
        }
    }
}