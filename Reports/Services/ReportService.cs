using Leasy.API.Reports.Domain.Models;
using Leasy.API.Reports.Domain.Repositories;
using Leasy.API.Reports.Domain.Services;
using Leasy.API.Reports.Domain.Services.Communication;
using Leasy.API.Shared.Domain.Repositories;

namespace Leasy.API.Reports.Services;

public class ReportService: IReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReportService(IReportRepository reportRepository, IUnitOfWork unitOfWork)
    {
        _reportRepository = reportRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Report>> ListAsync()
    {
        return await _reportRepository.ListAsync();
    }

    public async Task<ReportResponse> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ReportResponse> SaveAsync(Report report)
    {
        try
        {
            await _reportRepository.AddAsync(report);
            await _unitOfWork.CompleteAsync();

            return new ReportResponse(report);
        }
        catch(Exception e)
        {
            return new ReportResponse($"An error occurred while saving the report: {e.Message}");
        }
    }

    public async Task<ReportResponse> UpdateAsync(int id, Report report)
    {
        var existingReport = await _reportRepository.FindByIdAsync(id);

        if (existingReport == null)
        {
            return new ReportResponse("Report not found.");
        }

        existingReport.AssetPrice = report.AssetPrice;
        existingReport.LeasingTime = report.LeasingTime;
        existingReport.PaymentFrequency = report.PaymentFrequency;
        existingReport.RateType = report.RateType;
        existingReport.RateValue = report.RateValue;
        existingReport.Capitalization = report.Capitalization;
        existingReport.BuybackPercentage = report.BuybackPercentage;
        existingReport.NotaryFees = report.NotaryFees;
        existingReport.RegistryFees = report.RegistryFees;
        existingReport.Valuation = report.Valuation;
        existingReport.StudyCommission = report.StudyCommission;
        existingReport.ActivationCommission = report.ActivationCommission;
        existingReport.RegularCommission = report.RegularCommission;
        existingReport.RiskInsurancePercentage = report.RiskInsurancePercentage;
        existingReport.DiscountRateKs = report.DiscountRateKs;
        existingReport.DiscountRateWacc = report.DiscountRateWacc;

        try
        {
            _reportRepository.Update(existingReport);
            await _unitOfWork.CompleteAsync();

            return new ReportResponse(existingReport);
        }
        catch(Exception e)
        {
            return new ReportResponse($"An error occurred while updating the report: {e.Message}");
        }
        

    }

    public async Task<ReportResponse> DeleteAsync(int id)
    {
        var existingReport = await _reportRepository.FindByIdAsync(id);
        if (existingReport == null)
            return new ReportResponse("Report not found");
        try
        {
            _reportRepository.Remove(existingReport);
            await _unitOfWork.CompleteAsync();
            return new ReportResponse(existingReport);
        }
        catch (Exception e)
        {
            return new ReportResponse($"An error occurred while deleting the report: {e.Message}");
        }
    }
}