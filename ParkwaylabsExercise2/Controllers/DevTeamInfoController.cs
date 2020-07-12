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
    public class DevTeamInfoController : ControllerBase
    {
        internal IDeveloper_TechnologyManager _developer_TechnologyManager;
        internal ITechLead_TechnologyManager _techLead_TechnologyManager;

        public DevTeamInfoController(IDeveloper_TechnologyManager developer_TechnologyManager,
            ITechLead_TechnologyManager techLead_TechnologyManager)
        {
            _developer_TechnologyManager = developer_TechnologyManager;
            _techLead_TechnologyManager = techLead_TechnologyManager;
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

        [HttpGet]
        [Route("GetDeveloperByTechnology/{technologyName?}")]
        public async Task<IActionResult> GetDeveloperByTechnology(string technologyName)
        {
            var response = await _developer_TechnologyManager.GetDeveloperByTechnology(technologyName);

            if (response != null || response.Count != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("GetExperiencedTechLeadByTechnology/{technologyName?}")]
        public async Task<IActionResult> GetExperiencedTechLeadByTechnology(string technologyName)
        {
            var response = await _techLead_TechnologyManager.GetExperiencedTechLeadByTechnology(technologyName);

            if (response != null || response.Count != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("GetExperiencedTechLeadByDeveloperTechnology/{developerId?}/{technologyId?}")]
        public async Task<IActionResult> GetExperiencedTechLeadByDeveloperTechnology(int developerId, int technologyId)
        {
            var response = await _techLead_TechnologyManager.GetExperiencedTechLeadByDeveloperTechnology(developerId, technologyId);

            if (response != null || response.Count != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }

    }
}
