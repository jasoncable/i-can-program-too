﻿using System;
namespace SampleConsoleApp.Chapter10
{
    public class OldPoundAmount
    {
        public static readonly int NumberOfPence = 240;
        public static readonly int NumberOfShillings = 20;

        public int Count { get; set; }

        public OldPoundAmount(int pounds) => Count = pounds;

        public static implicit operator OldShillingAmount(OldPoundAmount pounds)
        {
            return new OldShillingAmount(pounds.Count * 20);
        }

        public static implicit operator OldPoundAmount(int pounds)
        {
            return new OldPoundAmount(pounds);
        }

        public int ToPence()
        {
            return Count * NumberOfPence;
        }
    }
}
