namespace BoxProverConverter
{
	public class ProofByContradictionRule : Rule
	{
		public ProofByContradictionRule(ProofBox box)
		{
			Box = box;
		}

		public override RuleType Type => RuleType.ProofByContradiction;
		public ProofBox Box { get; }
	}
}