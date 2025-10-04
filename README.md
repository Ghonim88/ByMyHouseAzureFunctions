# ByMyHouse Application

## Overview
**ByMyHouse** is a demo project that simulates mortgage application processing using:

- **ASP.NET Core Web API**: Handles mortgage applications (create, read).  
- **Azure Functions**: Processes applications asynchronously with a **TimerTrigger** and a **QueueTrigger**.  
- **In-Memory DAL (Data Access Layer)**: Stores mortgage application data for demo purposes.  

This project demonstrates the end-to-end flow of data, queue-based processing, and API exposure without needing a real database.

---
```
## Project Structure

ByMyHouse_Assignment/
├─ ByMyHouse.Api/                  # ASP.NET Core Web API project
│  ├─ Controllers/
│  │  └─ MortgageController.cs     # Handles HTTP requests for mortgage applications
│  ├─ Models/
│  │  ├─ MortgageApplication.cs    # Mortgage application data structure
│  │  └─ House.cs                  # House data structure
│  ├─ DAL/
│  │  ├─ IMortgageApplicationDAL.cs
│  │  ├─ MortgageApplicationDAL.cs # In-memory storage for mortgage applications
│  │  ├─ IHousesDAL.cs
│  │  └─ HousesDAL.cs              # In-memory storage for houses
│  ├─ DTOs/
│  │  └─ ApplicationResponse.cs    # DTOs for API responses
│  ├─ AppJsonSerializerContext.cs  # System.Text.Json source generation context
│  ├─ Program.cs                   # Configures API, DI, and Swagger
│  └─ Properties/
│     └─ launchSettings.json       # Launch profiles for local development
│
└─ BuyMyHouse.Functions/           # Azure Functions project
   ├─ ProcessMortgageOffers.cs     # TimerTrigger: reads applications and sends to queue
   ├─ SendMortgageEmail.cs         # QueueTrigger: processes messages from the queue
   ├─ Program.cs                   # Configures DI for the DAL
   └─ local.settings.json          # Local settings for Azure Functions
```
---

## Features Implemented

### 1. Web API
- **Endpoints via `MortgageController`:**
  - `GET /api/mortgage` → Returns all mortgage applications.
  - `POST /api/mortgage/apply` → Creates a new mortgage application.  

- **Swagger UI** enabled:
  - URL: `http://localhost:5146/swagger/index.html`
  - Allows testing endpoints interactively.

- **Data Layer**:  
  - Uses `MortgageApplicationDAL` for storing sample mortgage applications in memory.  
  - Pre-populated with multiple test applications for demonstration.

---

### 2. Azure Functions
- **ProcessMortgageOffers** (TimerTrigger)
  - Executes every 3 seconds (for testing)  
  - Reads all mortgage applications from the DAL  
  - Serializes them to JSON and sends to Azure Storage Queue (`mortgage-offers-queue`)  

- **SendMortgageEmail** (QueueTrigger)
  - Triggered when a message arrives in the queue  
  - Deserializes message and logs processing of the mortgage application  

- **Dependency Injection**
  - Both functions use the same in-memory DAL to simulate shared data access.

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022/2023](https://visualstudio.microsoft.com/) or VS Code
- [Azurite](https://github.com/Azure/Azurite) (Local Azure Storage Emulator)
