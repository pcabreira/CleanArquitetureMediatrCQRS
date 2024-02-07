using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PessoasAptas.API.Extensions;
using PessoasAptas.Application.Commands.CreateCriterio;
using PessoasAptas.Application.Commands.CreatePessoa;
using PessoasAptas.Application.Commands.CreatePessoaCriterio;
using PessoasAptas.Infrastructure.Persistence;

namespace PessoasAptas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DBConnection");
            services.AddDbContext<BeneficioGovernoDbContext>(options => options.UseSqlServer(connectionString));

            services.AddHttpClient();
            services.AddInfrastructure();
            services.AddMediatR(typeof(CreatePessoaCommand));
            services.AddMediatR(typeof(CreateCriterioCommand));
            services.AddMediatR(typeof(CreatePessoaCriterioCommand));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PessoasAptas.API v1"));

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
