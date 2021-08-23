using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HelloworldAspNetCoreRazorPagesWithEfCore.Data;

namespace HelloworldAspNetCoreRazorPagesWithEfCore
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
            services.AddRazorPages();

            #region EF Core
            // 로컬 개발의 경우 ASP.NET Core 구성 시스템은 appsettings.json 파일에서 연결 문자열을 읽어서 종속성 주입에 등록합니다.
            services.AddDbContext<SchoolContext>(options => options.UseSqlite(Configuration.GetConnectionString("SchoolContext")));
            // [Entity Framework Core 오류 페이지에 대한 ASP.NET Core 미들웨어를 제공합니다. 즉, 개발 환경에서 유용한 오류 정보를 제공합니다.](https://docs.microsoft.com/ko-kr/aspnet/core/data/ef-rp/intro?view=aspnetcore-5.0&tabs=visual-studio-code#add-the-database-exception-filter)
            services.AddDatabaseDeveloperPageExceptionFilter();
            #endregion
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
