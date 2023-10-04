using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SCHNELZAUER_Lucas_TD3_Algo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Afficher les choix à l'utilisateur 
            ColorBlue();
            Console.WriteLine("Veuillez sélectionner votre choix : ");
            resetColor();
            Console.WriteLine("(1) Lister les renseignements du fichier");
            Console.WriteLine("(2) Lister les renseignements du fichier en respectant les caractéristiques");
            Console.WriteLine("(3) Un calcul statistique");
            resetColor();
            //Attribution de la valeur de l'utilisateur à la variable choix de type chaine
            string choix = Console.ReadLine();
            //Convertir la chaine en entier
            Int32 choixutilisateur = Convert.ToInt32(choix);



            switch (choixutilisateur)
            {
                case 1:
                    ColorBlue();
                    Console.WriteLine("Voici la liste du fichier Etudiants :");
                    resetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Déclaration du fichier Etudiant en utilisation la Méthode ReadFile  
                    ReadFile("Etudiants.txt");
                    break; // Le "break" est utilisé pour sortir du switch une fois l'option traitée


                case 2:
                    //Déclaration du fichier Etudiant en utilisation la Méthode ReadFile
                    ReadFile2("Etudiants.txt");

                    break;
       

                case 3:
                    Console.WriteLine("Calcul des statistiques :");
                    ReadFile3("Etudiants.txt");
                    break;

                default:
                    Console.WriteLine("Choix non reconnu.");
                    // Code  exécuter si aucune des options ne correspond à la valeur de choix
                    break;

            }


            Console.ReadLine();



        }
        //Méthode pour lire le fichier Etudiants
        private static int ReadFile(string fileName)
        {
            //Permet de lire un fichier 
            StreamReader lecteur = new StreamReader(fileName);
            String line = "";
            int numberOfChars = 0;


            while (line != null)
            {
                line = lecteur.ReadLine();

                if (line != null)
                {
                    numberOfChars += line.Length;
                    Console.WriteLine(line);
                }

            }

            lecteur.Close();
            return numberOfChars;
        }

        //Méthode pour le choix n°2
        private static void ReadFile2(string fileName)
        {
            //Permet de lire un fichier 
            StreamReader lecteur = new StreamReader(fileName);
            String line = "";
            int nombreligne = 0; // Pour alterner les couleurs

            while (line != null)
            {
                line = lecteur.ReadLine();

                if (line != null)
                {
                    // Séparer chaque partie en utilisant les tabulations du fichier Etudiant.txt
                    string[] parts = line.Split('\t');


                    
                    if (parts.Length >= 5)
                    {
                        // Les parties sont indexées à partir de 0
                        string nomEtudiant = parts[0].Trim(); // Enleve les espaces entre chaque mots
                        string prenomEtudiant = parts[1].Trim().ToUpper(); // Met le prénom en majuscule
                        string dateNaissance = parts[2].Trim(); //
                        string sexe = parts[3].Trim();
                        string baccalaureat = parts[4].Trim();

                        

                        // Si le numéro de la ligne est pair alors on met la couleur en bleu foncé 
                        if (nombreligne % 2 == 0 )
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else // Sinon on met la couleur du texte en rouge
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        // Convertir la date en un objet
                        DateTime date;
                        if (DateTime.TryParse(dateNaissance, out date))
                        {
                            // Transformer la date au format demandé Mardi 18 Avril 1980 
                            string dateformat = date.ToString("dddd dd MMMMMM yyyy");
                            // Afficher les informations formatées de type NOM PRENOM  Mardi 18 Avril 1980 G/F BAC
                            Console.WriteLine($"{nomEtudiant} {prenomEtudiant} {dateformat} {sexe} {baccalaureat}");


                        }
                        else
                        {
                            Console.WriteLine("Une erreur est survenue"); // En cas d'erreur, renvoyer la date brute
                        }

                        

                        // Incrémenter le compteur de lignes
                        nombreligne++;
                    }
                }
            }

            lecteur.Close();

        }

        //Méthode pour lire le fichier Etudiants pour le choix n°3
        private static void ReadFile3(string fileName)
        {
            //Permet de lire un fichier 
            StreamReader lecteur = new StreamReader(fileName);
            String line = "";
            int TotalEtudiants = 0;
            int Masculin = 0;
            int Féminin = 0;

            while (line != null)
            {
                line = lecteur.ReadLine();

                if (line != null)
                {
                    // Séparer chaque partie en utilisant les tabulations du fichier Etudiant.txt
                    string[] parts = line.Split('\t');

                    // Si les parts ont une longueur supérieur ou égale a 4 alors
                    if (parts.Length >= 5)
                    {
                        // Attribution de la position 3 du tableau parts à la variable sexe
                        string sexe = parts[3].Trim();

                        // Vérifiez si la position 3 dispose d'une lettre G ou F et incrémente les différents sexe
                        if (sexe == "G" | sexe == "g")
                        {
                            Masculin++;
                        }
                        else if (sexe == "F" | sexe =="f")
                        {
                            Féminin++;
                        }

                        // Incrémente le nombre totale d'étudiants
                        TotalEtudiants++;
                    }
                }
            }

            //Calcule le pourcentage des étudiants parmi le nombre total d'étudiants et affiche ce pourcentage avec deux décimales après la virgule
            Console.WriteLine($"Nombre d'étudiants de sexe Masculin : {Masculin} Hommes soit {((double)Masculin / TotalEtudiants * 100):F2}% des étudiants");
            Console.WriteLine($"Nombre d'étudiants de sexe Féminin   : {Féminin} Femmes soit {((double)Féminin / TotalEtudiants * 100):F2}% des étudiants");
            Console.WriteLine($"Nombre total d'étudiants : {TotalEtudiants}");



            lecteur.Close();
        }

        //Méthode qui va réinitialiser la couleur d'origine du texte (blanc)
        private static void resetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }


        //Méthode qui va attribuer la couleur bleu au texte
        private static void ColorBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}

