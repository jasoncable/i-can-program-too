using System;
namespace SampleConsoleApp.Chapter10
{
    public class Letter
    {
        private char[] _sa = { 'a', 'b', 'c', 'd' };
        //public Letter(char c) => Current = c;
        //public char Current { get; set; }

        public char this[int i]
        {
            get
            {
                return _sa[i];
            }
            set
            {
                _sa[i] = value;
            }
        }
    }

    public class LetterA
    {
        private char[] _sa = { 'a', 'b', 'c', 'd' };
        public LetterA(char c) => Current = c;
        public char Current { get; set; }

        public char this[int i] => _sa[i];
    }

    public class LetterB
    {
        private char[] _sa = { 'a', 'b', 'c', 'd' };
        public LetterB(char c) => Current = c;
        public char Current { get; set; }

        public char this[int i]
        {
            get => _sa[i];
            set => _sa[i] = value;
        }
    }
}
