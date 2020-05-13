using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerCore.Models.Inrerfaces;
using Microsoft.AspNetCore.HttpsPolicy;
using ServerCore.Models.RealizationInrerface;

namespace ServerCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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

            string con = "Server=LocalHost; Database=Smart_voting; Trusted_Connection=True";
            services.AddTransient<IOptionsFunctional, OptionsFunctional>(provider => new OptionsFunctional(con));
            services.AddTransient<IUserFunctional, UserFunctional>(provider => new UserFunctional(con));
            services.AddTransient<IVotingFunctional, VotingFunctional>(provider => new VotingFunctional(con));  
            services.AddTransient<IUserAnswerFunctional, UserAnswerFunctional>(provider => new UserAnswerFunctional(con));
            
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
