using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Interfaces;
using BlackVinil.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using TestesBlckVinil.IoC;

namespace TestesBlckVinil
{
    class Program
    {
        private static readonly IAppDiscoService _discos;        

        static void Main(string[] args)
        {
            FormResolve.Wire(ModuloNinject.Create());
            FormResolve.Resolve<Program>();

            double ret = CashBack.Calcular(GeneroMusical.MPB);

            //DiscoRepository disco = new DiscoRepository();
            Console.WriteLine("Digite 1 para sair:");
            while (Console.ReadLine() != "1")
            {
                IEnumerable<Disco> a = null;//_discos.GetAllSpotfyApi(GeneroMusical.MPB);
                foreach (Disco d in a)
                {
                    Console.WriteLine("ID : " + d.Id);
                    Console.WriteLine("NOME : " + d.Nome);
                    Console.WriteLine("ANO : " + d.Ano);
                    Console.WriteLine("Href : " + d.href);
                    Console.WriteLine("Imagem : " + d.Imagem);
                    Console.WriteLine("Preço : " + d.Preco.ToString("n2"));
                    Console.WriteLine("CashBack : " + (d.CashBack / 100).ToString("P0"));
                    Console.WriteLine("GENERO : " + d.Genero);
                   
                    Console.WriteLine("----------------- ");
                }
                Console.WriteLine("Digite 1 para sair");
            }


            Console.ReadKey();

            Console.WriteLine(ret.ToString("n2"));
            Console.ReadKey();
        }
    }
}
