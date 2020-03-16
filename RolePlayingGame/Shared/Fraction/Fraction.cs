namespace RolePlayingGame.Shared.Fraction
{
	using System;
	using System.Globalization;

	public struct Fraction : IComparable, IConvertible, IFormattable, IComparable<Fraction>, IEquatable<Fraction>
	{
		private readonly bool sign;
		private readonly ulong numerator;
		private readonly ulong denominator;

		public Fraction(byte b) : this(Convert.ToDecimal(b))
		{
		}

		public Fraction(sbyte b) : this(Convert.ToDecimal(b))
		{
		}

		public Fraction(ushort numerator, ulong denominator) : this(Convert.ToUInt64(numerator), denominator)
		{
		}

		public Fraction(short numerator, ulong denominator) : this(Convert.ToUInt64(numerator), denominator)
		{
		}

		public Fraction(uint numerator, ulong denominator) : this(Convert.ToUInt64(numerator), denominator)
		{
		}

		public Fraction(int numerator, ulong denominator) : this(Convert.ToUInt64(numerator), denominator)
		{
		}

		public Fraction(ulong numerator, ulong denominator)
		{
			sign = false;
			var greatestCommonDivisor = GreatestCommonDivisor(numerator, denominator);
			this.numerator = numerator / greatestCommonDivisor;
			this.denominator = denominator / greatestCommonDivisor;
		}

		public Fraction(long numerator, ulong denominator)
		{
			sign = numerator < 0;
			var unsignedNumerator = Convert.ToUInt64(Math.Abs(numerator));
			var greatestCommonDivisor = GreatestCommonDivisor(unsignedNumerator, denominator);
			this.numerator = unsignedNumerator / greatestCommonDivisor;
			this.denominator = denominator / greatestCommonDivisor;
		}

		public Fraction(ushort numerator) : this(numerator, 1)
		{
		}

		public Fraction(short numerator) : this(numerator, 1)
		{
		}

		public Fraction(uint numerator) : this(numerator, 1)
		{
		}

		public Fraction(int numerator) : this(numerator, 1)
		{
		}

		public Fraction(ulong numerator) : this(numerator, 1)
		{
		}

		public Fraction(long numerator) : this(numerator, 1)
		{
		}

		public Fraction(float f) : this(Convert.ToDecimal(f))
		{
		}

		public Fraction(double d) : this(Convert.ToDecimal(d))
		{
		}

		public Fraction(decimal d)
		{
			sign = d < 0;

			denominator = Convert.ToUInt64(Math.Pow(10, BitConverter.GetBytes(decimal.GetBits(d)[3])[2]));
			numerator = decimal.ToUInt64(Math.Abs(Math.Truncate(d * denominator)));

			var greatestCommonDivisor = GreatestCommonDivisor(numerator, denominator);
			numerator /= greatestCommonDivisor;
			denominator /= greatestCommonDivisor;
		}

		private static ulong GreatestCommonDivisor(ulong left, ulong right)
		{
			while (left != 0 && right != 0)
			{
				if (left > right)
					left %= right;
				else
					right %= left;
			}

			return left == 0 ? right : left;
		}

		public int CompareTo(object? obj) =>
			obj == default ? 1 : obj is Fraction other ? CompareTo(other) : throw new ArgumentException("Must be a fraction.", nameof(obj));
		public int CompareTo(Fraction other) => (numerator * other.denominator).CompareTo(other.numerator * denominator);

		public override bool Equals(object? obj) => obj is Fraction fraction && Equals(fraction);
		public bool Equals(Fraction other) => numerator == other.numerator && denominator == other.denominator;
		public override int GetHashCode() => HashCode.Combine(numerator, denominator);

		public override string ToString() => ToString("G", CultureInfo.CurrentCulture);
		public string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);
		public string ToString(IFormatProvider provider) => ToString(default, provider);
		public string ToString(string? format, IFormatProvider formatProvider)
		{
			if (string.IsNullOrEmpty(format))
				format = "G";
			if (formatProvider == default)
				formatProvider = CultureInfo.CurrentCulture;

			return (format.ToUpperInvariant()) switch
			{
				"G" => $"{(sign ? "-" : string.Empty)}{numerator.ToString(formatProvider)}/{denominator.ToString(formatProvider)}",
				"F" => $"{(sign ? "-" : string.Empty)}{numerator.ToString(formatProvider)}/{denominator.ToString(formatProvider)}",
				"D" => $"{(sign ? "-" : string.Empty)}{ToDecimal(formatProvider)}",
				_ => throw new FormatException($"The {format} format string is not supported."),
			};
		}

		public TypeCode GetTypeCode() => TypeCode.Decimal;
		public bool ToBoolean(IFormatProvider provider) => Convert.ToBoolean(this);
		public byte ToByte(IFormatProvider provider) => Convert.ToByte(this);
		public char ToChar(IFormatProvider provider) => throw new InvalidCastException($"Invalid cast from {nameof(Fraction)} to {nameof(Char)}");
		public DateTime ToDateTime(IFormatProvider provider) => throw new InvalidCastException($"Invalid cast from {nameof(Fraction)} to {nameof(DateTime)}");
		public decimal ToDecimal(IFormatProvider provider) => (decimal)numerator / denominator;
		public double ToDouble(IFormatProvider provider) => Convert.ToDouble(this);
		public short ToInt16(IFormatProvider provider) => Convert.ToInt16(this);
		public int ToInt32(IFormatProvider provider) => Convert.ToInt32(this);
		public long ToInt64(IFormatProvider provider) => Convert.ToInt64(this);
		public sbyte ToSByte(IFormatProvider provider) => Convert.ToSByte(this);
		public float ToSingle(IFormatProvider provider) => Convert.ToSingle(this);
		public object ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(this, conversionType);
		public ushort ToUInt16(IFormatProvider provider) => Convert.ToUInt16(this);
		public uint ToUInt32(IFormatProvider provider) => Convert.ToUInt32(this);
		public ulong ToUInt64(IFormatProvider provider) => Convert.ToUInt64(this);

		public static implicit operator Fraction(byte value) => new Fraction(value);
		public static implicit operator Fraction(sbyte value) => new Fraction(value);
		public static implicit operator Fraction(ushort value) => new Fraction(value);
		public static implicit operator Fraction(short value) => new Fraction(value);
		public static implicit operator Fraction(uint value) => new Fraction(value);
		public static implicit operator Fraction(int value) => new Fraction(value);
		public static implicit operator Fraction(ulong value) => new Fraction(value);
		public static implicit operator Fraction(long value) => new Fraction(value);
		public static implicit operator Fraction(float value) => new Fraction(value);
		public static implicit operator Fraction(double value) => new Fraction(value);
		public static implicit operator Fraction(decimal value) => new Fraction(value);
		public static explicit operator byte(Fraction value) => Convert.ToByte(value);
		public static explicit operator sbyte(Fraction value) => Convert.ToSByte(value);
		public static explicit operator ushort(Fraction value) => Convert.ToUInt16(value);
		public static explicit operator short(Fraction value) => Convert.ToInt16(value);
		public static explicit operator uint(Fraction value) => Convert.ToUInt32(value);
		public static explicit operator int(Fraction value) => Convert.ToInt32(value);
		public static explicit operator ulong(Fraction value) => Convert.ToUInt64(value);
		public static explicit operator long(Fraction value) => Convert.ToInt64(value);
		public static explicit operator float(Fraction value) => Convert.ToSingle(value);
		public static explicit operator double(Fraction value) => Convert.ToDouble(value);
		public static explicit operator decimal(Fraction value) => Convert.ToDecimal(value);

		public static bool operator <(Fraction left, Fraction right) => left.CompareTo(right) < 0;
		public static bool operator >(Fraction left, Fraction right) => left.CompareTo(right) > 0;
		public static bool operator <=(Fraction left, Fraction right) => left.CompareTo(right) <= 0;
		public static bool operator >=(Fraction left, Fraction right) => left.CompareTo(right) >= 0;
		public static bool operator ==(Fraction left, Fraction right) => left.Equals(right);
		public static bool operator !=(Fraction left, Fraction right) => !(left == right);

		public static Fraction operator +(Fraction left, Fraction right) =>
			new Fraction(left.numerator * right.denominator + right.numerator * left.denominator, left.denominator * right.denominator);

		public static Fraction operator -(Fraction left, Fraction right) =>
			new Fraction(left.numerator * right.denominator - right.numerator * left.denominator, left.denominator * right.denominator);

		public static Fraction operator *(Fraction left, Fraction right) =>
			new Fraction(left.numerator * right.numerator, left.denominator * right.denominator);

		public static Fraction operator /(Fraction left, Fraction right) =>
			new Fraction(left.numerator * right.denominator, right.numerator * left.denominator);
	}
}
