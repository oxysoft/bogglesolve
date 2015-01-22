using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bogglesolver {
	public class WordTree {
		public Dictionary<char, WordCluster> clusters;

		public WordTree(string filepath) {
			clusters = new Dictionary<char, WordCluster> {
				{'a', new WordCluster(1)},
				{'b', new WordCluster(1)},
				{'c', new WordCluster(1)},
				{'d', new WordCluster(1)},
				{'e', new WordCluster(1)},
				{'f', new WordCluster(1)},
				{'g', new WordCluster(1)},
				{'h', new WordCluster(1)},
				{'i', new WordCluster(1)},
				{'j', new WordCluster(1)},
				{'k', new WordCluster(1)},
				{'l', new WordCluster(1)},
				{'m', new WordCluster(1)},
				{'n', new WordCluster(1)},
				{'o', new WordCluster(1)},
				{'p', new WordCluster(1)},
				{'q', new WordCluster(1)},
				{'r', new WordCluster(1)},
				{'s', new WordCluster(1)},
				{'t', new WordCluster(1)},
				{'u', new WordCluster(1)},
				{'v', new WordCluster(1)},
				{'w', new WordCluster(1)},
				{'x', new WordCluster(1)},
				{'y', new WordCluster(1)},
				{'z', new WordCluster(1)}
			};

			string[] lines = File.ReadAllLines(Application.StartupPath + "/" + filepath);

			foreach (string w in lines) {
				string word = RemoveDiacritics(w).ToLower();
				char c = word[0];
				WordCluster cluster = clusters[c];
				cluster.Push(word);
			}
		}

		public bool IsWord(string word) {
			word = RemoveDiacritics(word).ToLower();
			return clusters[word[0]].IsWord(word);
		}

		static string RemoveDiacritics(string text) {
			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder();

			foreach (var c in normalizedString) {
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark) {
					stringBuilder.Append(c);
				}
			}

			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
		}
	}
}
