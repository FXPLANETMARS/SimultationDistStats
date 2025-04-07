using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Travail_Pratique_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] anciensFichiers = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            foreach (string fichier in anciensFichiers)
            {
                File.Delete(fichier);
            }

            DistributionNormale distributionNormale = null;
            DistributionBinomiale distributionBinomiale = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Simulateur de Distribution Statistiques!");
                Console.WriteLine("****************************************");
                Console.WriteLine("Option 1- Generer un Echantillon");
                Console.WriteLine("Option 2- Afficher les statistiques d'un echantillon");
                Console.WriteLine("Option 3- Comparer la moyenne theorique et la moyenne empirique");
                Console.WriteLine("Option 4- Quitter et sauvegarder les statistiques");
                Console.Write("\nOption ? : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine("\n--- Génération d’un échantillon ---");
                        Console.WriteLine("N - Distribution normale");
                        Console.WriteLine("B - Distribution binomiale");
                        Console.WriteLine("M - Retour au menu principal");
                        Console.Write("\nVotre choix ? : ");
                        string type = Console.ReadLine().ToUpper();

                        if (type == "N")
                        {
                            Console.Write("Taille de l’échantillon : ");
                            int taille = int.Parse(Console.ReadLine());
                            Console.Write("Moyenne théorique : ");
                            double moyenne = double.Parse(Console.ReadLine());
                            Console.Write("Écart-type : ");
                            double ecartType = double.Parse(Console.ReadLine());

                            distributionNormale = new DistributionNormale(taille, moyenne, ecartType);
                            distributionNormale.GenererEchantillon();
                            distributionNormale.AfficherStatistiques();
                            Console.ReadKey();
                        }
                        else if (type == "B")
                        {
                            Console.Write("Taille de l’échantillon : ");
                            int taille = int.Parse(Console.ReadLine());
                            Console.Write("Nombre total d’essais : ");
                            int essais = int.Parse(Console.ReadLine());
                            Console.Write("Probabilité de succès : ");
                            double proba = double.Parse(Console.ReadLine());

                            distributionBinomiale = new DistributionBinomiale(taille, essais, proba);
                            distributionBinomiale.GenererEchantillon();
                            distributionBinomiale.AfficherStatistiques();
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n--- Statistiques d’un échantillon ---");
                        Console.WriteLine("N - Distribution normale");
                        Console.WriteLine("B - Distribution binomiale");
                        Console.WriteLine("M - Retour au menu principal");
                        Console.Write("\nVotre choix ? : ");
                        string stat = Console.ReadLine().ToUpper();

                        if (stat == "N")
                        {
                            if (distributionNormale != null)
                                distributionNormale.AfficherStatistiques();
                            else
                                Console.WriteLine("Aucun échantillon normal n’a encore été généré.");
                            
                        }
                        else if (stat == "B")
                        {
                            if (distributionBinomiale != null)
                                distributionBinomiale.AfficherStatistiques();
                            else
                                Console.WriteLine("Aucun échantillon binomial n’a encore été généré.");
                            
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("\n--- Comparaison des moyennes ---");
                        Console.WriteLine("N - Distribution normale");
                        Console.WriteLine("B - Distribution binomiale");
                        Console.WriteLine("M - Retour au menu principal");
                        Console.Write("\nVotre choix ? : ");
                        string comp = Console.ReadLine().ToUpper();

                        if (comp == "N")
                        {
                            if (distributionNormale != null)
                                distributionNormale.ComparerMoyennes();
                            else
                                Console.WriteLine("Échantillon non généré.");
                        }
                        else if (comp == "B")
                        {
                            if (distributionBinomiale != null)
                                distributionBinomiale.ComparerMoyennes();
                            else
                                Console.WriteLine("Échantillon non généré.");
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("\n--- Sauvegarde des distributions ---");

                        if (distributionNormale != null)
                        {
                            string fichierNormal = "distribution_normale.txt";
                            File.WriteAllText(fichierNormal, distributionNormale.ToString());
                            Console.WriteLine($"Fichier sauvegardé : {fichierNormal}");
                        }

                        if (distributionBinomiale != null)
                        {
                            string fichierBinomiale = "distribution_binomiale.txt";
                            File.WriteAllText(fichierBinomiale, distributionBinomiale.ToString());
                            Console.WriteLine($"Fichier sauvegardé : {fichierBinomiale}");
                        }

                        Console.WriteLine("\nFermeture du programme...");
                        return;

                    default:
                        Console.WriteLine("Option invalide. Appuyez sur une touche pour continuer.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
