using Leasy.API.Users.Domain.Models;

namespace Leasy.API.Reports.Domain.Models;

public class Report
{
    public int Id { get; set; }
    public decimal AssetPrice { get; set; } 
    public int LeasingTime { get; set; }
    public string PaymentFrequency { get; set; }
    public string RateType { get; set; }
    public decimal RateValue { get; set; }
    public string Capitalization { get; set; }
    public decimal BuybackPercentage { get; set; }
    public decimal NotaryFees { get; set; }
    public decimal RegistryFees { get; set; }
    public decimal Valuation { get; set; }
    public decimal StudyCommission { get; set; }
    public decimal ActivationCommission { get; set; }
    public decimal RegularCommission { get; set; }
    public decimal RiskInsurancePercentage { get; set; }
    public decimal DiscountRateKs { get; set; }
    public decimal DiscountRateWacc {get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}