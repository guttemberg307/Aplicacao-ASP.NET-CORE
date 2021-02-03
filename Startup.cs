using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)//Containers da aplicação de serviços
        {

            //services.AddTransient<ICatalogo, Catalogo>(); //AddTransient adicionar um transitorio ou um serviço TEMPORARIO // instancia temporaria
            //services.AddTransient<IRelatorio, Relatorio>();//Objetos transitórios são sempre diferentes; uma nova instância é fornecida cada vez que o objeto é solicitado.


            //services.AddScoped<ICatalogo, Catalogo>();//AddScoped gera somente uma instancia do serviço a cada requisiçao atravez do navegador 
            //services.AddScoped<IRelatorio, Relatorio>();//Objetos com escopo são os mesmos em uma requisições, mas diferentes entre requisições diferentes.


            var catalogo = new Catalogo();
            services.AddSingleton<ICatalogo>(catalogo); //AddSingleton trabalha somente com uma instancia, tanto de catalogo quanto de relatorio 
            services.AddSingleton<IRelatorio>(new Relatorio(new Catalogo())); //Objetos singleton são os mesmos para todas as requisições.



        }

        //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)// IServiceProvider serviceProvider ->> esse parametro é responsavel em obter as intancias das classes catalogo e relatorio
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();// serviceProvider.GetService pede a instacia da classe catalogo no lugar do operador NEW  
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();
            app.Run(async (context) =>
            {
                relatorio.Imprimir(context);
            });

        }
    }
}
