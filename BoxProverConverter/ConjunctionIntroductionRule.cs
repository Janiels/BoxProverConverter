namespace BoxProverConverter
{
	public class ConjunctionIntroductionRule : Rule
	{
		public ConjunctionIntroductionRule(ProofLineRef left, ProofLineRef right)
		{
			Left = left;
			Right = right;
		}

		public override RuleType Type => RuleType.ConjunctionIntroduction;
		public ProofLineRef Left { get; }
		public ProofLineRef Right { get; }
	}
}