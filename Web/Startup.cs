using System.IO;
using MediaAds.Core;
using MediaAds.Core.Interfaces;
using MediaAds.Infrastructure.Data;
using MediaAds.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Web
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
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IChannelRepository, ChannelRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = JwtOptions.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = JwtOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = JwtOptions.SecurityKey,
                    ValidateIssuerSigningKey = true
                };
            });

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            services.AddDbContext<MediaDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(config.GetConnectionString("DefaultConnection")));

            //services.AddCors();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            //app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
        }
    }
}
