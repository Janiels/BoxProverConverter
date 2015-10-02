namespace BoxProverConverter
{
	public class BotEliminationRule : Rule
	{
		public BotEliminationRule(ProofLineRef bot)
		{
			Bot = bot;
		}

		public override RuleType Type => RuleType.BotElimination;
		public ProofLineRef Bot { get; }
	}
}