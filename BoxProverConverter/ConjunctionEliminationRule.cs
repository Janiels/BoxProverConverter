namespace BoxProverConverter
{
	public class ConjunctionEliminationRule : Rule
	{
		public ConjunctionEliminationRule(ProofLineRef line, int variant)
		{
			Line = line;
			Variant = variant;
		}

		public override RuleType Type => RuleType.ConjunctionElimination;
		public ProofLineRef Line { get; }
		public int Variant { get; }
	}
}