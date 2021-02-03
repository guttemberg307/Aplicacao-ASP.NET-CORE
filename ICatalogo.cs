using System.Collections.Generic;

namespace Web
{
    public interface ICatalogo // essa interface se torna idependente 
    {
        List<Livro> Getlivros();
    }
}