using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Pratique_02
{
    internal class DistributionNormale:Distribution
    {
            private double moyenne;
            private double ecartType;
            private static Random random = new Random();

            public DistributionNormale(int taille, double moyenne, double ecartType)
                : base(taille)
            {
                this.moyenne = moyenne;
                this.ecartType = ecartType;
            }

            
        public override void GenererEchantillon()
        {
            echantillon.Clear();

            for (int i = 0; i < tailleEchantillon / 2; i++)
            {
                double u1 = 1.0 - random.NextDouble();
                double u2 = 1.0 - random.NextDouble();
                double z1 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
                double z2 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

                echantillon.Add(z1 * ecartType + moyenne);
                if (echantillon.Count < tailleEchantillon)
                    echantillon.Add(z2 * ecartType + moyenne);
            }

            Console.WriteLine("\nÉchantillon normal généré :");
            foreach (var v in echantillon)
                Console.Write($"{v:F2} ");
            Console.WriteLine("\n");
        }
        public override double MoyenneTheorique() => moyenne;
            public override double VarianceTheorique() => Math.Pow(ecartType, 2);
        }

    }
