using System;
using System.Collections.Generic;
using System.Linq;
using WordScramblerApp.Actions;
using WordScramblerApp.Data;

namespace WordScramblerApp
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();



        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine(Constants.OptionsForEnteringScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordManualEntryScenario();

                            break;
                        default:
                            Console.Write(Constants.EnterScrambledWordsOptionNotRecognize);
                            break;

                    }

                    var decision = string.Empty; // Either True or False
                    do
                    {
                        Console.WriteLine(Constants.OptionsForContinouingProgramme);
                        decision = (Console.ReadLine() ?? string.Empty); // Coalescing

                    } while (!decision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                             !decision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = decision.Equals
                        (Constants.Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }

        }


        private static void ExecuteScrambledWordManualEntryScenario()
        {
            var manualInput = (Console.ReadLine() ?? string.Empty);
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedWords(scrambledWords);

        }


        private static void ExecuteScrambledWordInFileScenario()
        {
            try
            {
                var fileName = (Console.ReadLine() ?? string.Empty);
                string[] scrambledWords = _fileReader.Read(fileName);
                DisplayMatchedWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }


        }


        private static void DisplayMatchedWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedword in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedword.ScrambleWord, matchedword.Word);

                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);

            }
        }
    }
}
