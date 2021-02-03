using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Catalogo : ICatalogo // interface 
    // essa classe foi criada para organizar e otimizar o codigo
    {
        public List<Livro> Getlivros() //Getlivros vai ser do tipo lista de livros 
        {
            var livros = new List<Livro>(); // instancia uma lista de livros 
            livros.Add(new Livro("001", " Recursao ", 12.99m));// final "m" define que o numero é decimal 
            livros.Add(new Livro("002", " Materia Escura ", 35.99m));
            livros.Add(new Livro("003", " O Homem de Giz ", 45.99m));// livros.add() adiciona o livro na lista de livros  


            return livros;// retorna a variavel livros 

        }

    }
}
