using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Pratique_02
{
    internal class DistributionBinomiale:Distribution
    {

        private int essais;
        private double probabilite;
        private static Random random = new Random();

        public DistributionBinomiale(int taille, int essais, double probabilite)
            : base(taille)
        {
            this.essais = essais;
            this.probabilite = probabilite;
        }

        public override void GenererEchantillon()
        {
            echantillon.Clear();

            for (int i = 0; i < tailleEchantillon; i++)
            {
                int succes = 0;
                for (int j = 0; j < essais; j++)
                {
                    if (random.NextDouble() < probabilite)
                        succes++;
                }
                echantillon.Add(succes);
            }

            Console.WriteLine("\nÉchantillon binomial généré :");
            foreach (var v in echantillon)
                Console.Write($"{v} ");
            Console.WriteLine("\n");
        }

        public override double MoyenneTheorique() => essais * probabilite;
        public override double VarianceTheorique() => essais * probabilite * (1 - probabilite);

    }
}
