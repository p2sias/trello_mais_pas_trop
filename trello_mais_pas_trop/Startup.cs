using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using trello_mais_pas_trop.DAL;
using trello_mais_pas_trop.BL.Services;
using Microsoft.Extensions.Logging;

namespace trello_mais_pas_trop
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
            services.AddControllers();

            services.AddSwaggerGen();
            services.AddDbContext<TrelloMptContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TrelloMptContext")));
            services.Add(new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ITaskService), typeof(TaskService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ITaskUserService), typeof(TaskUserService), ServiceLifetime.Transient));

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trello Mais Pas Trop");
            });
        }
    }
}
