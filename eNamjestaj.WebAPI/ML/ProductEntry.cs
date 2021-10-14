using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.ML
{
    //klasa koja se koristi da bi se dobio rezulztat nase predikcije
    //da li je velika vjerovatnoca da covjek koji uzima monitor uzme i CPU
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        //keytype pomaze algoritmu da mu kazemo koliko ima podataka u nasoj bazi 
        [KeyType(count: 2000)]
        public uint ProductID { get; set; }

        [KeyType(count: 2000)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }
}
