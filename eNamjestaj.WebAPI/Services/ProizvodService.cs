using AutoMapper;
using eNamjestaj.Mobile;
using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Database;
using eNamjestaj.WebAPI.ML;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkcijskiKatalog = eNamjestaj.WebAPI.Database.AkcijskiKatalog;
using NarudzbaStavka = eNamjestaj.WebAPI.Database.NarudzbaStavka;
using Proizvod = eNamjestaj.WebAPI.Database.Proizvod;

namespace eNamjestaj.WebAPI.Services
{
    public class ProizvodService : BaseCRUDService<Model.Proizvod, ProizvodSearchRequest, Database.Proizvod, ProizvodUpsertRequest, ProizvodUpsertRequest>, IProizvodService
    {
        //obzirom da zelimo trenirati samo prvi put kad se pokrene, koristimo static clan
        //null - da znamo da nismo natrenirali mrezu

        static List<Database.Proizvod> finalResult = new List<Database.Proizvod>();
        public ProizvodService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Proizvod> Get(ProizvodSearchRequest search)
        {
            AkcijskiKatalog aktivniKatalog = null;


            if (_context.Set<AkcijskiKatalog>().Where(a => a.Aktivan == true).Count() > 0)
            {
                IQueryable<Proizvod> query = null;
                aktivniKatalog = _context.Set<AkcijskiKatalog>().Where(a => a.Aktivan == true).First();

                var proizvodiAktivnogKatalogaId = _context.Set<KatalogStavka>().Where(x => x.AkcijskiKatalogId == aktivniKatalog.Id)
                    .Select(s => s.ProizvodId)
                    .AsQueryable();

                var queryProizvodStavkeJoin = _context.Set<Proizvod>()
                    .Where(p => !proizvodiAktivnogKatalogaId.Any(x => x == p.Id)).AsQueryable();


                if (search?.VrstaProizvodaId.HasValue == true && search?.BojaId.HasValue == false)
                {
                    query = queryProizvodStavkeJoin.Where(x => x.VrstaProizvodaId == search.VrstaProizvodaId);
                    query = query.OrderBy(x => x.Naziv);
                }

                if (search?.BojaId.HasValue == true && search?.VrstaProizvodaId.HasValue == false)
                {
                    bool exists = _context.ProizvodBoja.Any(x => x.BojaId == search.BojaId);
                    if (exists)
                    {
                        query = queryProizvodStavkeJoin.Join(_context.ProizvodBoja,
                          p => p.Id,
                          pb => pb.ProizvodId,
                          (x, y) => new { Proizvod = x, ProizvodBoja = y }).Where(x => x.ProizvodBoja.BojaId == search.BojaId)
                          .AsQueryable().Select(x => x.Proizvod);
                        query = query.OrderBy(x => x.Naziv);
                    }
                    else
                        query = null;

                }

                if (search?.BojaId.HasValue == true && search?.VrstaProizvodaId.HasValue == true)
                {
                    bool exists = _context.ProizvodBoja.Any(x => x.BojaId == search.BojaId);
                    if (exists)
                    {
                        query = queryProizvodStavkeJoin.Join(_context.ProizvodBoja,
                          p => p.Id,
                          pb => pb.ProizvodId,
                          (x, y) => new { Proizvod = x, ProizvodBoja = y })
                           .Where(x => x.ProizvodBoja.BojaId == search.BojaId && x.Proizvod.VrstaProizvodaId == search.VrstaProizvodaId)
                          .AsQueryable().Select(x => x.Proizvod);
                        query = query.OrderBy(x => x.Naziv);
                    }
                    else
                        query = null;
                }

                if (query != null)
                {
                    var listP = query.ToList();

                    return _mapper.Map<List<Model.Proizvod>>(listP);
                }
                else
                    return new List<Model.Proizvod>();

            }
            else
            {
                var query = _context.Set<Proizvod>().AsQueryable();

                if (search?.VrstaProizvodaId.HasValue == true && search?.BojaId.HasValue == false)
                {
                    query = query.Where(x => x.VrstaProizvodaId == search.VrstaProizvodaId);
                    query = query.OrderBy(x => x.Naziv);
                }

                if (search?.BojaId.HasValue == true && search?.VrstaProizvodaId.HasValue == false)
                {
                    bool exists = _context.ProizvodBoja.Any(x => x.BojaId == search.BojaId);
                    if (exists)
                    {
                        query = _context.Proizvod.Join(_context.ProizvodBoja,
                          p => p.Id,
                          pb => pb.ProizvodId,
                          (x, y) => new { Proizvod = x, ProizvodBoja = y }).Where(x => x.ProizvodBoja.BojaId == search.BojaId)
                          .AsQueryable().Select(x => x.Proizvod);
                        query = query.OrderBy(x => x.Naziv);
                    }
                    else
                        query = null;

                }

                if (search?.BojaId.HasValue == true && search?.VrstaProizvodaId.HasValue == true)
                {
                    bool exists = _context.ProizvodBoja.Any(x => x.BojaId == search.BojaId);
                    if (exists)
                    {
                        query = _context.Proizvod.Join(_context.ProizvodBoja,
                          p => p.Id,
                          pb => pb.ProizvodId,
                          (x, y) => new { Proizvod = x, ProizvodBoja = y })
                           .Where(x => x.ProizvodBoja.BojaId == search.BojaId && x.Proizvod.VrstaProizvodaId == search.VrstaProizvodaId)
                          .AsQueryable().Select(x => x.Proizvod);
                        query = query.OrderBy(x => x.Naziv);
                    }
                    else
                        query = null;
                }

                if (query != null)
                {
                    var listP = query.ToList();

                    return _mapper.Map<List<Model.Proizvod>>(listP);
                }
                else
                    return new List<Model.Proizvod>();
            }
        }

        public async Task<IEnumerable<ProizvodKatalogDisplayRequest>> GetProizvodiKatalog(ProizvodSearchRequest search)
        {

            var aktivniKatalog = (_context.Set<AkcijskiKatalog>().Where(a => a.Aktivan == true).Count() > 0 ? _context.Set<AkcijskiKatalog>().Where(a => a.Aktivan == true).FirstOrDefault() : null);

            if (aktivniKatalog != null)
            {
                var proizvodi = _context.Set<Proizvod>().Join(_context.Set<KatalogStavka>(),
                 p => p.Id,
                 ks => ks.ProizvodId,
                 (x, y) => new { Proizvod = x, KatalogStavka = y }).Where(x => x.KatalogStavka.AkcijskiKatalogId == aktivniKatalog.Id);

                var query = proizvodi;

                if (search != null)
                {

                    if (search?.VrstaProizvodaId.HasValue == true && search?.BojaId.HasValue == false)
                    {
                        query = proizvodi.Where(x => x.Proizvod.VrstaProizvodaId == search.VrstaProizvodaId);
                        query = query.OrderBy(x => x.Proizvod.Naziv);

                    }



                    if (search?.BojaId.HasValue == true && search?.VrstaProizvodaId.HasValue == false)
                    {
                        bool exists = _context.ProizvodBoja.Any(x => x.BojaId == search.BojaId);
                        if (exists)
                        {
                            var queryListaProizvodBojaId = _context.Proizvod.Join(_context.ProizvodBoja,
                               p => p.Id,
                               pb => pb.ProizvodId,
                               (x, y) => new { Proizvod = x, ProizvodBoja = y }).Where(x => x.ProizvodBoja.BojaId == search.BojaId)
                               .AsQueryable().Select(x => x.Proizvod.Id);

                            query = proizvodi.Where(x => queryListaProizvodBojaId.Any(l => l == x.Proizvod.Id)).AsQueryable().OrderBy(x => x.Proizvod.Naziv);

                        }
                        else
                            query = null;
                    }

                    if (search?.BojaId.HasValue == true && search?.VrstaProizvodaId.HasValue == true)
                    {
                        bool exists = _context.ProizvodBoja.Any(x => x.BojaId == search.BojaId);
                        if (exists)
                        {
                            var queryListaBojaVrstaProizvodId = _context.Proizvod.Join(_context.ProizvodBoja,
                              p => p.Id,
                              pb => pb.ProizvodId,
                              (x, y) => new { Proizvod = x, ProizvodBoja = y })
                               .Where(x => x.ProizvodBoja.BojaId == search.BojaId && x.Proizvod.VrstaProizvodaId == search.VrstaProizvodaId)
                              .AsQueryable().Select(x => x.Proizvod.Id);
                            //query = query.OrderBy(x => x.Naziv);

                            query = proizvodi.Where(x => queryListaBojaVrstaProizvodId.Any(l => l == x.Proizvod.Id)).AsQueryable().OrderBy(x => x.Proizvod.Naziv);
                        }
                        else
                            query = null;

                    }
                }

                var trazeneStavke = new List<ProizvodKatalogDisplayRequest>();

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        trazeneStavke.Add(new ProizvodKatalogDisplayRequest
                        {
                            Naziv = item.Proizvod.Naziv,
                            Sifra = item.Proizvod.Sifra,
                            Cijena = item.Proizvod.Cijena,
                            CijenaSaPopustom = item.Proizvod.Cijena - (item.Proizvod.Cijena * item.KatalogStavka.PopustProcent / 100),
                            Slika = item.Proizvod.Slika,
                            Popust = item.KatalogStavka.PopustProcent,
                            ProizvodId = item.Proizvod.Id
                        });
                    }
                }
                return await Task.FromResult(trazeneStavke);
            }
            else
                return await Task.FromResult(new List<ProizvodKatalogDisplayRequest>());
        }

        public ProizvodKatalogDisplayRequest GetProizvodKatalogByProizvodId(int id)
        {
            var ak = _context.AkcijskiKatalog.Where(a => a.Aktivan == true).First();
            var p_k = _context.Set<Proizvod>().Join(_context.Set<KatalogStavka>(),
                p => p.Id,
                ks => ks.ProizvodId,
                (x, y) => new { Proizvod = x, KatalogStavka = y }).Where(x => x.KatalogStavka.AkcijskiKatalogId==ak.Id && x.KatalogStavka.ProizvodId == id).First();

            var proizvodTrazeni = new ProizvodKatalogDisplayRequest
            {
                Naziv = p_k.Proizvod.Naziv,
                Sifra = p_k.Proizvod.Sifra,
                Slika = p_k.Proizvod.Slika,
                Cijena = p_k.Proizvod.Cijena,
                Popust = p_k.KatalogStavka.PopustProcent,
                CijenaSaPopustom = p_k.Proizvod.Cijena - (p_k.Proizvod.Cijena * p_k.KatalogStavka.PopustProcent / 100),
                ProizvodId = p_k.Proizvod.Id
            };

            return proizvodTrazeni;

        }

        public List<Model.Proizvod> Recommend(int kupacId, int proizvodId)
        {
            MLContext mlContext = null;
            ITransformer model = null;
            mlContext = new MLContext();

           
            //var tmpData = _context.Izlaz.Include("IzlaziStavka").ToList();

            var tmpData = _context.Recenzija.ToList();
            var data = new List<ProductRating>();



            var trainData = _context.Recenzija.ToList().Select(s => new { userId = s.KupacId, productId = s.ProizvodId, rating = (float)s.Ocjena });
            foreach (var x in trainData)
            {
                data.Add(new ProductRating()
                {
                    userId = (float)x.userId,
                    productId = x.productId,
                    Label = x.rating
                });

            }
            /*

            //iz Narudzba-NarudzbaStavke je potrebno konvertovati u ProductEntry
            var data = new List<ProductEntry>();

            foreach(var x in tmpData)
            {
                //ukoliko je kupljen samo jedan artikal 
                //preskace se jer se ne moze praviti nikakav similarity

                if (x.IzlaziStavka.Count > 1)
                {
                    //dobavljanje svih ID-eva proizvoda iz IzlazStavka
                    var distinctItemId = x.IzlaziStavka.Select(y => y.Id).ToList();

                    //za svaku stavku uzeti druge proizvode osim trenutnog i konvertovati u ProductEntry

                    distinctItemId.ForEach(y =>
                    {
                        //uzeti sve povezane proizvode iz te narudzbe osim samog sebe

                        //u sustini ulazi se u svaku nabavku koja ima vise od jedne stavke
                        //potom se uzimaju stavke te narudzbe
                        //potom se tranverza kroz te stavke
                        //uzima se jedna po jedna
                        // za svaku--sto je sad ovaj kod
                        //kreira se lista od preostalih stavki
                        //i to je lista relatedItems

                        var relatedItems = x.IzlaziStavka.Where(z => z.ProizvodId != y).ToList();

                        //potom se vrsi konverzija

                        relatedItems.ForEach(rs =>
                        {
                            data.Add( new ProductEntry()
                            { 
                                ProductID=(uint)y,
                                CoPurchaseProductID=(uint)rs.ProizvodId
                            });//Kad je kupljen ovaj proizvod (ProductID, kupljen je i ovaj CoPurchaseProductId
                        }
                        );

                    });
                }
            }*/

            //sada se moze kreirati trainData
            IDataView trainingDataView = mlContext.Data.LoadFromEnumerable(data);
            //var traindata = 

            // STEP 3: Transform your data by encoding the two features userId and movieID.These encoded features will be provided as input
            //        to our MatrixFactorizationTrainer.
            var dataProcessingPipeline = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: nameof(ProductRating.userId))
                           .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "productIdEncoded", inputColumnName: nameof(ProductRating.productId)));


            //Specify the options for MatrixFactorization trainer            
            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            options.MatrixColumnIndexColumnName = "userIdEncoded";
            options.MatrixRowIndexColumnName = "productIdEncoded";
            options.LabelColumnName = "Label";
            options.NumberOfIterations = 20;
            options.ApproximationRank = 100;


            //STEP 4: Create the training pipeline 
            var trainingPipeLine = dataProcessingPipeline.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

            //STEP 5: Train the model fitting to the DataSet
            Console.WriteLine("=============== Training the model ===============");
            model = trainingPipeLine.Fit(trainingDataView);


            /*
            //uzeti 20% podataka za test 
            int totalNumOfData = _context.Recenzija.Count();
            decimal calc20PercentOfGivenDataset = 0;

            if (totalNumOfData > 0)
                calc20PercentOfGivenDataset = totalNumOfData * (20 / 100);

            int numOfTestData = Convert.ToInt32(calc20PercentOfGivenDataset);


            var tmpTestRecenzijaData = new List<Database.Recenzija>();
            */

            var testData = new List<ProductRating>()
            {
                new ProductRating { userId = 1, productId = 1, Label=4 },
                new ProductRating { userId = 1, productId = 2, Label=5 },
                new ProductRating { userId = 1, productId = 3, Label=3 },
                new ProductRating { userId = 2, productId = 1, Label=4 },
                new ProductRating { userId = 2, productId = 3, Label=2 },
                new ProductRating { userId = 2, productId = 4, Label=1 },
                new ProductRating { userId = 3, productId = 1, Label=3 },
                new ProductRating { userId = 3, productId = 3, Label=1 },
                new ProductRating { userId = 4, productId = 1, Label=3 }

            };



            //STEP 6: Evaluate the model performance 
            Console.WriteLine("=============== Evaluating the model ===============");
            IDataView testDataView = mlContext.Data.LoadFromEnumerable(testData);
            var prediction = model.Transform(testDataView);
            var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");
            Console.WriteLine("The model evaluation metrics RootMeanSquaredError:" + metrics.RootMeanSquaredError);



            //STEP 7:  Try/test a single prediction by predicting a single movie rating for a specific user
            var predictionengine = mlContext.Model.CreatePredictionEngine<ProductRating, ProductRatingPrediction>(model);
            /* Make a single movie rating prediction, the scores are for a particular user and will range from 1 - 5. 
               The higher the score the higher the likelyhood of a user liking a particular movie.
               You can recommend a movie to a user if say rating > 3.5.*/

            var allItems = _context.Proizvod.Where(p => p.Id != proizvodId).ToList();

            var listRecommendedProducts = new List<Tuple<Database.Proizvod, float>>();

            foreach (var x in allItems)
            {
                var productRatingPrediction = predictionengine.Predict(
                    new ProductRating()
                    {
                        //Example rating prediction for userId = 6, movieId = 10 (GoldenEye)
                        userId = kupacId,
                        productId = x.Id
                    }
                );

                listRecommendedProducts.Add(new Tuple<Proizvod, float>(x, productRatingPrediction.Score));

            }

            finalResult = listRecommendedProducts.OrderByDescending(o => o.Item2).Select(s => s.Item1).Take(3).ToList();


            return _mapper.Map<List<Model.Proizvod>>(finalResult);


        }

       
        public Task<bool> CheckIfProductInCatalogue(int id)
        {
            
            if (_context.AkcijskiKatalog.Where(a => a.Aktivan == true).Count() < 0)
            {
                return Task.FromResult(false);
            }
            else
            {
                var aktivan = _context.AkcijskiKatalog.Where(a => a.Aktivan == true).First();
                var found = false;
                foreach (var x in _context.KatalogStavka.Where(ks => ks.AkcijskiKatalogId == aktivan.Id))
                {
                    if (x.ProizvodId == id)
                        found=true;
                }

                if (!found)
                    return Task.FromResult(false);
                else
                    return Task.FromResult(true);
            }
        }
    }
}

