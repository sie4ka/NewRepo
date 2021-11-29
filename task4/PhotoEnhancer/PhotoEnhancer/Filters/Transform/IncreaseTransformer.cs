using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class IncreaseTransformer : ITransformer<IncreaseParameters>
    {
        public Size ResultSize { get; private set; }

        Size size;
        double n;

        public void Initialize(Size size, IncreaseParameters parameters)
        {
            this.size = size;
             n = parameters.N*1.0;

            ResultSize = new Size(
                 (int)(size.Width*n),
                        (int)(size.Height*n) );

        }

		public Point? MapPoint(Point newPoint)
		{
            var p = new Point(newPoint.X - ResultSize.Width,
                        newPoint.Y-ResultSize.Height) ;

			var x = (int)(p.X/n+size.Width);

			var y = (int)(p.Y/n+size.Height);

			if (x < 0 || x >= size.Width || y < 0 || y >= size.Height)
				return null;

			return new Point(x, y);
        }
    }
}