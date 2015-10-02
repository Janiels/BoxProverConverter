namespace BoxProverConverter
{
	public class ProofLine
	{
		public ProofLine(ProofLineRef reference, string formula, Rule rule)
		{
			Reference = reference;
			Formula = formula;
			Rule = rule;
		}

		public ProofLineRef Reference { get; }
		public string Formula { get; }
		public Rule Rule { get; }

		public override string ToString()
		{
			return $"{Reference}: {Formula} (by {Rule})";
		}
	}
}