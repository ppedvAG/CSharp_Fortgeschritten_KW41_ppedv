using IOCSampleInWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOCSampleInWebAPI.Controllers
{
    //Controller-Klasse wird via Factory-Klasse erstellt
    [Route("api/[controller]")]
    [ApiController]
    public class TimeServiceController : ControllerBase
    {
        private readonly ITimeService _timeservice;

        //Konstruktor-Injection
        public TimeServiceController(ITimeService timeservice)
        {
            _timeservice = timeservice;
        }




    }
}
