using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            //builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);
            builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivro);
            //{id:int} so vai aceitar valores do tipo inteiro na requisição
            builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes);

            builder.MapRoute("Cadastro/ExibeForm", CadastroLogica.ExibeForm);
            builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);

            var rotas = builder.Build();
            app.UseRouter(rotas);
        }
    }
}