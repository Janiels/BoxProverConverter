namespace BoxProverConverter
{
	public class ImpliesIntroduction : Rule
	{
		public ImpliesIntroduction(ProofBox box)
		{
			Box = box;
		}

		public override RuleType Type => RuleType.ImpliesIntroduction;
		public ProofBox Box { get; }
	}
}