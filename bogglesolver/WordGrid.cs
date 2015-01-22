using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bogglesolver {
	public class WordGrid {
		public int w, h;
		public Cell[] cells;

		public WordGrid(char[] data) {
			w = 4;
			h = 4;

			cells = new Cell[w * h];

			for (int i = 0; i < w; i++) {
				for (int j = 0; j < h; j++) {
					cells[j * w + i] = new Cell(this, data[j * w + i], i, j);
				}
			}
		}

		public Cell Get(int i, int j) {
			return cells[j * w + i];
		}

		public List<Cell> GetNeighbors(int i, int j) {
			List<Cell> neighbors = new List<Cell>();

			if (i > 0)
				neighbors.Add(Get(i - 1, j));
			if (i < w - 1)
				neighbors.Add(Get(i + 1, j));
			if (j > 0)
				neighbors.Add(Get(i, j - 1));
			if (j < h - 1)
				neighbors.Add(Get(i, j + 1));
			if (i > 0 && j > 0)
				neighbors.Add(Get(i - 1, j - 1));
			if (i < w - 1 && j > 0)
				neighbors.Add(Get(i + 1, j - 1));
			if (i > 0 && j < h - 1)
				neighbors.Add(Get(i - 1, j + 1));
			if (i < w - 1 && j < h - 1)
				neighbors.Add(Get(i + 1, j + 1));

			return neighbors;
		}

		public List<string> FindWords(WordTree dictionary) {
			List<string> words = new List<string>();

			for (int i = 0; i < w; i++) {
				for (int j = 0; j < h; j++) {
					Cell c = Get(i, j);

					List<string> found = c.Expand(dictionary);
				}
			}

			return words;
		}
	}
}
