using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IChoosrAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ILogger<CameraController> logger;
        private readonly ISearchHandler searchHandler;

        public CameraController(ILogger<CameraController> logger, ISearchHandler searchHandler)
        {
            this.logger = logger;
            this.searchHandler = searchHandler;
        }


        /// <summary>
        /// Retrieves all data from the Camera CSV file
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">BadRequest, check the file</response>
        /// <response code="404">The requested file was not found</response>
        /// <response code="500">Error in system, check logs</response>
        /// <returns>Data (if found)</returns>
        [Produces(typeof(FileResult))]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public ActionResult GetAllCameras()
        {
            logger.LogTrace("Getting data from file");
            try
            {
                var data = this.searchHandler.GetNames();

                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString(), ex);
                return StatusCode(500);
            }
        }

        // GET: api/Camera/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Camera
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Camera/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
