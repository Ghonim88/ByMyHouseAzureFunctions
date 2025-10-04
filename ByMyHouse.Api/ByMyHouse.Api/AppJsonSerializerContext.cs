using BuyMyHouse.Api.DTOs; // Ensure this using is present if ApplicationResponse is in DTOs
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BuyMyHouse.Api.Models;

namespace BuyMyHouse.Api
{
    [JsonSerializable(typeof(ApplicationResponse))]
    [JsonSerializable(typeof(List<MortgageApplication>))] // <-- Add this line
    [JsonSerializable(typeof(List<House>))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext 
    {
    }
}