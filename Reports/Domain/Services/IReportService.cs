using Leasy.API.Reports.Domain.Models;
using Leasy.API.Reports.Domain.Services.Communication;

namespace Leasy.API.Reports.Domain.Services;

public interface IReportService
{
    Task<IEnumerable<Report>> ListAsync();
    Task<ReportResponse> GetById(int id);
    Task<ReportResponse> SaveAsync(Report report);
    Task<ReportResponse> UpdateAsync(int id, Report report);
    Task<ReportResponse> DeleteAsync(int id);
}