using System.Linq;

namespace BoxProverConverter
{
	public abstract class Rule
	{
		public abstract RuleType Type { get; }

		public static Rule Parse(string text)
		{
			text = text.Trim();
			if (text.StartsWith("premise"))
				return new PremiseRule();

			if (text.StartsWith("assumption"))
				return new AssumptionRule();

			if (text.StartsWith("∧i"))
			{
				string[] parts = text.Substring(2).Split(',').Select(s => s.Trim()).ToArray();
				return new ConjunctionIntroductionRule(new ProofLineRef(parts[0]), new ProofLineRef(parts[1])); 
			}

			if (text.StartsWith("∧e"))
			{
				int index = text[2] == '_' ? 3 : 2;
				int variant = text[index] == '1' ? 1 : 2;

				ProofLineRef to = new ProofLineRef(text.Substring(index + 1).Trim());
				return new ConjunctionEliminationRule(to, variant);
			}

			if (text.StartsWith("∨i"))
			{
				int index = text[2] == '_' ? 3 : 2;
				int variant = text[index] == '1' ? 1 : 2;

				ProofLineRef to = new ProofLineRef(text.Substring(index + 1).Trim());
				return new DisjunctionIntroductionRule(to, variant);
			}

			if (text.StartsWith("∨e"))
			{
				string[] parts = text.Substring(2).Split(',').Select(s => s.Trim()).ToArray();
				return new DisjunctionEliminationRule(new ProofLineRef(parts[0]), ProofBox.Parse(parts[1]), ProofBox.Parse(parts[2]));
			}

			if (text.StartsWith("¬¬i"))
			{
				ProofLineRef to = new ProofLineRef(text.Substring(3).Trim());
				return new NegNegIntroductionRule(to);
			}

			if (text.StartsWith("¬¬e"))
			{
				ProofLineRef to = new ProofLineRef(text.Substring(3).Trim());
				return new NegNegEliminationRule(to);
			}

			if (text.StartsWith("→i"))
			{
				ProofBox box = ProofBox.Parse(text.Substring(2).Trim());
				return new ImpliesIntroductionRule(box);
			}

			if (text.StartsWith("→e"))
			{
				string[] parts = text.Substring(2).Split(',').Select(s => s.Trim()).ToArray();
				return new ImpliesEliminationRule(new ProofLineRef(parts[0]), new ProofLineRef(parts[1]));
			}

			if (text.StartsWith("¬i"))
			{
				ProofBox box = ProofBox.Parse(text.Substring(2).Trim());
				return new NegIntroductionRule(box);
			}

			if (text.StartsWith("¬e"))
			{
				string[] parts = text.Substring(2).Split(',').Select(s => s.Trim()).ToArray();

				ProofLineRef line = new ProofLineRef(parts[0]);
				ProofLineRef negLine = new ProofLineRef(parts[1]);
				return new NegEliminationRule(line, negLine);
			}

			if (text.StartsWith("PBC"))
			{
				ProofBox box = ProofBox.Parse(text.Substring(3).Trim());
				return new ProofByContradictionRule(box);
			}

			if (text.StartsWith("LEM"))
			{
				return new LawOfExcludedMiddleRule();
			}

			return null;
		}

		public override string ToString()
		{
			return Type.ToString();
		}
	}
}