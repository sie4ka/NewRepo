using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class IncreaseParameters : IParameters
    {
        [ParameterInfo(Name = "Увеличение в", MinValue = 1, MaxValue = 10, DefaultValue = 1, Increment = 0.5)]
        public double N { get; set; }
    }
}
