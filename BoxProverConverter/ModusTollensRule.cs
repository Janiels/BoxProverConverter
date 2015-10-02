namespace BoxProverConverter
{
	public class ModusTollensRule : Rule
	{
		public ModusTollensRule(ProofLineRef implication, ProofLineRef negConclusion)
		{
			Implication = implication;
			NegConclusion = negConclusion;
		}

		public override RuleType Type => RuleType.ModusTollens;
		public ProofLineRef Implication { get; }
		public ProofLineRef NegConclusion { get; }
	}
}