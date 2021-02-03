using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Relatorio : IRelatorio
    {
        private readonly ICatalogo catalogo; // readonly campo somente leitura

        public Relatorio(ICatalogo catalogo)
        {
            this.catalogo = catalogo; // contrutor cheio 
        }
        // HttpContext  é um parametro do html com o nome context
        public async void Imprimir(HttpContext context)// metodo imprime as informções // async quer dizer metodo assincrono 
        {
            foreach (var livro in catalogo.Getlivros())//para cada livro dentro de catalogos
            {
                await context.Response.WriteAsync($"{livro.Codigo,-10}{livro.Nome,-40}{livro.Preco.ToString("C"),10}\r\n");   // imprime todos os livros na tela 
                                                                                                                              // RESPONSE é o objeto que gera resposta que vai ser colocada dentro do html 
                                                                                                                              // -10 alinha a esquerda                                                                                                                
            }
        }
    }
}
