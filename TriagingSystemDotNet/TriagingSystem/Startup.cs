using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TriagingSystem.Models;
using TriagingSystem.Services;

namespace TriagingSystem
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
         
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddTransient<INlpService, nlpService>(); 
            //services.AddTransient<IJSONHelper, JSONHelper>();
            
            services.AddTransient<IAlogrithmService, AlogrithmService>(); 
            services.AddTransient<IUserService, UserService>(); 
            services.AddTransient<IKeywordService, KeywordService>();
            services.AddTransient<IQuestionService, QuestionService>(); 
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddCors(options =>
            {
                options.AddPolicy("corspolicy",
                builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });
            //var connection = @"Server=DESKTOP-DQMKLIH; Database=triagingDB; Trusted_Connection=True; ConnectRetryCount=0";
            //services.AddDbContext<triagingDBContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<triagingDBContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("corspolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
