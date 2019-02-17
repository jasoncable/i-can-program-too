using System;
namespace SampleConsoleApp.Chapter10
{
    public class PreDecimalAmount
    {
        public OldPoundAmount Pounds { get; set; }
        public OldShillingAmount Shillings { get; set; }
        public OldPennyAmount Pence { get; set; }

        public PreDecimalAmount(int pounds, int shillings, int pence)
        {
            Pounds = new OldPoundAmount(pounds);
            Shillings = new OldShillingAmount(shillings);
            Pence = new OldPennyAmount(pence);
        }

        public PreDecimalAmount(int pence)
        {
            int pounds = 0, shillings = 0;

            if (pence > 240) {
                pounds = pence / 240;
                pence = pence % 240;
            }

            if(pence > 12)
            {
                shillings = pence / 12;
                pence = shillings % 12;
            }

            Pounds = new OldPoundAmount(pounds);
            Shillings = new OldShillingAmount(shillings);
            Pence = new OldPennyAmount(pence);
        }

        public static PreDecimalAmount operator +(PreDecimalAmount a, PreDecimalAmount b)
        {
            return new PreDecimalAmount(a.ToPence() + b.ToPence());
        }

        public static bool operator ==(PreDecimalAmount a, PreDecimalAmount b)
        {
            return a.ToPence() == b.ToPence();
        }

        public static bool operator !=(PreDecimalAmount a, PreDecimalAmount b)
        {
            return a.ToPence() != b.ToPence();
        }

        public int ToPence()
        {
            return Pounds.ToPence() +
                Shillings.ToPence() +
                Pence.Count;
        }
    }
}
