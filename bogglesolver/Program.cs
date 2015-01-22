using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bogglesolver {
	static class Program {

		static void Main() {
			// a word tree
			WordTree words = new WordTree("words.txt");

			// the letter grid
			char[] data = {
				'd', 'e', 'c', 'd', 
				'r', 'n', 'n', 'e', 
				'u', 'n', 's', 'd', 
				'e', 'u', 'a', 'd', 
			};

			WordGrid grid = new WordGrid(data);

			grid.FindWords(words);
		}
	}
}
