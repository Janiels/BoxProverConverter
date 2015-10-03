namespace BoxProverConverter
{
	public enum RuleType
	{
		Premise,
		Assumption,

		Copy,

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

		ModusTollens,
		ProofByContradiction,
		LawOfExcludedMiddle,
	}
}