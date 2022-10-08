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

        public bool IsGameOver => Deck.IsSafeOpened;

        public Logic()
        {
            _random = new Random();
        }

        public Deck GenerateDeck(int quantity)
        {
            var grid = GenerateGrid(quantity);
            Deck = new Deck(grid);

            if (!DeckHasSolution())
            {
                return GenerateDeck(quantity);
            }

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

        private bool DeckHasSolution() 
        {
            // Ќе успела найти логику, как игра может быть нерешаемой
            return !Deck.IsSafeOpened;
        }

        /// <summary>
        /// »зменение позиции рычагов на поле по координате
        /// </summary>
        /// <returns>ѕоказатель, что позиции рычагов были изменены.
        /// false обозначает, что сейф открыт.</returns>
        public bool ChangePosition(int column, int row)
        {
            if (Deck.IsSafeOpened)
            {
                return false;
            }

            return Deck.ChangePosition(column, row);
        }
    }
}
