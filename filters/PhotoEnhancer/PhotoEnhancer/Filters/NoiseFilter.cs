using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class NoiseFilter:PixelFilter
    {
        public NoiseFilter() : base(new NoiseParameters()) { }
        public override Pixel ProcessPixel(Pixel original, IParameters parameters)
        {
            Random rnd = new Random();
            double k =(parameters as NoiseParameters).Coefficent;
            var channelR = k * rnd.NextDouble() + (1 - k) * original.R;
            var channelG = k * rnd.NextDouble() + (1 - k) * original.G;
            var channelB = k * rnd.NextDouble() + (1 - k) * original.B;

            return new Pixel(channelR, channelG, channelB);

        }

        public override string ToString()
        {
            return "Шум";
        }
    }
}
