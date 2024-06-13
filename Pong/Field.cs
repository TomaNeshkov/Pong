using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Field
    {
        private readonly char[,] _field;
        public char Tile { get; }
        public Field(int width, int height, char tile = '#')
        {
            this._field = new char[height, width];
            this.Tile = tile;

            for (int i = 0; i < this.GetCols; i++)
            {
                this.Set(row: 0, col: i, tile);
                this.Set(row: this.GetRows-1, col: i, tile);
            }
        }

        public int GetRows => this._field.GetLength(dimension: 0);
        public int GetCols => this._field.GetLength(dimension: 1);

        public char Get(int row, int col)
        {
            return this._field[row, col];
        }

        public void Set(int row, int col, char value)
        {
            this._field[row, col] = value;
        }
    }
}
