using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkwaylabsExercise2.BusinessLogic.Interfaces;

namespace ParkwaylabsExercise2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Developer_TechnologyController : ControllerBase
    {
        internal IDeveloper_TechnologyManager _developer_TechnologyManager;

        public Developer_TechnologyController(IDeveloper_TechnologyManager developer_TechnologyManager)
        {
            _developer_TechnologyManager = developer_TechnologyManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _developer_TechnologyManager.GetDeveloperByTechnology("Tech1");

            if (response != null || response.Count != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }
    }
}
