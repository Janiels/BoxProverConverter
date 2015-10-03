namespace BoxProverConverter
{
	public class CopyRule : Rule
	{
		public CopyRule(ProofLineRef line)
		{
			Line = line;
		}

		public override RuleType Type => RuleType.Copy;
		public ProofLineRef Line { get; }
	}
}