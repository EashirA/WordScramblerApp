using System;
using System.Collections.Generic;
using WordScramblerApp.Data;

namespace WordScramblerApp.Actions
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWords(scrambledWord, word));
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWords(scrambledWord, word));

                        }
                    }
                }
            }

            return matchedWords;
        }

        private MatchedWord BuildMatchedWords(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambleWord = scrambledWord,
                Word = word

            };
            return matchedWord;
        }
    }
}
