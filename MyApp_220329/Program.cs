using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyApp_220329
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // BuildWebHost 함수 호출
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            // WebHost.CreateDefaultBuilder 함수 호출 - webapp을 실행 시키기 위한 기본적인 것들을 구축
            WebHost.CreateDefaultBuilder(args)
                // 웹 요청이 서버에 들어왔을 때 어떤 클래스를 써야하는지 표시 - Startup.cs
                .UseStartup<Startup>()
                // 내용을 빌드
                .Build();
    }
}
