﻿using System;
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
        internal IDeveloperTechnologyManager developerTechnologyManager;
        internal ITechLeadTechnologyManager techLeadTechnologyManager;

        public DevTeamInfoController(IDeveloperTechnologyManager developerTechnologyManager,
            ITechLeadTechnologyManager techLeadTechnologyManager)
        {
            this.developerTechnologyManager = developerTechnologyManager;
            this.techLeadTechnologyManager = techLeadTechnologyManager;
        }

        /// <summary>
        /// Task 01: Most experienced developers by technology
        /// </summary>
        /// <param name="technologyName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDeveloperByTechnology/{technologyName?}")]
        public async Task<IActionResult> GetDeveloperByTechnology(string technologyName)
        {
            var response = await developerTechnologyManager.GetDeveloperByTechnology(technologyName);
            if (response != null && response.Count != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }

        /// <summary>
        /// Task 02: Most experienced Tech Leads by Technology
        /// </summary>
        /// <param name="technologyName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetExperiencedTechLeadByTechnology/{technologyName?}")]
        public async Task<IActionResult> GetExperiencedTechLeadByTechnology(string technologyName)
        {
            var response = await techLeadTechnologyManager.GetExperiencedTechLeadByTechnology(technologyName);
            if (response != null && response.Count != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }

        /// <summary>
        /// Task 03: Most experienced Tech Leads by Developer and Technology  
        /// </summary>
        /// <param name="developerId"></param>
        /// <param name="technologyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetExperiencedTechLeadByDeveloperTechnology/{developerId?}/{technologyId?}")]
        public async Task<IActionResult> GetExperiencedTechLeadByDeveloperTechnology(int developerId, int technologyId)
        {
            var response = await techLeadTechnologyManager.GetExperiencedTechLeadByDeveloperTechnology(developerId, technologyId);

            if (response != null || response.Count != 0)
            {
                return Ok(response);
            }

            return NotFound();
        }

    }
}
