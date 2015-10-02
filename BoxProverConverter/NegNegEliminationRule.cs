namespace BoxProverConverter
{
	public class NegNegEliminationRule : Rule
	{
		public NegNegEliminationRule(ProofLineRef line)
		{
			Line = line;
		}

		public override RuleType Type => RuleType.NegNegElimination;
		public ProofLineRef Line { get; }
	}
}