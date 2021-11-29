using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class IncreaseParameters : IParameters
    {
        public double N { get; set; }

        public ParameterInfo[] GetDisciption()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Увеличить изображение в",
                    MinValue = 1,
                    MaxValue = 10,
                    DefaultValue = 1,
                    Increment = 0.5
                }
            };
        }

        public void SetValues(double[] values)
        {
            N = values[0];
        }
    }
}

