namespace BoxProverConverter
{
	public class ImpliesEliminationRule : Rule
	{
		public ImpliesEliminationRule(ProofLineRef implication, ProofLineRef left)
		{
			Implication = implication;
			Left = left;
		}

		public override RuleType Type => RuleType.ImpliesElimination;
		public ProofLineRef Implication { get; }
		public ProofLineRef Left { get; }
	}
}