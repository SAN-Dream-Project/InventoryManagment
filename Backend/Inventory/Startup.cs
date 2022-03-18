using Inventory.Application;
using Inventory.Application.Authentications;
using Inventory.Application.Shared.Authentications;
using Inventory.Application.Shared.UserAndRoles.Roles;
using Inventory.Application.Shared.UserAndRoles.Users;
using Inventory.Application.UserAndRoles.Roles;
using Inventory.Application.UserAndRoles.Users;
using Inventory.EntityFramwork;
using Inventory.EntityFramwork.Abstract;
using Inventory.EntityFramwork.Abstract.UserAndRoles.Roles;
using Inventory.EntityFramwork.Abstract.UserAndRoles.Users;
using Inventory.EntityFramwork.Repositories;
using Inventory.EntityFramwork.Repositories.UserAndRoles.Roles;
using Inventory.EntityFramwork.Repositories.UserAndRoles.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Inventory.EntityFramwork.Abstract;
using System.Text;
using Inventory.EntityFramwork.Abstract.Goods;
using Inventory.Application.Shared.Goods;
using Inventory.Application.Goods;
using Inventory.EntityFramwork.Repositories.Goods;
using Inventory.EntityFramwork.Abstract.Kadatas;
using Inventory.EntityFramwork.Repositories.Kadatas;
using Inventory.Application.Kadatas;
using Inventory.Application.Shared.Kadatas;
using Inventory.EntityFramwork.Abstract.GoodSuppliers;
using Inventory.Application.Shared.GoodSuppliers;
using Inventory.EntityFramwork.Repositories.GoodSuppliers;
using Inventory.Application.GoodSuppliers;
using Inventory.EntityFramwork.Abstract.Stocks;
using Inventory.EntityFramwork.Repositories.Stocks;
using Inventory.Application.Shared.Stocks;
using Inventory.Application.Stocks;
using Inventory.EntityFramwork.Abstract.Labours;
using Inventory.EntityFramwork.Repositories.Labours;
using Inventory.Application.Labours;
using Inventory.Application.Shared.Labours;
using Inventory.EntityFramwork.Abstract.Retailers;
using Inventory.EntityFramwork.Repositories.Retailers;
using Inventory.Application.Retailers;
using Inventory.Application.Shared.Retailers;
using Inventory.EntityFramwork.Abstract.BharadaRates;
using Inventory.EntityFramwork.Repositories.BharadaRates;
using Inventory.Application.Shared.BharadaRates;
using Inventory.Application.BharadaRates;

namespace Inventory.Host
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
       
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.  
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InventoryContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddHttpClient();
            // Automapper Configuration
            // Automapper Configuration
            var key = "This is my first Test Key";
            AutoMapperConfiguration.Configure(); services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
                };
            });

            services.AddSingleton<IJwtAuth>(new Auth(key));
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleAppService, RoleAppService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IGoodRepository, GoodRepository>();
            services.AddTransient<IGoodAppService, GoodAppService>();
            services.AddTransient<IKadataRepository, KadataRepository>();
            services.AddTransient<IKadataAppService, KadataAppService>();
            services.AddTransient<IGoodSupplierRepository, GoodSupplierRepository>();
            services.AddTransient<IGoodSupplierAppService, GoodSupplierAppService>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IStockAppService, StockAppService>();
            services.AddTransient<ILabourRepository, LabourRepository>();
            services.AddTransient<ILabourAppService, LabourAppService>();
            services.AddTransient<IRetailerRepository, RetailerRepository>();
            services.AddTransient<IRetailerAppService, RetailerAppService>();
            services.AddTransient<IBharadaRateRepository, BharadaRateRepository>();
            services.AddTransient<IBharadaRateAppService, BharadaRateAppService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryAPI", Version = "v1" });
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
                app.UseHsts();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          
        }
    }
}
