using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bogglesolver {
	public class WordCluster {
		public Dictionary<char, WordCluster> clusters;
		public List<string> words;

		public int depth;

		public WordCluster(int depth) {
			this.depth = depth;

			clusters = new Dictionary<char, WordCluster>();
			words = new List<string>();
		}

		public void Push(string word) {
			if (depth >= word.Length) {
				words.Add(word);
			} else {
				WordCluster cluster = GetCluster(word);
				cluster.Push(word);
			}
		}

		public WordCluster GetCluster(string word) {
			char c = word[depth];

			if (!clusters.ContainsKey(c)) {
				clusters.Add(c, new WordCluster(depth + 1));
			}

			return clusters[c];
		}

		public bool IsWord(string word) {
			if (words.Contains(word)) {
				return true;
			} else {
				if (depth >= word.Length)
					return false;
				if (clusters.ContainsKey(word[depth]))
					return clusters[word[depth]].IsWord(word);
			}

			return false;
		}
	}
}
