namespace BoxProverConverter
{
	public class NegNegIntroductionRule : Rule
	{
		public NegNegIntroductionRule(ProofLineRef line)
		{
			Line = line;
		}

		public override RuleType Type => RuleType.NegNegIntroduction;
		public ProofLineRef Line { get; }
	}
}