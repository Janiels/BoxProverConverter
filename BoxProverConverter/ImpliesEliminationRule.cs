namespace BoxProverConverter
{
	public class ImpliesEliminationRule : Rule
	{
		public ImpliesEliminationRule(ProofLineRef implication, ProofLineRef assumption)
		{
			Implication = implication;
			Assumption = assumption;
		}

		public override RuleType Type => RuleType.ImpliesElimination;
		public ProofLineRef Implication { get; }
		public ProofLineRef Assumption { get; }
	}
}