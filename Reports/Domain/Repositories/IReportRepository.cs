using Leasy.API.Reports.Domain.Models;

namespace Leasy.API.Reports.Domain.Repositories;

public interface IReportRepository
{
    Task<IEnumerable<Report>> ListAsync();
    Task AddAsync(Report report);
    Task<Report> FindByIdAsync(int id);
    Task<IEnumerable<Report>> ListByUserIdAsync(int userId);
    void Update(Report report);
    void Remove(Report report);
}