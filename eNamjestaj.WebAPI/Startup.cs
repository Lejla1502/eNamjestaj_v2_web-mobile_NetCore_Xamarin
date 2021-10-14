using AutoMapper;
using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Database;
using eNamjestaj.WebAPI.Filter;
using eNamjestaj.WebAPI.Security;
using eNamjestaj.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI
{
    public class BasicAuthDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

            swaggerDoc.Security = new[] { securityRequirements };
        }
    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x=>x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.CustomSchemaIds(x => x.FullName);
                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.DocumentFilter<BasicAuthDocumentFilter>();

            });

            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

           

            //services.AddScoped<ICRUDService<Model.Proizvod, ProizvodSearchRequest, ProizvodUpsertRequest, ProizvodUpsertRequest>,ProizvodService>();
            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IService<Model.Uloga, object>, BaseService<Model.Uloga,object,Uloga>>();
            services.AddScoped<IOpstinaService, OpstinaService>();
            services.AddScoped<IService<Model.VrstaProizvoda, object>, BaseService<Model.VrstaProizvoda
                , object, VrstaProizvoda>>();
            services.AddScoped<IProizvodSkladisteService, ProizvodSkladisteService>();
            services.AddScoped<IService<Model.AkcijskiKatalog, object>, BaseService<Model.AkcijskiKatalog
                , object, AkcijskiKatalog>>();
            services.AddScoped<IService<Model.OpisProizvoda, object>, BaseService<Model.OpisProizvoda, object, OpisProizvoda>>();
            services.AddScoped<IService<Model.AkcijskiKatalog, object>, BaseService<Model.AkcijskiKatalog, object, AkcijskiKatalog>>();
            services.AddScoped<IKupacService, KupacService>();
            services.AddScoped<IBojaService,BojaService>();
            services.AddScoped<INarudzbaService, NarudzbaService>();
            services.AddScoped<INarudzbaStavkaService, NarudzbaStavkaService>();
            services.AddScoped<IIzlazService, IzlazService>();
            services.AddScoped<IProizvodService, ProizvodService>();
            services.AddScoped<IRecenzijaService, RecenzijaService>();


            var connection = @"Server=.;Database=eNamjestaj_v2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<eNamjestaj_v2Context>(options => options.UseSqlServer(connection));
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
           // app.UseRouting();
            app.UseAuthentication();
            //app.UseAuthorization();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });

            app.UseAuthentication();
           // app.UseAuthorization();

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
