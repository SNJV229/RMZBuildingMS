using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMZBuildingMS.Authentication;
using RMZBuildingMS.Models;
using RMZBuildingMS.Repository;

namespace RMZBuildingMS.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class RMZController : ControllerBase
    {
        private readonly RMZContext _context;
        private readonly IGetInfo _repository;

        public RMZController(RMZContext context, IGetInfo repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetActionResult(string str, DateTime startDate, DateTime endDate)
        {
            var result = _repository.getAtLevel(str, startDate, endDate);
            return Ok(result);
        }
    }
}
