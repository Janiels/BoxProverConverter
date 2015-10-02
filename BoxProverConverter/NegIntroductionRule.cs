namespace BoxProverConverter
{
	public class NegIntroduction : Rule
	{
		public NegIntroduction(ProofBox box)
		{
			Box = box;
		}

		public override RuleType Type => RuleType.NegIntroduction;
		public ProofBox Box { get; }
	}
}