using System;

public struct CurrencyAmount : IEquatable<CurrencyAmount>
{
    private readonly decimal amount;
    private readonly string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        // Basic validation to ensure currency symbol is not null or empty
        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency symbol cannot be null or empty.", nameof(currency));
        }
        this.amount = amount;
        this.currency = currency;
    }

    // --- Equality ---

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        // Ensure currencies are the same before comparing amounts
        if (a.currency != b.currency)
        {
            // Or return false, depending on desired behavior for different currencies.
            // Throwing an exception is safer to prevent logic errors.
            throw new ArgumentException("Cannot compare amounts with different currencies.");
        }
        return a.amount == b.amount;
    }

    // Correctly implemented using the == operator
    public static bool operator !=(CurrencyAmount a, CurrencyAmount b) => !(a == b);

    // --- Comparison ---

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException("Cannot compare amounts with different currencies.");
        }
        return a.amount > b.amount;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException("Cannot compare amounts with different currencies.");
        }
        return a.amount < b.amount;
    }

    public static bool operator >=(CurrencyAmount a, CurrencyAmount b)
    {
        // Reuse other operators to reduce code duplication
        return a > b || a == b;
    }

    public static bool operator <=(CurrencyAmount a, CurrencyAmount b)
    {
        // Reuse other operators
        return a < b || a == b;
    }

    // --- Arithmetic ---

    // Adding two amounts results in a new amount of the same currency
    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException("Cannot add amounts with different currencies.");
        }
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    // Subtracting two amounts
    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException("Cannot subtract amounts with different currencies.");
        }
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    // Multiplying an amount by a scalar (decimal)
    public static CurrencyAmount operator *(CurrencyAmount a, decimal scalar)
    {
        return new CurrencyAmount(a.amount * scalar, a.currency);
    }
    
    // Commutative version of multiplication
    public static CurrencyAmount operator *(decimal scalar, CurrencyAmount a)
    {
        return new CurrencyAmount(a.amount * scalar, a.currency);
    }

    // Dividing an amount by a scalar (decimal)
    public static CurrencyAmount operator /(CurrencyAmount a, decimal scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Cannot divide a currency amount by zero.");
        }
        return new CurrencyAmount(a.amount / scalar, a.currency);
    }
    
    // Dividing an amount by another amount to get a ratio (decimal)
    public static decimal operator /(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
             throw new InvalidOperationException("Cannot divide amounts with different currencies.");
        }
        if (b.amount == 0)
        {
            throw new DivideByZeroException();
        }
        return a.amount / b.amount;
    }


    // --- Type Conversion ---
        public static implicit operator decimal(CurrencyAmount a)
    {
        return a.amount;
    }

    public static explicit operator double(CurrencyAmount a)
    {
        return (double)a.amount;
    }

    // --- Best Practices: IEquatable, Equals, and GetHashCode ---

    public bool Equals(CurrencyAmount other)
    {
        // Type-safe equality check
        return currency == other.currency && amount == other.amount;
    }

    public override bool Equals(object obj)
    {
        // Override for general-purpose equality
        return obj is CurrencyAmount other && Equals(other);
    }

    public override int GetHashCode()
    {
        // Important for performance in collections like Dictionary or HashSet
        return HashCode.Combine(amount, currency);
    }

    public override string ToString()
    {
        // For easy display and debugging
        return $"{amount:0.00} {currency}";
    }
}