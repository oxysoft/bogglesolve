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
				'e', 't', 'i', 'e', 
				'n', 'r', 'q', 'b', 
				's', 'e', 'g', 'n', 
				'c', 'a', 'e', 't', 
			};

			WordGrid grid = new WordGrid(data);

			grid.FindWords(words);
		}
	}
}
