using Inc.MyFamily.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inc.MyFamily.Api.Interfaces
{
    public interface IActionResultConverter
    {
        IActionResult Convert<T>(UseCaseResponse<T> response, bool noContentIfSuccess = false);
    }
}
