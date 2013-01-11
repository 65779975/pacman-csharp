using System;
using System.Drawing;

namespace Pacman
{
    public class Map
    {
        private Size m_size;
        private TileType[,] m_tiles;

        public Size Size
        {
            get { return m_size; }
            set { m_size = value; }
        }

        public TileType this[int x, int y]
        {
            get
            {
                if (IsValid(x, y)) 
                { 
                    return m_tiles[x, y]; 
                }
                return TileType.Empty;
            }
            set { m_tiles[x, y] = value; }
        }

        public Map(Size sz)
        {
            m_size = sz;
            m_tiles = new TileType[sz.Width, sz.Height];
        }

        private bool IsValid(int x, int y)
        {
            return ((x >= 0) && (y >= 0) && (x < m_size.Width) && (y < m_size.Height));
        }
    }
}
