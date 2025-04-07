using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_Pratique_02
{
    internal abstract class Distribution
    {
        public int tailleEchantillon { get; set; }
        public List<double> echantillon { get; protected set; } = new List<double>();
        public double moyenneTheorique { get; protected set; }
        public double varianceTheorique { get; protected set; }
        public Distribution(int taille)
        {
            tailleEchantillon = taille;
        }

        public virtual void AfficherStatistiques()
        {
            if (echantillon.Count == 0)
            {
                Console.WriteLine("Aucun échantillon n'a été généré.");
                return;
            }

            double moyenne = echantillon.Average();
            double variance = echantillon.Select(x => Math.Pow(x - moyenne, 2)).Average();
            double ecartType = Math.Sqrt(variance);

            Console.WriteLine($"\nMoyenne empirique : {moyenne:F2}");
            Console.WriteLine($"Variance empirique : {variance:F2}");
            Console.WriteLine($"Écart-type empirique : {ecartType:F2}\n");
        }
        public virtual void ComparerMoyennes()
        {
            if (echantillon.Count == 0)
            {
                Console.WriteLine("Aucun échantillon n'a été généré.");
                return;
            }

            double moyenneEmpirique = echantillon.Average();
            Console.WriteLine($"\nMoyenne théorique : {moyenneTheorique:F2}");
            Console.WriteLine($"Moyenne empirique : {moyenneEmpirique:F2}\n");
        }
        public virtual void Sauvegarder(string nomFichier)
        {
            using (StreamWriter writer = new StreamWriter(nomFichier))
            {
                foreach (var valeur in echantillon)
                {
                    writer.WriteLine(valeur);
                }
            }
            Console.WriteLine($"Échantillon sauvegardé dans le fichier : {nomFichier}\n");
        }
        public abstract void GenererEchantillon();
        public double CalculerMoyenneEmpirique() => echantillon.Average();
        public double CalculerVarianceEmpirique()
        {
            double moyenne = CalculerMoyenneEmpirique();
            return echantillon.Select(x => Math.Pow(x - moyenne, 2)).Average();
        }
        public double CalculerEcartTypeEmpirique() => Math.Sqrt(CalculerVarianceEmpirique());
        public abstract double MoyenneTheorique();
        public abstract double VarianceTheorique();

        public override string ToString()
        {
            return string.Join(", ", echantillon.Select(v => v.ToString("F2")));
        }
    }
}

