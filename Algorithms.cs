using System.Text;

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
                    string s = algorithms[algo] + (key ? "1" : "0");
                    return s;

                    //case Algo.decalageSolution:
                    //    int key

            }

            return message;
        }


        #region Chahinez
        public static string DecalerCrypter(string message, bool versLaGauche)
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
                string motDecale = DecalerCrypter(mot, versLaGauche); // Décale chaque mot
                phraseDecalee.Append(motDecale).Append(' '); // Ajoute le mot décalé à la phrase décalée
            }

            return phraseDecalee.ToString().Trim(); // Supprime l'espace final et retourne la phrase décalée
        }

        public static string DecalerDecrypt(string message, bool versLaGauche)
        {
            return DecalerPhrase(message, !versLaGauche);
        }

        static readonly int ALPHABET_SIZE = 26; // Taille de l'alphabet anglais

        // Fonction de chiffrement affine
        public static string AffineCrypt(string message, int a, int b)
        {
            StringBuilder encryptedMessage = new();

            foreach (char character in message)
            {
                if (char.IsLetter(character))
                {
                    int x = character - (char.IsUpper(character) ? 'A' : 'a');
                    int y = (a * x + b) % ALPHABET_SIZE;
                    if (y < 0) y += ALPHABET_SIZE; // Gestion des valeurs négatives
                    encryptedMessage.Append((char)(y + (char.IsUpper(character) ? 'A' : 'a')));
                }
                else
                {
                    encryptedMessage.Append(character); // Ne pas chiffrer les caractères non alphabétiques
                }
            }

            return encryptedMessage.ToString();
        }

        // Fonction de déchiffrement affine
        public static string AffineDecrypt(string message, int a, int b)
        {
            StringBuilder decryptedMessage = new();

            // Calcul de l'inverse multiplicatif de a modulo ALPHABET_SIZE (si possible)
            int aInverse = -1;
            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if ((a * i) % ALPHABET_SIZE == 1)
                {
                    aInverse = i;
                    break;
                }
            }

            if (aInverse == -1)
            {
                Console.WriteLine("Impossible de déchiffrer. 'a' n'a pas d'inverse.");
                return null;
            }

            foreach (char character in message)
            {
                if (char.IsLetter(character))
                {
                    int y = character - (char.IsUpper(character) ? 'A' : 'a');
                    int x = (aInverse * (y - b)) % ALPHABET_SIZE;
                    if (x < 0) x += ALPHABET_SIZE; // Gestion des valeurs négatives
                    decryptedMessage.Append((char)(x + (char.IsUpper(character) ? 'A' : 'a')));
                }
                else
                {
                    decryptedMessage.Append(character); // Ne pas déchiffrer les caractères non alphabétiques
                }
            }

            return decryptedMessage.ToString();
        }

        public static bool ValiderParametres(int a, int b)
        {
            // Vérifier que a est différent de 1 et b est different de 0 because x*1+0=maderna walo
            if (a == 1 && b == 0)
            {
                Console.WriteLine("Attention : lorsque 'a' vaut 1 et 'b' vaut 0, le chiffrement affine ne produit aucun chiffrement réel.");
                return false;
            }

            // Vérifier que a est premier avec ALPHABET_SIZE
            if (Pgcd(a, ALPHABET_SIZE) != 1)
            {
                Console.WriteLine("La valeur de 'a' n'est pas valide. 'a' doit être premier avec " + ALPHABET_SIZE + ".");
                return false;
            }

            // Vérifier que b est un entier valide
            if (b < 0 || b >= ALPHABET_SIZE)
            {
                Console.WriteLine("La valeur de 'b' n'est pas valide. 'b' doit être compris entre 0 et " + (ALPHABET_SIZE - 1) + ".");
                return false;
            }

            return true;
        }

        static int Pgcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return Pgcd(b, a % b);
            }
        }
        static int tailleDesiree = 0;

        public static string DecalageSolutionCrypt(string message, int cle, int tailleDesiree)
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

        public static string DecalageSolutionDecrypt(string messageCrypte, int cle)
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

        static readonly int ASCII_SIZE = 256; // Taille de l'alphabet ASCII étendu

        // Fonction de chiffrement affine
        public static string AffineSolutionCrypt(string message, int a, int b)
        {
            System.Text.StringBuilder encryptedMessage = new System.Text.StringBuilder();

            foreach (char character in message)
            {
                int x = character;
                int y = (a * x + b) % ASCII_SIZE;
                if (y < 0) y += ASCII_SIZE; // Gestion des valeurs négatives
                encryptedMessage.Append((char)y);
            }

            return encryptedMessage.ToString();
        }

        // Fonction de déchiffrement affine
        public static string AffineSolutionDecrypt(string message, int a, int b)
        {
            System.Text.StringBuilder decryptedMessage = new System.Text.StringBuilder();

            // Calcul de l'inverse multiplicatif de a modulo ALPHABET_SIZE (si possible)
            int aInverse = -1;
            for (int i = 0; i < ASCII_SIZE; i++)
            {
                if ((a * i) % ASCII_SIZE == 1)
                {
                    aInverse = i;
                    break;
                }
            }

            if (aInverse == -1)
            {
                Console.WriteLine("Impossible de déchiffrer. 'a' n'a pas d'inverse.");
                return null;
            }

            // Définir la longueur du message déchiffré sur celle du message chiffré
            int decryptedLength = message.Length;

            foreach (char character in message)
            {
                int y = character;
                int x = (aInverse * (y - b)) % ASCII_SIZE;
                if (x < 0) x += ASCII_SIZE; // Gestion des valeurs négatives
                decryptedMessage.Append((char)x);
            }

            // Retirer les caractères supplémentaires du message déchiffré
            return decryptedMessage.ToString();
        }

        //public char[] CipherCode(int number)
        //{
        //    var charA = 'a';
        //    var result = new char[ALPHABET_SIZE];

        //    for (int i = 0; i < ALPHABET_SIZE; i++)
        //    {
        //        var code = (charA + number);
        //        if (code > 'z')
        //        {
        //            code -= ALPHABET_SIZE;
        //        }

        //        result[i] = (char)code;
        //    }

        //    return result;

        //}

        public static string CaesarEncrypt(string message, int shift)
        {
            char[] encryptedMessage = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char character = message[i];
                if (char.IsLetter(character))
                {
                    char baseChar = char.IsUpper(character) ? 'A' : 'a';
                    char encryptedChar = (char)(((character - baseChar + shift) % 26) + baseChar);
                    if (encryptedChar < baseChar)
                    {
                        encryptedChar += (char)26;
                    }
                    encryptedMessage[i] = encryptedChar;
                }
                else
                {
                    encryptedMessage[i] = character;
                }
            }

            return new string(encryptedMessage);
        }

        public static string CaesarDecrypt(string encryptedMessage, int shift)
        {
            return CaesarEncrypt(encryptedMessage, 26 - shift);
        }

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
