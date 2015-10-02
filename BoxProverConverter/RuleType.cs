namespace BoxProverConverter
{
	public enum RuleType
	{
		Premise,
		Assumption,

		ConjunctionIntroduction,
		ConjunctionElimination,

		DisjunctionIntroduction,
		DisjunctionElimination,

		ImpliesIntroduction,
		ImpliesElimination,

		NegIntroduction,
		NegElimination,

		BotElimination,

		NegNegIntroduction,
		NegNegElimination,

		ProofByContradiction,

		LawOfExcludedMiddle,
	}
}