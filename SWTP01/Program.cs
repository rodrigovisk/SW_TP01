using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTP01
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Test();
            //Console.ReadKey();
            
            IWebHost host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .Build();
            host.Run();
            
           
        }

        public class Startup
        {

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddRouting();
            }

            public void Configure(IApplicationBuilder app)
            {
               
                var builder = new RouteBuilder(app);
                builder.MapRoute("/nomeDoLivro/{book}", NameBook);
                builder.MapRoute("/resultadoToString/{book}", resultadoToString);
                builder.MapRoute("/getAuthorNames/{book}", getAuthorNames);               
                builder.MapRoute("/livro/ApresentarLivro/{book}", carregaHtml);
                var rotas = builder.Build();
                app.UseRouter(rotas);


            }


            public Task NameBook(HttpContext context)
            {
                Consulta ler = new Consulta();
                var livros = ler.buscaArquivo();
                Book result = new Book();


                foreach (var livro in livros)
                {
                    if (livro.getName().Equals(context.GetRouteValue("book").ToString()))
                    {
                        result = livro;
                    }
                }

                if (result.getName() != null)
                {
                    return context.Response.WriteAsync(result.name);
                }

                return context.Response.WriteAsync("Livro Não encontrado");

            }
            public Task resultadoToString(HttpContext context)
            {
                var book = context.GetRouteValue("book").ToString();
                Consulta ler = new Consulta();
                var livros = ler.buscaArquivo();
                Book result = new Book();


                foreach (var livro in livros)
                {
                    if (livro.getName().Equals(context.GetRouteValue("book").ToString()))
                    {
                        result = livro;
                    }
                }

                if (result.getName() != null)
                {
                    return context.Response.WriteAsync(result.ToString());
                }

                return context.Response.WriteAsync("Livro Não encontrado");

            }

            public Task getAuthorNames(HttpContext context)
            {
                Consulta ler = new Consulta();
                var livros = ler.buscaArquivo();
                Book result = new Book();


                foreach (var livro in livros)
                {
                    if (livro.getName().Equals(context.GetRouteValue("book").ToString()))
                    {
                        result = livro;
                    }
                }

                if (result.getName() != null)
                {
                    return context.Response.WriteAsync(livros[0].getAuthorNames());
                }

                return context.Response.WriteAsync("Livro Não encontrado");
            }

            public Task carregaHtml(HttpContext context)
            {
                Consulta ler = new Consulta();
                var livros = ler.buscaArquivo();
                Book result = new Book();


                foreach (var livro in livros)
                {
                    if (livro.getName().Equals(context.GetRouteValue("book").ToString()))
                    {
                        result = livro;
                    }
                }

                if (result.getName() != null)
                {
                    var html = $"<pre style='color:red'>{livros[0].ToString()}</pre>";
                    return context.Response.WriteAsync(html);
                }

                return context.Response.WriteAsync("Livro Não encontrado");
            }

        }

    }
}
