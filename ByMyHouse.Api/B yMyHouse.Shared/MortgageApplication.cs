namespace BuyMyHouse.Shared
{
    public class MortgageApplication
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public decimal Income { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
        public string OfferFilePath { get; set; } = string.Empty; // Blob path for offer

    }
}
