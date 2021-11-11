using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class NoiseParameters : IParameters
    {
        public double Coefficent { get; set; }

        public ParameterInfo[] GetDisciption()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Коэффициент",
                    MinValue = 0,
                    MaxValue = 1,
                    DefaultValue = 0,
                    Increment = 0.01
                }
            };
        }

        public void SetValues(double[] values)
        {
            Coefficent = values[0];
        }
    }
}