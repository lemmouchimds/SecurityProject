namespace SecurityAPI
{
    public record Code(string code);

    public enum Algo
    {
        decalage, 
        ceasar, 
        affine, 
        decalageSolution,
        
    }

    public class Algorithms
    {
        static Dictionary<Algo, string> algorithms = new Dictionary<Algo, string>()
        {
            {Algo.decalage,  "d"}, {Algo.ceasar, "e"}, {Algo.decalageSolution, "ds"}, {Algo.affine, "a"}
        }
        ;

        public static string PostCrypt(string message, Algo algo, List<object> cles)
        {
            switch (algo)
            {
                case Algo.decalage:
                    bool key = bool.Parse(cles.First().ToString()!);
                    string s = algorithms[algo] + (key? "1": "0");
                    return s;
                    
                //case Algo.decalageSolution:
                //    int key

            }

            return message;
        }


        #region Chahinez
        public static string Decaler(string message, bool versLaGauche)
        {
            if (string.IsNullOrEmpty(message))
            {
                return message;
            }

            if (versLaGauche)
            {
                // shift to the left
                message = message[1..] + message[0];
            }
            else
            {
                // shift to the right
                message = message[^1] + message[..^1];
            }

            return message; // Retourne le message décalé
        }

        public static string DecalerPhrase(string phrase, bool versLaGauche)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }

            string[] mots = phrase.Split(' '); // Sépare la phrase en mots

            System.Text.StringBuilder phraseDecalee = new();

            foreach (string mot in mots)
            {
                string motDecale = Decaler(mot, versLaGauche); // Décale chaque mot
                phraseDecalee.Append(motDecale).Append(' '); // Ajoute le mot décalé à la phrase décalée
            }

            return phraseDecalee.ToString().Trim(); // Supprime l'espace final et retourne la phrase décalée
        }

        public static string DecalerInverse(string message, bool versLaGauche)
        {
            if (string.IsNullOrEmpty(message))
            {
                return message;
            }

            if (versLaGauche)
            {
                // shift to the right
                message = message[^1] + message[..^1];
            }
            else
            {
                // shift to the left
                message = message.Substring(1) + message[0];
            }

            return message; // Retourne le message décalé
        }

        //public static void Main(string[] args)
        //{
        //    Console.Write("Entrez la phrase: ");
        //    string phrase = Console.ReadLine();

        //    Console.Write("Voulez-vous décaler vers la gauche (true) ou vers la droite (false) ? ");
        //    bool versLaGauche = bool.Parse(Console.ReadLine());

        //    string phraseDecalee = DecalerPhrase(phrase, versLaGauche);
        //    Console.WriteLine("Phrase décalée: " + phraseDecalee);
        //    string phraseDecryptee = DecalerPhrase(phraseDecalee, !versLaGauche);
        //    Console.WriteLine("Phrase déchiffrée: " + phraseDecryptee);
        //}


        static int tailleDesiree = 0;

        public static string Crypter(string message, int cle, int tailleDesiree)
        {
            System.Text.StringBuilder messageCrypte = new System.Text.StringBuilder();
            foreach (char caractere in message)
            {
                // Conversion en code ASCII
                int ascii = (int)caractere;
                // Décalage du code ASCII
                ascii = (ascii + cle) % 128; // ASCII va de 0 à 127
                                             // Conversion du code ASCII décalé en caractère
                char nouveauCaractere = (char)ascii;
                messageCrypte.Append(nouveauCaractere);
            }
            // Remplissage jusqu'à atteindre la taille désirée
            while (messageCrypte.Length < tailleDesiree)
            {
                messageCrypte.Append('*'); // Caractère de remplissage, peut être modifié selon les besoins
            }
            return messageCrypte.ToString();
        }

        public static string Decrypter(string messageCrypte, int cle)
        {
            System.Text.StringBuilder messageDecrypte = new System.Text.StringBuilder();
            foreach (char caractere in messageCrypte)
            {
                if (caractere != '*') // Ne pas inclure les caractères de remplissage
                {
                    // Conversion en code ASCII
                    int ascii = (int)caractere;
                    // Décalage inverse du code ASCII
                    ascii = (ascii - cle) % 128;
                    // Assurer que le résultat reste dans la plage ASCII
                    if (ascii < 0)
                    {
                        ascii += 128;
                    }
                    // Conversion du code ASCII décalé en caractère
                    char nouveauCaractere = (char)ascii;
                    messageDecrypte.Append(nouveauCaractere);
                }
            }
            return messageDecrypte.ToString();
        }

        //public static void Main(string[] args)
        //{
        //    Console.Write("Entrez la phrase: ");
        //    string messageClair = Console.ReadLine();
        //    int cle = 3; // La clé de décalage (peut être ajustée selon les besoins)
        //                 // La taille désirée du message crypté
        //    Console.Write("Entrez la taille desiree: ");
        //    tailleDesiree = int.Parse(Console.ReadLine());
        //    // Cryptage
        //    string messageCrypte = Crypter(messageClair, cle, tailleDesiree);
        //    Console.WriteLine("Message crypté: " + messageCrypte);

        //    // Décryptage
        //    string messageDecrypte = Decrypter(messageCrypte, cle);
        //    Console.WriteLine("Message décrypté: " + messageDecrypte);
        //}

        #endregion

        #region Abdou
        public static string Mirroir(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return message;
            }

            System.Text.StringBuilder messageMirroir = new System.Text.StringBuilder();

            for (int i = message.Length - 1; i >= 0; i--)
            {
                messageMirroir.Append(message[i]);
            }

            return messageMirroir.ToString(); // Retourne le message miroir
        }

        public static string MirroirPhrase(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }

            string[] mots = phrase.Split(' '); // Sépare la phrase en mots

            System.Text.StringBuilder phraseMirroir = new System.Text.StringBuilder();

            foreach (string mot in mots)
            {
                string motMirroir = Mirroir(mot); // Miroir chaque mot
                phraseMirroir.Append(motMirroir).Append(" "); // Ajoute le mot miroir à la phrase miroir
            }

            return phraseMirroir.ToString().Trim(); // Supprime l'espace final et retourne la phrase miroir
        }

        //fonction mirroir pour les mots paleindromes, il faut faire un decalage apres le mirroir


        #endregion
    }
}
