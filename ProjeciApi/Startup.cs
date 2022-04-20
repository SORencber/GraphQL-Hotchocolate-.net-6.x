using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;
using ProjeciApi.Interfaces;
using ProjeciApi.Repositories;
using ProjeciApi.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace ProjeciApi
{
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

            // GraphQL elements
            // Register custom services for the 

            services.AddScoped<PersonRepository, PersonRepository>();
            services.AddScoped<CompanyRepository, CompanyRepository>();

            // Add Application Db Context options

            services.AddDbContext<PersonelDataContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("PersonelAppConn")));

           
            services.AddInMemorySubscriptions();
            services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddSubscriptionType<Subscription>().AddFiltering().AddSorting();
;






            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            

            //JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            services.AddControllers();



            //// Swagger adding 
            ///
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Repalogic Personel API",
                    Description = " First ASP.NET Core Web API",
                   // TermsOfService = new System.Uri("www.repalogic.com"),
                    Contact = new OpenApiContact() { Name = "Repalogic", Email = "contact@repalogic.com" }
                });

                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Repalogic Personel API",
                    Description = "Sample Web API",
                   // TermsOfService = new System.Uri("www.repalogic.com"),
                    Contact = new OpenApiContact() { Name = "Repalogic", Email = "contact@repalogic.com" }
                });

               // c.DescribeAllEnumsAsStrings();
               // c.DescribeStringEnumsInCamelCase();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Personel API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Personel API V2");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL("/graphql");
               
            });
            // app.MapGraphQL("/graphql");
            // app.Run();
            
            //GraphQL 
            app.UseWebSockets();




        }
    }
}
