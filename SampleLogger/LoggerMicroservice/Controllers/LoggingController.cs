using System.Linq;
using System.Transactions;
using LoggerMicroservice.Models;
using LoggerMicroservice.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace LoggerMicroservice.Controllers
{
    [Route("api/Logging")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        // POST: api/Logging
        public IActionResult Post([FromBody] LogModel logModel)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    LoggerUtility.Log(logModel.Target, logModel.Id, logModel.Message, logModel.DateTimestamp);
                    scope.Complete();
                }
                Response.StatusCode = 200;
                return Content("Log post successful");
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                Response.StatusCode = 400;
                return Content(message);
            }
        }
    }
}
