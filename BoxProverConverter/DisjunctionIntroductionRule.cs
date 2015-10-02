namespace BoxProverConverter
{
	public class DisjunctionIntroductionRule : Rule
	{
		public DisjunctionIntroductionRule(ProofLineRef line, int variant)
		{
			Line = line;
			Variant = variant;
		}

		public override RuleType Type => RuleType.DisjunctionIntroduction;
		public ProofLineRef Line { get; }
		public int Variant { get; }
	}
}