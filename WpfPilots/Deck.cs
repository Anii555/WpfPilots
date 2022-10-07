using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPilots
{
    public class Deck
    {
        public bool IsSafeOpened { get; set; }

        public Dictionary<int, List<LevelArm>> Columns { get; }

        public Dictionary<int, List<LevelArm>> Rows { get; }

        public List<List<LevelArm>> Grid { get; }

        public List<LevelArm> AllArms { get; }

        public Deck(List<List<LevelArm>> grid)
        {
            Grid = grid;
            AllArms = grid.SelectMany(a => a).ToList();
            Columns = AllArms.GroupBy(a => a.Column).ToDictionary(a => a.Key, a => a.ToList());
            Rows = AllArms.GroupBy(a => a.Row).ToDictionary(a => a.Key, a => a.ToList());
        }

        public void ChangePosition(int column, int row)
        {
            var levelArm = Grid.ElementAt(column).ElementAt(row);
            levelArm.IsVertical = !levelArm.IsVertical;
            Columns.GetValueOrDefault(column).ForEach(c => c.IsVertical = !c.IsVertical);
            Rows.GetValueOrDefault(row).ForEach(r => r.IsVertical = !r.IsVertical);
        }
    }
}
