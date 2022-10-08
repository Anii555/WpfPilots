using System;
using System.Collections.Generic;
using System.Linq;
using WpfPilots;

namespace LogicLibrary
{
    public class Logic
    {
        public Deck Deck { get; private set; }
        private Random _random;

        public Logic()
        {
            _random = new Random();
        }

        public Deck GenerateDeck(int quantity)
        {
            var grid = GenerateGrid(quantity);
            Deck = new Deck(grid);

            return Deck;
        }

        private List<List<LevelArm>> GenerateGrid(int quantity)
        {
            var result = new List<List<LevelArm>>(quantity);

            for (var i = 0; i < quantity; i++)
            {
                var list = new List<LevelArm>(quantity);

                for (var j = 0; j < quantity; j++)
                {
                    var isVertical = _random.Next(0, 2) == 1;
                    var levelArm = new LevelArm
                    {
                        IsVertical = isVertical,
                        Column = j,
                        Row = i,
                    };

                    list.Add(levelArm);
                }

                result.Add(list);
            }

            return result;
        }

        public void ChangePosition(int column, int row)
        {
            Deck.ChangePosition(column, row);
        }
    }
}
