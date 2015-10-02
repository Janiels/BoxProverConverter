namespace BoxProverConverter
{
	public class ImpliesIntroductionRule : Rule
	{
		public ImpliesIntroductionRule(ProofBox box)
		{
			Box = box;
		}

		public override RuleType Type => RuleType.ImpliesIntroduction;
		public ProofBox Box { get; }
	}
}