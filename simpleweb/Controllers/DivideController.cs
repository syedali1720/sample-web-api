using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simpleweb.model;


namespace simpleweb.Controllers
{
    [Route("api/Divide")]
    [ApiController]
    public class DivideController : ControllerBase
    {
        // GET: api/Add/5
        [HttpGet("{x}/{y}", Name = "GetDiv")]
        public IMathResult Get(int x, int y)
        {
            MathValue result;
            if (y != 0)
            {
                result = new MathValue(x, y, (x/y));
            }
            else
            {
                result = new MathValue(x, y, 0);
            }
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
                if (y != 0)
                {
                    result = new MathValue(x, y, (x/y));
                }
                else
                {
                    result = new MathValue(x, y, 0);
                }
            }
            else
            {
                result = new MathValue(int.MinValue, int.MinValue, double.MinValue);
            }
            return result;
        }

    }
}
