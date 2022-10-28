using Leasy.API.Reports.Domain.Models;

namespace Leasy.API.Reports.Domain.Repositories;

public interface IReportRepository
{
    Task<IEnumerable<Report>> ListAsync();
    Task AddAsync(Report report);
    Task<Report> FindByIdAsync(int id);
    void Update(Report report);
    void Remove(Report report);
}