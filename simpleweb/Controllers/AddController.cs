using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using simple_math_nuget;
using simpleweb.model;
namespace simpleweb.Controllers
{
    [Route("api/Add")]
    [ApiController]
    public class AddController : ControllerBase
    {

        // GET: api/Add/5
        [HttpGet("{x}/{y}", Name = "GetAdd")]
        public IMathResult Get(int x, int y)
        {
            System.Diagnostics.Stopwatch durationTimer = new System.Diagnostics.Stopwatch();
            durationTimer.Start();
            MathValue result = new MathValue(x, y, (x+y));
            durationTimer.Stop();
            result.Duration = new TimeSpan(durationTimer.ElapsedTicks);
            
            return result;
        }

        // POST: api/Add
        [HttpPost]
        public IMathResult Post([FromBody] string[] values)
        {
            //List<string> vals = values.Split('|').ToListstring>();
            List<string> vals = values.ToList<string>();
            MathValue result;
            int x;
            int y;
            bool xsuccess = int.TryParse(vals[0], System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.CurrentInfo, out x);
            bool ysuccess = int.TryParse(vals[1], System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.CurrentInfo, out y);
            if (xsuccess && ysuccess)
            {
                result = new MathValue(x,y, x +y);
            }
            else
            {
                result = new MathValue(int.MinValue, int.MinValue, double.MinValue);
            }
            return result;
        }

        
    }
}
