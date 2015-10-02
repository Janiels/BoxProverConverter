namespace BoxProverConverter
{
	public class ProofBox
	{
		public ProofBox(ProofLineRef start, ProofLineRef end)
		{
			Start = start;
			End = end;
		}

		public ProofLineRef Start { get; }
		public ProofLineRef End { get; }

		protected bool Equals(ProofBox other)
		{
			return Equals(End, other.End) && Equals(Start, other.Start);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((ProofBox)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((End != null ? End.GetHashCode() : 0)*397) ^ (Start != null ? Start.GetHashCode() : 0);
			}
		}

		public static bool operator ==(ProofBox left, ProofBox right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(ProofBox left, ProofBox right)
		{
			return !Equals(left, right);
		}

		public static ProofBox Parse(string text)
		{
			string[] parts = text.Split('-');
			return new ProofBox(new ProofLineRef(parts[0]), new ProofLineRef(parts[1]));
		}

		public override string ToString()
		{
			return $"{Start}-{End}";
		}
	}
}