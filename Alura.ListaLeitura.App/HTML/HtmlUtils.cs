using System.IO;

namespace Alura.ListaLeitura.App.HTML
{
    public class HtmlUtils
    {
        public static string CarregaHtml(string nomeArquivo)
        {
            var nomeCompleto = $"HTML/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompleto))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
