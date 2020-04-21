using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);
            return "O livro foi adicionado com sucesso!";
        }

        public static Task ExibeForm(HttpContext context)
        {
            var html = HtmlUtils.CarregaHtml("form");

            return context.Response.WriteAsync(html);
        }
    }
}
