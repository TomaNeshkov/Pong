using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Ball
    {
        private readonly char _tile;
        private readonly int _initialX;
        private readonly int _initialY;
        private int x;
        private int y;
        private int dx;
        private int dy;

        public Ball(int x, int y, char tile = '0')
        {
            this._tile = tile;

            this.x = this._initialX = x;
            this.y = this._initialY = y;

            this.dx = 1;
            this.dy = 1;
        }

        public int Y => this.y;
        public int X => this.x;

        public void Draw(Field field)
        {
            field.Set(row: this.x, col: this.y, this._tile);
        }

        public void CalculateTrajectory(Field field, char racketTile)
        {
            field.Set(row: this.x, col: this.y, ' ');

            char place = field.Get(row: this.x + this.dx, col: this.y + this.dy);
            if (place == field.Tile)
            {
                this.dx *= -1;
            }

            if (place == racketTile)
            {
                this.dy *= -1;
            }

            this.x += this.dx;
            this.y += this.dy;

            this.Draw(field);

        }

        public void Reset(Field field)
        {
            field.Set(row: this.x, col: this.y, value: ' ');
            this.x = this._initialX;
            this.y = this._initialY;
            this.Draw(field);
        }
    }
}
