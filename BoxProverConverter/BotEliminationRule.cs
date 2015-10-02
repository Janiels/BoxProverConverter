namespace BoxProverConverter
{
	public class BotElimination : Rule
	{
		public BotElimination(ProofLineRef bot)
		{
			Bot = bot;
		}

		public override RuleType Type => RuleType.BotElimination;
		public ProofLineRef Bot { get; }
	}
}