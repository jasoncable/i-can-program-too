﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace JasonCable.SampleConsoleApp3and8
{
    public class ProgrammingStyle : IProgrammingLanguage
    {
        public static readonly LanguageFamilyType Family = 
            LanguageFamilyType.ObjectOriented;

        public const int DB_TIMEOUT = 60;

        private string _myName;

        public ProgrammingStyle()
        {
            _myName = "C#";
        }

        public ProgrammingStyle(string formalName)
        {
            _myName = formalName;
        }

        public string Name { get; set; }
        public List<decimal> Versions = new List<decimal>();

        public decimal? GetFirstVersion()
        {                
            return Versions.FirstOrDefault(); 
        }

        public string MyName
        {
            get
            {
                return _myName;
            }

            private set
            {
                _myName = value;
            }
        }
    }

    public interface IProgrammingLanguage
    {
        string Name { get; set; }
    }

    public enum LanguageFamilyType
    {
        Functional = 1,
        ObjectOriented = 2
    }
}
