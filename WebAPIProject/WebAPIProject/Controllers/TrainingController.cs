using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIProject.DataAccess;
using WebAPIProject.Entities;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    public class TrainingController : Controller
    {

        [HttpGet("[action]")]
        public IActionResult Get(string message)
        {
            return Ok("Hello World!");
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody]TrainingData data)
        {
            var days = 0;
            var result = string.Empty;

            //Validate data.
           result = data.ValidateDates(out days);

            try
            {
                //If valid data then save.
                if (days > 0)
                {
                    var trainingDA = new TrainingDA();
                    var trainingData = new Training { TrainingName = data.TrainingName, StartDate = data.StartDate, EndDate = data.EndDate };
                    var saveFlag = await trainingDA.SaveTraining(trainingData);

                    result = Constants.ResponseMessages.Training_Save_Success;
                    return Ok(new { result = result, days = days });
                }
                return BadRequest(new { error = result, days = days });
            }
            catch (Exception ex)
            {
                //Need to log the error in logs like elastic search or log4net.
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }            
        }

    }

}