using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Draughts
{
    public class Game
    {
        public Color CurrentTurn { get; set; }
        public Checker[,] board = new Checker[8, 8];
        public bool GameOn { get; set; }

        public Game()
        {
            GameOn = true;
            for (int i = 0; i < 8; i += 2)
            {
                board[i, 0] = new Checker(Color.Black, i, 0);
                board[i + 1, 1] = new Checker(Color.Black, i + 1, 1);
                board[i, 2] = new Checker(Color.Black, i, 2);

                board[i + 1, 5] = new Checker(Color.Red, i + 1, 5);
                board[i, 6] = new Checker(Color.Red, i, 6);
                board[i + 1, 7] = new Checker(Color.Red, i + 1, 7);
            }

            CurrentTurn = Color.Red;
        }

        public Game(bool gameOn, Color color)
        {
            GameOn = gameOn;
            CurrentTurn = color;
        }

        public string Serialize()
        {
            string state = GameOn + "\n";
            state += CurrentTurn + "\n";
            for (int x = 0; x < 8; x += 1)
            {
                for (int y = 0; y < 8; y += 1)
                {
                    Checker checker = board[x, y];
                    if (checker != null)
                        state += $"{checker.Color}|{checker.King}|{checker.Coords.X}|{checker.Coords.Y}\n";
                }
            }

            return state;
        }

        public static Game Deserialize(string state)
        {
            string[] lines = state.Split("\n");
            Game game = new Game(bool.Parse(lines[0]), Enum.Parse<Color>(lines[1]));
            game.board = new Checker[8, 8];
            for (int i = 2; i < lines.Length - 1; i += 1)
            {
                string[] checkerParts = lines[i].Split("|");
                int x = int.Parse(checkerParts[2]);
                int y = int.Parse(checkerParts[3]);
                Color checkerColor = Enum.Parse<Color>(checkerParts[0]);
                game.board[x, y] = new Checker(checkerColor, x, y, bool.Parse(checkerParts[1]));
            }
            return game;
        }
    }
}
