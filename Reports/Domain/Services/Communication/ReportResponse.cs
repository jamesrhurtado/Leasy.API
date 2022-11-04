using Leasy.API.Reports.Domain.Models;
using Leasy.API.Shared.Domain.Services.Communication;

namespace Leasy.API.Reports.Domain.Services.Communication;


public class ReportResponse : BaseResponse<Report>
{
    public ReportResponse(Report resource) : base(resource)
    {
    }

    public ReportResponse(string message) : base(message)
    {
    }
}