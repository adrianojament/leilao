using Leilao.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Leilao.Application
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(
             CertificateAuthenticationDefaults.AuthenticationScheme)
             .AddCertificate(options =>
             {
                 options.Events = new CertificateAuthenticationEvents
                 {
                     OnCertificateValidated = context =>
                     {
                         var claims = new[]
                         {
                    new Claim(
                        ClaimTypes.NameIdentifier,
                        context.ClientCertificate.Subject,
                        ClaimValueTypes.String,
                        context.Options.ClaimsIssuer),
                    new Claim(ClaimTypes.Name,
                        context.ClientCertificate.Subject,
                        ClaimValueTypes.String,
                        context.Options.ClaimsIssuer)
                         };

                         context.Principal = new ClaimsPrincipal(
                             new ClaimsIdentity(claims, context.Scheme.Name));
                         context.Success();

                         return Task.CompletedTask;
                     }
                 };
             });

            services.AddControllers();
            ConfigureSwagger(services);

            //Configuration Dependency Injection
            ConfigureRepositories.ConfigureDependencies(Configuration, services);
            ConfigureServicesDependencies.Configure(services);
            ConfigureMappings.Configure(services);
            //Configuration Dependency Injection

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            if (!_env.IsDevelopment())
            {
                services.AddHttpsRedirection(options =>
                {
                    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                    options.HttpsPort = 443;
                });
            }

        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Desafio Fullstack - Leilão online",
                    Description = "Desenvolvimento de controle de Leilão online",
                    Contact = new OpenApiContact
                    {
                        Name = "Adriano Jose Ament",
                        Email = "adrianojament@gmail.com",
                        Url = new Uri("https://gist.github.com/filipenonato/0183c086bc147f6322095572ff7ff403")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leilao.Application v1"));

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
