using Inc.MyFamily.Api.Interfaces;
using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Inc.MyFamily.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ChildrenContoller : ControllerBase
    {
        public readonly IGetAllChildrenByFamilyIdUseCase _GetAllChildrenByFamilyIdUseCase;
        public readonly IActionResultConverter _ActionResultConverter;

        public ChildrenContoller(IGetAllChildrenByFamilyIdUseCase getAllChildrenByFamilyIdUseCase, IActionResultConverter actionResultConverter)
        {
            _GetAllChildrenByFamilyIdUseCase = getAllChildrenByFamilyIdUseCase;
            _ActionResultConverter = actionResultConverter;
        }

        [ProducesResponseType(typeof(List<Children>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllChildrenByFamilyIdUseCase(int familyId)
        {
            var response = await _GetAllChildrenByFamilyIdUseCase.Execute(familyId);
            return _ActionResultConverter.Convert(response);
        }

    }
}
