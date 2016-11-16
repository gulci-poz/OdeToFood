using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                // ten middleware przetwarza responses z innych middleware
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/error");

                // z użyciem obiektu jako opcji
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Opps!")
                });
            }

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            // pliki domyślne + pliki statyczne
            // można też umożliwić directory serving
            app.UseFileServer();

            app.UseMvcWithDefaultRoute();

            // wprowadzamy MVC, na razie nie używamy middleware UseWelcomePage ani Run
            /*
            // terminal piece of middleware - nie będzie wywołany kolejny middleware
            //app.UseWelcomePage("/welcome");

            // z użyciem obiektu jako opcji
            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/welcome"
            });

            // terminal piece of middleware
            app.Run(async (context) =>
            {
                //throw new Exception("");

                var message = greeter.GetGreeting();
                await context.Response.WriteAsync(message);
            });
            */
        }
    }
}
