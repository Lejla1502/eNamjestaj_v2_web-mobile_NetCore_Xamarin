using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.ML
{
    public class ProductRating
    {
        [LoadColumn(0)]
        public float userId;

        [LoadColumn(1)]
        public float productId;

        [LoadColumn(2)]
        public float Label;
    }
}
