namespace BoxProverConverter
{
	public class NegNegElimination : Rule
	{
		public NegNegElimination(ProofLineRef line)
		{
			Line = line;
		}

		public override RuleType Type => RuleType.NegNegElimination;
		public ProofLineRef Line { get; }
	}
}