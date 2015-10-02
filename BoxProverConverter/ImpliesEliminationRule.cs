namespace BoxProverConverter
{
	public class ImpliesElimination : Rule
	{
		public ImpliesElimination(ProofLineRef implication, ProofLineRef left)
		{
			Implication = implication;
			Left = left;
		}

		public override RuleType Type => RuleType.ImpliesElimination;
		public ProofLineRef Implication { get; }
		public ProofLineRef Left { get; }
	}
}