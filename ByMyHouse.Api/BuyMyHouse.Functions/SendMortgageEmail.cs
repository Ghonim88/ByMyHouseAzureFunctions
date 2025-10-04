using System;
using System.Text;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using BuyMyHouse.Api.Models;

namespace BuyMyHouse.Functions
{
    public class SendMortgageEmail
    {
        private readonly ILogger<SendMortgageEmail> _logger;

        public SendMortgageEmail(ILogger<SendMortgageEmail> logger)
        {
            _logger = logger;
        }

        [Function("SendMortgageEmail")]
        public void Run([QueueTrigger("mortgage-offers-queue", Connection = "AzureWebJobsStorage")] string queueMessage)
        {
            var application = JsonSerializer.Deserialize<MortgageApplication>(queueMessage);
            _logger.LogInformation($"Processing mortgage offer for {application.ApplicantName} (ID: {application.Id})");
        }
    }
}
