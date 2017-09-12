using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace OwinKatanaStart
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";


            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Start");
                Console.ReadKey();
                Console.WriteLine("End");
            }


        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage();

            //app.Run(ctx => ctx.Response.WriteAsync("Heloo from console app!"));
        }
    }
}
