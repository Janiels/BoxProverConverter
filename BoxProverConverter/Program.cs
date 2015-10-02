using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoxProverConverter
{
	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			string text = Clipboard.GetText();

			List<ProofLine> lines = new List<ProofLine>();
			foreach (string line in text.Substring(2, text.Length - 3).Split('@'))
			{
				string[] parts = line.Split('&');

				if (parts.Any(string.IsNullOrWhiteSpace))
					continue;

				Rule rule = Rule.Parse(parts[2]);
				if (rule == null)
					throw new NotImplementedException();

				lines.Add(new ProofLine(new ProofLineRef(parts[0]), parts[1], rule));
			}

			List<string> variables = GetVariables(lines).ToList();

			StringBuilder boxProver = new StringBuilder();
			boxProver.AppendLine("%abbrev");
			boxProver.AppendFormat("autogen : {0}", string.Join("", variables.Select(v => $"{{{v}}}"))).AppendLine();

			string premises = string.Join(" , ",
			                              lines.Where(l => l.Rule.Type == RuleType.Premise)
			                                   .Select(l => FormulaToBoxProver(l.Formula)));
			string conclusion = FormulaToBoxProver(lines.Last().Formula);
			boxProver.AppendFormat("\t\tproof (({0} , |- {1})) =", premises, conclusion).AppendLine();
			boxProver.AppendLine(string.Join("", variables.Select(v => $"[{v}]")));

			List<ProofBox> boxes = lines.SelectMany(l => Boxes(l.Rule)).Distinct().ToList();

			for (int i = 0; i < lines.Count; i++)
			{
				ProofLine line = lines[i];
				if (BoxStartsHere(line.Reference, boxes))
				{
					boxProver.Append("( ");
				}

				boxProver.Append(FormulaToBoxProver(line.Formula));
				boxProver.Append("\t\t");
				boxProver.Append(RuleToBoxProver(line.Rule));

				if (BoxEndsHere(line.Reference, boxes))
				{
					boxProver.Append(" )");
				}

				if (i != lines.Count - 1)
				{
					if (line.Rule.Type != RuleType.Assumption && line.Rule.Type != RuleType.Premise)
						boxProver.Append(" ");

					boxProver.AppendFormat("; [@l{0}]", line.Reference).AppendLine();
				}
				else
					boxProver.Append(".");
			}

			Clipboard.SetText(boxProver.ToString());
		}

		private static bool BoxStartsHere(ProofLineRef reference, IEnumerable<ProofBox> boxes)
		{
			return boxes.Any(pb => pb.Start == reference);
		}

		private static bool BoxEndsHere(ProofLineRef reference, IEnumerable<ProofBox> boxes)
		{
			return boxes.Any(pb => pb.End == reference);
		}

		private static IEnumerable<ProofBox> Boxes(Rule rule)
		{
			switch (rule.Type)
			{
				case RuleType.DisjunctionElimination:
					yield return ((DisjunctionEliminationRule)rule).Case1;
					yield return ((DisjunctionEliminationRule)rule).Case2;
					break;
				case RuleType.ImpliesIntroduction:
					yield return ((ImpliesIntroductionRule)rule).Box;
					break;
				case RuleType.NegIntroduction:
					yield return ((NegIntroductionRule)rule).Box;
					break;
				case RuleType.ProofByContradiction:
					yield return ((ProofByContradictionRule)rule).Box;
					break;
			}
		}

		private static IEnumerable<string> GetVariables(List<ProofLine> lines)
		{
			HashSet<string> variables = new HashSet<string>();
			foreach (ProofLine line in lines)
			{
				foreach (string variable in line.Formula
				                                .Replace("∧", "|")
				                                .Replace("∨", "|")
				                                .Replace("¬", "|")
				                                .Replace("→", "|")
				                                .Replace("(", "|")
				                                .Replace(")", "|")
				                                .Replace("⊤", "|")
				                                .Replace("⊥", "|")
				                                .Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries))
				{
					string trimmed = variable.Trim();
					variables.Add(trimmed);
				}
			}

			return variables;
		}

		private static string FormulaToBoxProver(string formula)
		{
			return formula.Replace("∧", " /\\ ")
			              .Replace("∨", " \\/ ")
			              .Replace("¬", " ~ ")
			              .Replace("→", " => ")
			              .Replace("⊤", " top ")
			              .Replace("⊥", " bot ");
		}

		private static string RuleToBoxProver(Rule rule)
		{
			switch (rule.Type)
			{
				case RuleType.Premise:
					return "premise";
				case RuleType.Assumption:
					return "assumption";
				case RuleType.ConjunctionIntroduction:
					var conjI = (ConjunctionIntroductionRule)rule;
					return $"by con_i @l{conjI.Left.To} @l{conjI.Right.To}";
				case RuleType.ConjunctionElimination:
					var conjE = (ConjunctionEliminationRule)rule;
					return $"by con_e{conjE.Variant} @l{conjE.Line.To}";
				case RuleType.DisjunctionIntroduction:
					var disjI = (DisjunctionIntroductionRule)rule;
					return $"by dis_i{disjI.Variant} @l{disjI.Line.To}";
				case RuleType.DisjunctionElimination:
					var disjE = (DisjunctionEliminationRule)rule;
					return $"by dis_e @l{disjE.Disjunction.To} @l{disjE.Case1.End.To} @l{disjE.Case2.End.To}";
				case RuleType.NegIntroduction:
					var negI = (NegIntroductionRule)rule;
					return $"by neg_i @l{negI.Box.End.To}";
				case RuleType.NegElimination:
					var negE = (NegEliminationRule)rule;
					return $"by neg_e @l{negE.Line.To} @l{negE.NegLine.To}";
				case RuleType.ImpliesIntroduction:
					var impI = (ImpliesIntroductionRule)rule;
					return $"by imp_i @l{impI.Box.End.To}";
				case RuleType.ImpliesElimination:
					var impE = (ImpliesEliminationRule)rule;
					return $"by imp_e @l{impE.Left.To} @l{impE.Implication.To}";
				case RuleType.NegNegIntroduction:
					var nnI = (NegNegIntroductionRule)rule;
					return $"by nni @l{nnI.Line.To}";
				case RuleType.NegNegElimination:
					var nnE = (NegNegEliminationRule)rule;
					return $"by nne @l{nnE.Line.To}";
				case RuleType.ProofByContradiction:
					var pbc = (ProofByContradictionRule)rule;
					return $"by pbc @l{pbc.Box.End.To}";
				case RuleType.LawOfExcludedMiddle:
					return "by lem";
				default:
					throw new NotImplementedException();
			}
		}
	}
}