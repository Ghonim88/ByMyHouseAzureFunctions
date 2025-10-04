using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Storage.Queues;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using BuyMyHouse.Api.Models;
using BuyMyHouse.Api.DAL;

namespace BuyMyHouse.Functions
{
    public class ProcessMortgageOffers
    {
        private readonly ILogger _logger;
        private readonly IMortgageApplicationDAL _dal;

        // Constructor with DI for DAL and Logger
        public ProcessMortgageOffers(IMortgageApplicationDAL dal, ILoggerFactory loggerFactory)
        {
            _dal = dal ?? throw new ArgumentNullException(nameof(dal));
            _logger = loggerFactory.CreateLogger<ProcessMortgageOffers>();
        }

        [Function("ProcessMortgageOffers")]
        public void Run([TimerTrigger("*/3 * * * * *")] TimerInfo myTimer) // every 3 seconds for testing
        {
            try
            {
                _logger.LogInformation($"Mortgage batch job triggered at: {DateTime.UtcNow}");

                // Get all mortgage applications from DAL
                var applications = _dal.GetAll();

                if (applications == null || !applications.Any())
                {
                    _logger.LogInformation("No mortgage applications found in DAL.");
                    return;
                }

                // Get connection string from environment
                var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    _logger.LogError("AzureWebJobsStorage connection string is not set.");
                    return;
                }

                var queueClient = new QueueClient(connectionString, "mortgage-offers-queue");
                queueClient.CreateIfNotExists();

                foreach (var app in applications)
                {
                    // Serialize to JSON
                    var messageJson = JsonSerializer.Serialize(app);
                    var messageBytes = Encoding.UTF8.GetBytes(messageJson);
                    var base64Message = Convert.ToBase64String(messageBytes);

                    // Send message to queue
                    queueClient.SendMessage(base64Message);
                    _logger.LogInformation($"Mortgage application {app.Id} sent to queue for applicant {app.ApplicantName}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing mortgage applications.");
                throw; // Rethrow to let Functions runtime handle retries
            }
        }
    }
}
