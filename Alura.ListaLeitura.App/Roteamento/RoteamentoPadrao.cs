using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Roteamento
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            //Pega o nome da classe e do método que vem pela URL
            var classe = context.GetRouteValue("classe").ToString();
            var nomeMetodo = context.GetRouteValue("metodo").ToString();
            //Monta o nome da classe
            var nomeClasse = $"Alura.ListaLeitura.App.Logica.{classe}Logica";
            
            var tipo = Type.GetType(nomeClasse);
            //Pega o método dentro da classe
            var metodo = tipo.GetMethods().Where(m => m.Name == nomeMetodo).First();
            //Cria um delegate para montar a reuqisição da URL
            var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);
            //retorna o delegate
            return requestDelegate.Invoke(context);
        }
    }
}
