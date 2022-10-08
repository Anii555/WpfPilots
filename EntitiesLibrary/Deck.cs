using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPilots
{
    /// <summary>
    /// Игровое поле (сейф)
    /// </summary>
    public class Deck
    {
        private bool _isSafeOpened;
        public int counter;

        /// <summary>
        /// Сейф открыт, игра окончена
        /// </summary>
        public bool IsSafeOpened => _isSafeOpened || CheckSafeOpened();

        private bool CheckSafeOpened()
        {
            var result = AllArms
                .GroupBy(a => a.IsVertical)
                .Any(g => g.Count() == AllArms.Count);

            _isSafeOpened = result;

            return result;
        }

        /// <summary>
        /// Столбцы, исп-ся для переворота рычагов
        /// </summary>
        public Dictionary<int, List<LevelArm>> Columns { get; }

        /// <summary>
        /// Строки, исп-ся для переворота рычагов
        /// </summary>
        public Dictionary<int, List<LevelArm>> Rows { get; }

        /// <summary>
        /// Двумерный массив для расположения рукояток на сейфе
        /// </summary>
        public List<List<LevelArm>> Grid { get; }

        /// <summary>
        /// Все рычаги, исп-ся для генерации кнопок(рычагов) на UI
        /// </summary>
        public List<LevelArm> AllArms { get; }

        public Deck(List<List<LevelArm>> grid)
        {
            Grid = grid;
            AllArms = grid.SelectMany(a => a).ToList();
            Columns = AllArms.GroupBy(a => a.Column).ToDictionary(a => a.Key, a => a.ToList());
            Rows = AllArms.GroupBy(a => a.Row).ToDictionary(a => a.Key, a => a.ToList());
        }

        public bool ChangePosition(int column, int row)
        {
            var levelArm = Grid.ElementAt(column).ElementAt(row);
            levelArm.IsVertical = !levelArm.IsVertical;
            Columns.GetValueOrDefault(column).ForEach(c => c.IsVertical = !c.IsVertical);
            Rows.GetValueOrDefault(row).ForEach(r => r.IsVertical = !r.IsVertical);

            return true;
        }
    }
}
