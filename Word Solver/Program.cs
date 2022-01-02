using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Word_Solver {
    class Program {
        static void Main() {
            List<string> words = new List<string>();

            Console.Write("Name of the text file (including the extension, if there's one): ");
            string fileName = Console.ReadLine();

            try {
                using (StreamReader sr = new StreamReader(fileName)) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        words.Add(line);
                    }
                }
            } catch (FileNotFoundException) {
                using (StreamWriter sw = new StreamWriter(fileName)) {
                    sw.Write("Just created this file for you.\nEdit this file then re-open the program.\nSeparate the words with new lines.");
                }
                Process.Start("notepad.exe", fileName);
                return;
            }

            while (true) {
                Console.Write("Enter the word: ");
                string codedWord = Console.ReadLine();

                Console.WriteLine("Result: " + SolveWord(codedWord, words));
            }
        }

        static string SolveWord(string codedWord, List<string> words) {
            foreach (string word in words) {
                if (word.Length == codedWord.Length) {
                    for (int i = 0; i < codedWord.Length; i++) {
                        if (!word.Contains(codedWord[i]) || !(codedWord.Contains(word[i]))) {
                            break;
                        } else if (word.Contains(codedWord[i]) && i == codedWord.Length - 1) {
                            return word;
                        }
                    }
                }
            }
            return "Not found.";
        }
    }
}