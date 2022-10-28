using Leasy.API.Reports.Domain.Models;
using Leasy.API.Reports.Domain.Repositories;
using Leasy.API.Shared.Persistence.Contexts;
using Leasy.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leasy.API.Reports.Persistence.Repositories;

public class ReportRepository: BaseRepository, IReportRepository
{
    public ReportRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Report>> ListAsync()
    {
        return await _context.Reports.ToListAsync();
    }

    public async Task AddAsync(Report report)
    {
        await _context.Reports.AddAsync(report);
    }

    public async Task<Report> FindByIdAsync(int id)
    {
        return await _context.Reports.FindAsync(id);
    }

    public void Update(Report report)
    {
        _context.Reports.Update(report);
    }

    public void Remove(Report report)
    {
        _context.Reports.Remove(report);
    }
}