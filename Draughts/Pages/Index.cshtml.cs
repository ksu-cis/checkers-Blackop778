using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Draughts.Pages
{
    public class IndexModel : PageModel
    {
        public Game Game { get; set; }
        public void OnGet()
        {
            Game = new Game();
        }

        public void OnPost(int cx, int cy, int sx, int sy, string state)
        {
            Game = Game.Deserialize(state);
            Checker checker = Game.board[cx, cy];
            checker.Coords = new Coordinates(sx, sy);
            Game.board[cx, cy] = null;
            Game.board[sx, sy] = checker;
        }
    }
}
