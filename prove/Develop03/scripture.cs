using System;

namespace DailyScripture
{
   public class Scripture
    {
        public Reference Reference { get; set; }
        private List<Word> Words;
        private Random Random = new Random();

        public Scripture(string book, int chapter, int verse, string text)
        {
            Reference = new Reference(book, chapter, verse);
            Words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        public void Display()
        {
            Console.WriteLine($"{Reference.Book} {Reference.Chapter}:{Reference.Verse}");
            foreach (var word in Words)
            {
                Console.Write(word.IsHidden ? "___ " : $"{word.Text} ");
            }
            Console.WriteLine();
        }

        public bool HideRandomWord()
        {
            var visibleWords = Words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Any())
            {
                var wordToHide = visibleWords[Random.Next(visibleWords.Count)];
                wordToHide.IsHidden = true;
                return true;
            }
            return false;
        }
    }
}