using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp_220329.Data;
using MyApp_220329.Data.Repositories;

namespace MyApp_220329
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup( IConfiguration config )
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // IServiceCollection을 파라미터로 함(의존성 주입)

            services.AddDbContext<MyAppContext>( options =>
            {
                // appsetting.json의 ConnectionStrings 내 MyAppConnection의 값을 읽어옴
                options.UseSqlServer( _config.GetConnectionString( "MyAppConnection" ) );
            });

            // DbSeeder 클래스를 IServiceCollection에 추가하기 위한 함수 AddTransient
            // 캐시 내에 저장되지 않고 필요할 떄마다 인스턴스가 새로 생성됨 - 한번만 사용되므로..
            services.AddTransient<DbSeeder>();

            // ITeacherRepository 인터페이스, TeacherRepository 클래스를 IServiceCollection에 추가하기 위한 함수 AddScoped
            // .NET Core에서 제공하는 서비스 생명주기 - 요청 시마다 인스턴스를 새로 생성 후 동일한 요청 내에서는 재사용
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            // 애플리케이션 생명주기 동안 단 한 번만 인스턴스를 생성, 요청 시마다 동일한 인스턴스를 계속 활용
            // 속성이 변하지 않는 정적인 데이터를 메모리 내에 저장하여 의존성 주입이 필요할 때마다 사용
            //services.AddSingleton

            // 설정한 MVC를 IServiceCollection에 추가
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // HTTP 프로세싱 파이프라인을 설정하는 함수 Configure - 웹 요청을 어떻게 듣고 진행할 것인지 정의
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbSeeder seeder)
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            // wwwroot 내의 정적 html 파일을 실행하기 위해 미들웨어 추가
            app.UseStaticFiles();

            // MVC 설정
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}" // URL 패턴
                    // id의 ? : id값은 써도 되고 안써도 된다는 뜻
                    // http://localhost:29255/Home/Student/2 - http://localhost:29255/컨트롤러/액션함수/매개변수
                );
            });

            // DbSeeder 클래스의 SeedDatabase 함수를 TaskType이 끝날 때까지 대기
            seeder.SeedDatabase().Wait();

            /*
            // 웹 요청이 들어왔을 때 HttpResponse로 "Hello World!" 문구를 전송하여 출력되도록 함
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */
        }
    }
}
