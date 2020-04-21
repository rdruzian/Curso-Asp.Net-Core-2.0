using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public static Task Incluir(HttpContext context)
        {
            var livro = new Livro()
            {
                //Converte o que vem da requisição para montar o objeto
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First(),
            };
            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }

        public static Task ExibeForm(HttpContext context)
        {
            var html = HtmlUtils.CarregaHtml("form");

            return context.Response.WriteAsync(html);
        }

        public static Task NovoLivro(HttpContext context)
        {
            var livro = new Livro()
            {
                //Converte o que vem da requisição para montar o objeto
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString(),
            };
            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }
    }
}
