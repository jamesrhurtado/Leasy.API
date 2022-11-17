namespace Leasy.API.Reports.Resources;

public class ReportResource
{
    public int Id { get; set; }
    public decimal AssetPrice { get; set; } 
    public int LeasingYears { get; set; }
    public string PaymentFrequency { get; set; }
    public string RateType { get; set; }
    public decimal RateValue { get; set; }
    public string RateFrequency { get; set; }
    public string Capitalization { get; set; }
    public decimal Buyback { get; set; }
    public decimal NotaryFees { get; set; }
    public decimal RegistryFees { get; set; }
    public decimal Valuation { get; set; }
    public decimal StudyCommission { get; set; }
    public decimal ActivationCommission { get; set; }
    public decimal RegularCommission { get; set; }
    public decimal RiskInsurance { get; set; }
    public decimal RateKs { get; set; }
    public decimal RateWacc {get; set; }
}