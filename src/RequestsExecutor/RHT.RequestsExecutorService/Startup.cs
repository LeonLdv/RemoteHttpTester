using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RHT.RequestsExecutor.HttpProvider;
using RHT.RequestsExecutor.Infrastructure;

namespace RHT.RequestsExecutorService
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
			   .SetBasePath(env.ContentRootPath)
			   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
			   .AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var appSettings = this.Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettings);

			AppSettings settings = new AppSettings();
			appSettings.Bind(settings);

			services.AddHttpClient();

			services.RegisterAppServices();
			services.RegisterHttpProvider();

			services.RegisterMassTransit(settings);

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			serviceProvider.StartBusControl();

			app.UseMvc();
		}
	}
}