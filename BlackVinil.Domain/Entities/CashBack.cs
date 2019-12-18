using System;
using System.Collections.Generic;
using System.Text;

namespace BlackVinil.Domain.Entities
{
    public class CashBack
    {
        public static double Calcular(GeneroMusical generoMusical)
        {
            return ((Preco(generoMusical) / 100) * ValorDia(generoMusical));
        }

        private static int ValorDia(GeneroMusical generoMusical)
        {
            int dia = (int)DateTime.Now.DayOfWeek;
            int[] pop = { 25, 7, 6, 2, 10, 15, 20 };
            int[] mpb = { 30, 5, 10, 15, 20, 25, 30 };
            int[] classic = { 35, 3, 5, 8, 13, 18, 25 };
            int[] rock = { 40, 10, 15, 15, 15, 20, 40 };

            switch (generoMusical)
            {
                case GeneroMusical.POP:
                    return pop[dia];
                case GeneroMusical.MPB:
                    return mpb[dia];
                case GeneroMusical.CLASSIC:
                    return classic[dia];
                case GeneroMusical.ROCK:
                    return rock[dia];
                default:
                    return 0;
            }
        }

        public static double Preco(GeneroMusical generoMusical)
        {
            switch (generoMusical)
            {
                case GeneroMusical.POP:
                    return 26.99;
                case GeneroMusical.MPB:
                    return 29.99;
                case GeneroMusical.CLASSIC:
                    return 40.89;
                case GeneroMusical.ROCK:
                    return 25.00;
                default:
                    return 1;
            }
        }

    }

    public enum GeneroMusical
    {
        POP = 0,
        MPB = 1,
        CLASSIC = 2,
        ROCK = 3
    }


}
