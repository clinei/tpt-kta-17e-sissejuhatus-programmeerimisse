namespace Hangman {
    using System;
    using System.Collections.Generic;

    public class Program {
        public static void Main(string[] args) {

            // using the Estonian alphabet
            List<char> alphabet = new List<char>("ABDEFGHIJKLMNOPRSTUVÕÄÖÜ");

            char ESC = (char) 27;

            string[] words = new string[] { "TOOMAS", "HENDRIK", "ILVES", "PUUDEL", "PUDEL",
                                            "HELKUR", "HERKULAPUDER", "KANALIHA", "SPAGETID",
                                            "SISESTA", "TÄHTHAAVAL", "SÕNASUPP", "SÕNASEPP" };

            List<char> guesses = new List<char>(alphabet.Count);

            List<char> word = new List<char>();

            List<char> revealed = new List<char>();

            uint lives = 5;

            Random randGen = new Random();

            bool playing = true;

            while (playing) {

                word.Clear();
                word.AddRange(words[randGen.Next(0, words.Length)].ToUpper());
                revealed.Clear();
                guesses.Clear();

                // hide letters
                for (int i = 0; i < word.Count; i++) {
                    revealed.Insert(i, '_');
                }

                lives = 5;

                Console.WriteLine();
                Console.WriteLine("Valisin sõna. Arva see tähthaaval ära.");
                Console.WriteLine("Kui arvad 5 korda valesti, on mäng läbi.");
                Console.WriteLine("Mängust lahkumiseks vajuta Escape.");

                Console.WriteLine();
                Console.WriteLine(String.Join(" ", revealed));

                // main loop
                while (lives > 0) {

                    Console.WriteLine();
                    Console.Write(">>> ");
                    char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                    bool inputValid = false;

                    if (input == ESC) {
                        playing = false;
                        lives = 0;
                        continue;
                    }

                    if (alphabet.Contains(input)) {
                        inputValid = true;

                        Console.WriteLine(input);
                    }

                    bool alreadyGuessed = false;

                    if (guesses.Contains(input)) {
                        alreadyGuessed = true;
                    }

                    bool contains = false;

                    if (inputValid && !alreadyGuessed) {

                        guesses.Add(input);

                        for (int i = 0; i < word.Count; i++) {
                            char c = word[i];

                            if (input == c) {
                                contains = true;
                                revealed[i] = c;
                            }
                        }

                        if (!contains) {
                            lives -= 1;
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine(String.Join(" ", revealed));

                    // check answer
                    if (String.Join("", revealed) != String.Join("", word)) {

                        if (alreadyGuessed) {
                            Console.WriteLine();
                            Console.WriteLine("Seda tähte oled juba pakkunud.");

                        } else {
                            if (!inputValid) {
                                Console.WriteLine();
                                Console.WriteLine("Sisestage ainult eesti keele tähti.");

                            } else {
                                if (!contains) {
                                    Console.WriteLine();
                                    Console.WriteLine("Seda tähte sõnas ei ole.");
                                }
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine("Elusid: {0}", lives);

                        if (lives < 1) {
                            Console.WriteLine();
                            Console.Write("Oled surnud. Proovime uuesti? (Y/n) ");

                            input = Char.ToUpper(Console.ReadKey(true).KeyChar);

                            Console.WriteLine(input);
                            Console.WriteLine();

                            if (input == 'N') {
                                playing = false;
                            }
                        }
                    } else {
                        Console.WriteLine();
                        Console.Write("Võitsid! Mängime uuesti? (Y/n) ");

                        input = Char.ToUpper(Console.ReadKey(true).KeyChar);

                        Console.WriteLine(input);
                        Console.WriteLine();

                        if (input == 'N') {
                            playing = false;
                        }

                        lives = 0;
                    }
                }
            }
        }
    }
}
