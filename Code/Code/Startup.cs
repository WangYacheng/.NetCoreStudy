using Dang.CrossCutting.IOC;
using Dang.Domain.Interfaces;
using Dang.Context;
using Dang.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace Code
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
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            services.AddControllers().AddNewtonsoftJson(opts =>
            {
                opts.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                opts.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            });
            services.AddTransient<Dang.Infrastruct.DB.ISqlHelper>(sp => new Dang.Infrastruct.DB.MSSqlHelper(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IDangUnitOfWork, DangUnitOfWork<DangContext>>();
            services.AddScoped<DangContext>();

            // .NET Native DI Abstraction
            RegisterServices(services);

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
