﻿using System;
namespace SampleConsoleApp.Chapter11
{
    public class MultipleClassInheritance
    {
        public static void RunMe()
        {
            Piano p = new Piano();
            Console.WriteLine(p.Name);
            Console.WriteLine(p.ToString());
        }
    }

    public class Instrument
    {
        public string Name { get; protected set; }

        public virtual void Play() { }

        public override string ToString()
        {
            return Name;
        }
    }

    public class StringInstrument : Instrument
    {
        public StringInstrument()
        {
            base.Name = "Strings Section";
        }

        public virtual void Pluck() { }
    }

    public class Violin : StringInstrument
    {
        public Violin() : base()
        {
            base.Name = "Violin";
        }

        public override void Play() { }

        public override void Pluck() { }
    }

    public class Piano : StringInstrument
    {
        public Piano() : base()
        {
            base.Name = "Piano";
        }

        public override void Play() { }

        public override void Pluck()
        {
            throw new Exception("I'm not usually plucked.");
        }

        public void Strike() { }
    }
}
