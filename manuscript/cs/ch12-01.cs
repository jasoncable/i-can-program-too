public struct PreDecimalAmount : IEquatable<PreDecimalAmount>
{
    private static readonly byte _poundsToShillings = 20;
    private static readonly byte _shillingsToPence = 12;
    private static readonly byte _poundsToPence = 
        (byte)(_poundsToShillings * _shillingsToPence);

    public ulong Pounds => TotalPence / _poundsToPence;
    public byte Shillings => (byte)((uint)TotalPence % _poundsToShillings);
    public byte Pence => (byte)((uint)TotalPence % _shillingsToPence);
    public ulong TotalPence { get; private set; }
    public bool IsNegative { get; private set; }

    public PreDecimalAmount(int pounds, int shillings, int pence) 
        : this(pounds, shillings, pence, pounds < 0) { }

    public PreDecimalAmount(int pounds, int shillings, int pence, 
        bool isNegative) : this()
    {
        if (shillings < 0 || shillings < 0)
            throw new ArgumentOutOfRangeException
                ("shillings/pence can't be negative");

        TotalPence = ((ulong)Math.Abs(pounds) * _poundsToPence) +
            ((ulong)shillings * _shillingsToPence) +
            (ulong)pence;
        IsNegative = isNegative;
    }

    private PreDecimalAmount(ulong totalPence, bool isNegative)
    {
        TotalPence = totalPence;
        IsNegative = isNegative;
    }

    public static PreDecimalAmount Zero =>
        new PreDecimalAmount(0, 0, 0);

    public static PreDecimalAmount operator +(PreDecimalAmount a, 
        PreDecimalAmount b)
    {
        if(!a.IsNegative && !b.IsNegative)
        {
            return new PreDecimalAmount(a.TotalPence + b.TotalPence, false);
        }
        if(a.IsNegative && b.IsNegative)
        {
            return new PreDecimalAmount(a.TotalPence + b.TotalPence, true);
        }
        if(a.TotalPence == b.TotalPence) // one -, one +
        {
            return PreDecimalAmount.Zero;
        }
        if(a.TotalPence > b.TotalPence)
        {
            return new PreDecimalAmount(a.TotalPence - b.TotalPence, 
                a.IsNegative);
        }
        if(b.TotalPence > a.TotalPence)
        {
            return new PreDecimalAmount(b.TotalPence - a.TotalPence, 
                b.IsNegative);
        }

        // will NEVER get here!
        return PreDecimalAmount.Zero;
    }

    public override string ToString()
    {
        ulong pounds = this.Pounds;
        byte shillings = this.Shillings;
        byte pence = this.Pence;

        string returnValue = String.Empty;

        if (pounds > 0)
        {
            returnValue += $"\u00a3 {pounds.ToString("#,##0")} ";
        }

        if (shillings == 0)
        {
            returnValue += $"{pence}d";
        }
        else
        {
            returnValue += $"{shillings}/";
            returnValue += pence == 0 ? "-" : pence.ToString();
        }

        return returnValue;
    }

    public static bool operator ==(PreDecimalAmount a, PreDecimalAmount b)
    {
        return a.TotalPence == b.TotalPence &&
            a.IsNegative == b.IsNegative;
    }

    public static bool operator !=(PreDecimalAmount a, PreDecimalAmount b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        return obj is PreDecimalAmount && this == (PreDecimalAmount)obj;
    }

    public bool Equals(PreDecimalAmount other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.TotalPence, this.IsNegative);
    }
}