using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using ServerCore.Services;

namespace ServerCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string VueCorsPolicy = "_vueCorsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: VueCorsPolicy,
                                  builder =>
                                  {
                                      builder
                                        .WithOrigins("http://localhost:8080")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials();
                                  });
            });

            string con = "Server=LocalHost; Database=Smart_poll; Trusted_Connection=True";
            services.AddTransient<IClient, ClientRealization>(provider => new ClientRealization(con));
            services.AddTransient<IPoll, PollRealization>(provider => new PollRealization(con));
            services.AddTransient<IClientAnswer, ClientAnswerRealization>(provider => new ClientAnswerRealization(con));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(VueCorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
