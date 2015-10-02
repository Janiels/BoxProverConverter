namespace BoxProverConverter
{
	public class NegEliminationRule : Rule
	{
		public NegEliminationRule(ProofLineRef line, ProofLineRef negLine)
		{
			Line = line;
			NegLine = negLine;
		}

		public override RuleType Type => RuleType.NegElimination;
		public ProofLineRef Line { get; }
		public ProofLineRef NegLine { get; }
	}
}