using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleweb.model
{

    public interface IMathResult
    {
        int x
        {
            get; set;
        }
        int y
        {
            get; set;
        }
        double result
        {
            get; set;
        }

        DateTime timestamp
        {
            get;
        }
        
        string ver
        {
            get;
        }

        TimeSpan Duration
        {
            get;
            set;
        }
    }

    public class MathValue : IMathResult
    {
        public int x
        {
            get; set;
        }
        public int y
        {
            get; set;
        }
        public double result
        {
            get; set;
        }

        public DateTime timestamp
        {
            get { return DateTime.Now; }
        }

        public string ver
        {
            get { return "v1.10"; }
        }

        public TimeSpan Duration 
            {
                get;
                set;
            }

        public MathValue(int x, int y, double result)
        {
            this.x = x;
            this.y = y;
            this.result = result;
            this.Duration = new TimeSpan(0);
        }
    }
}
