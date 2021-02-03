using Microsoft.AspNetCore.Http;

namespace Web
{
    public interface IRelatorio // essa interface se torna idependente
    {
        void Imprimir(HttpContext context);
    }
}