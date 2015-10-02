namespace BoxProverConverter
{
	public class NegNegIntroduction : Rule
	{
		public NegNegIntroduction(ProofLineRef line)
		{
			Line = line;
		}

		public override RuleType Type => RuleType.NegNegIntroduction;
		public ProofLineRef Line { get; }
	}
}