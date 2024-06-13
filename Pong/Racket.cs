using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Racket
    {
        private readonly int y;
        private readonly int length;
        private readonly int initialX;
        private int x;

        public Racket(int x, int y, int length = 5, char tile = '|')
        {
            this.x = this.initialX = x;
            this.y = y;
            this.length = length;
            this.Tile = tile;
        }
        public char Tile { get; }

        public void Draw(Field field)
        {
            for (int i = 0; i < this.length; i++)
            {
                field.Set(row: i + this.x, col: this.y, this.Tile);
            }
        }

        public void MoveUp(Field field)
        {
            if (field.Get(row: this.x -1, col: this.y) == field.Tile)
            {
                return;
            }
            field.Set(row: this.x + (this.length - 1), col: this.y, value: ' ');
            this.x -= 1;
            field.Set(row: this.x, col: this.y, value: this.Tile);
        }

        public void MoveDown(Field field)
        {
            if (field.Get(row: this.x + this.length, col: this.y) == field.Tile)
            {
                return;
            }
            field.Set(row: this.x, col: this.y, value: ' ');
            this.x += 1;
            field.Set(row: this.x + (this.length - 1), col: this.y, value: this.Tile);
        }

        public void Reset(Field field)
        {
            for (int i=0; i<this.length; i++)
            {
                field.Set(row: i + this.x, col: this.y, value: ' ');
            }

            this.x = this.initialX;
            this.Draw(field);
        }
    }
}
