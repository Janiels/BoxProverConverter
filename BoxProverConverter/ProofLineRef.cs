using System;

namespace BoxProverConverter
{
	public class ProofLineRef
	{
		public ProofLineRef(string to)
		{
			To = to;
		}

		public string To { get; }

		public bool Equals(ProofLineRef other)
		{
			return string.Equals(To, other.To, StringComparison.Ordinal);
		}


		public override string ToString()
		{
			return To;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((ProofLineRef)obj);
		}

		public override int GetHashCode()
		{
			return StringComparer.Ordinal.GetHashCode(To);
		}

		public static bool operator ==(ProofLineRef left, ProofLineRef right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(ProofLineRef left, ProofLineRef right)
		{
			return !Equals(left, right);
		}
	}
}