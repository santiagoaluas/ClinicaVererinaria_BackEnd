using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using clinicaveterinariaBackEnd.Helps;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using clinicaveterinariaBackEnd.Interfaces;
using clinicaveterinariaBackEnd.Service;

namespace clinicaveterinariaBackEnd
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

            services.AddControllers(opciones => {
                opciones.Filters.Add(typeof(ManagerException));
            }).AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "clinicaveterinariaBackEnd", Version = "v1" });
            });

            var appSettingSection = Configuration.GetSection(nameof(AppSettings));
            services.Configure<AppSettings>(appSettingSection);
            var appSetting = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSetting.JwtSettings.secret);

            string mySqlConnectionStr = Configuration.GetConnectionString("ConnectionStrings");
            services.AddDbContextPool<DataContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            services.AddAutoMapper(AutomapperProfiles.ProfilesConfig,
                                    GetType().Assembly);

            //Configuracion JWT
            

            // dentro de esta sección estamos configurando la autenticación y estableciendo el esquema predeterminado
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

             .AddJwtBearer(opt =>
             {
                 opt.RequireHttpsMetadata = false;
                 opt.SaveToken = true;
                 opt.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                 };
             });

            services.AddScoped<IUserService, ServicesUsuario>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "clinicaveterinariaBackEnd v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
