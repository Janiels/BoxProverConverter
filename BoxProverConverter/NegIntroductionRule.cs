namespace BoxProverConverter
{
	public class NegIntroductionRule : Rule
	{
		public NegIntroductionRule(ProofBox box)
		{
			Box = box;
		}

		public override RuleType Type => RuleType.NegIntroduction;
		public ProofBox Box { get; }
	}
}