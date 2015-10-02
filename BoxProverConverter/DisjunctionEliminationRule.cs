namespace BoxProverConverter
{
	public class DisjunctionEliminationRule : Rule
	{
		public DisjunctionEliminationRule(ProofLineRef disjunction, ProofBox case1, ProofBox case2)
		{
			Disjunction = disjunction;
			Case1 = case1;
			Case2 = case2;
		}

		public override RuleType Type => RuleType.DisjunctionElimination;
		public ProofLineRef Disjunction { get; }
		public ProofBox Case1 { get; }
		public ProofBox Case2 { get; }
	}
}