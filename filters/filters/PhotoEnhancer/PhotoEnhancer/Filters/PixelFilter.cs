﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public abstract class PixelFilter : ParametrizedFilter
    {
        public PixelFilter(IParameters parameters) : base(parameters) { }

        //public abstract ParameterInfo[] GetParametersInfo();

        public override Photo Process(Photo original, IParameters parameters)
        {
            var resultPhoto = new Photo(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
                for (int y = 0; y < original.Height; y++)
                    resultPhoto[x, y] = ProcessPixel(original[x, y], parameters);

            return resultPhoto;
        }

        public abstract Pixel ProcessPixel(Pixel original, IParameters parameters);
    }
}
