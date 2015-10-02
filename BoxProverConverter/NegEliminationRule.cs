namespace BoxProverConverter
{
	public class NegElimination : Rule
	{
		public NegElimination(ProofLineRef line, ProofLineRef negLine)
		{
			Line = line;
			NegLine = negLine;
		}

		public override RuleType Type => RuleType.NegElimination;
		public ProofLineRef Line { get; }
		public ProofLineRef NegLine { get; }
	}
}