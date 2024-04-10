using System;

namespace DailyScripture
{
        public class Reference
    {
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }

        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            Verse = verse;
        }
    }
}