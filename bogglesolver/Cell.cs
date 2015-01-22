using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bogglesolver {
	public class Cell {
		private WordGrid grid;
		public char value;
		public readonly int x, y;

		public List<Cell> neighbors;

		public Cell(WordGrid grid, char value, int x, int y) {
			this.grid = grid;
			this.value = value;
			this.x = x;
			this.y = y;
		}

		public List<string> Expand(WordTree dictionary) {
			List<string> list = new List<string>();
			foreach (Cell n in neighbors) {
				List<string> ret = n.ExpandProcess(dictionary, "" + value, 0, list, new List<CellVisit> { new CellVisit(this, 0) });
			}
			return list;
		}

		private List<string> ExpandProcess(WordTree dictionary, string sum, int depth, List<string> list, List<CellVisit> visited) {
			visited.Add(new CellVisit(this, depth));

			if (sum.Length > 2 && dictionary.IsWord(sum) && !list.Contains(sum)) {
				list.Add(sum);
				Console.WriteLine(":: " + sum);
			}

			foreach (Cell n in neighbors) {
				if (!visited.Contains(new CellVisit(n, depth))) {
					n.ExpandProcess(dictionary, sum + value, depth + 1, list, visited);
				}
			}

			visited.RemoveAll(visit => visit.depth >= depth);

			return list;
		}
	}

	struct CellVisit {
		public int x, y;
		public int depth;

		public CellVisit(Cell cell, int depth) {
			x = cell.x;
			y = cell.y;
			this.depth = depth;
		}

		public override bool Equals(object obj) {
			if (obj is CellVisit) {
				if (x == ((CellVisit) obj).x && y == ((CellVisit) obj).y) {
					return true;
				}
			}

			return base.Equals(obj);
		}
	}
}
