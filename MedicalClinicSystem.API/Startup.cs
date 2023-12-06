using MedicalClinicSystem.Core.UnitOfWork;
using MedicalClinicSystem.EF.Contex;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MedicalClinicSystem.API
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
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddMvc();
            // Add services to the container.
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MedicalClinicContext>(options =>
            {
                //options.UseSqlServer(connectionString);
                options.UseSqlServer("Data Source=DESKTOP-CEOJM8V\\SQL2016;Initial Catalog=MedicalClinicSystem;Integrated Security=True;Integrated security=SSPI;MultipleActiveResultSets=True;trustservercertificate=True;");

            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalClinicSystem.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalClinicSystem.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
