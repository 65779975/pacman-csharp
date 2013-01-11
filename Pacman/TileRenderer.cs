using System;
using System.Drawing;
using System.Collections; 

namespace Pacman
{
    public class TileRenderer
    {
        // Fields

        private int m_pillRadius;
        private int m_powerPillRadius;
        private int m_blockSize;
        private int m_headerSize;
        private Brush m_brPill;
        private Pen m_pWall;
        private Pen m_pDoor;

        // Constructor

        public TileRenderer(int blockSize, int headerSize)
        {
            m_blockSize = blockSize;
            m_pillRadius = m_blockSize / 8;
            m_powerPillRadius = m_blockSize / 4;
            m_pWall = new Pen(Color.Blue, 2);
            m_pDoor = new Pen(Color.White, 2);
            m_brPill = new SolidBrush(Color.Yellow);
            m_headerSize = headerSize;
        }
        
        // Methods

        public void RenderTile(Graphics g, Map m, int i, int j)
        {
            int x, y;
            int wall = 16;

            x = i * m_blockSize;
            y = m_headerSize + j * m_blockSize;
            switch (m[i, j])
            {
                case TileType.Pill:
                    DrawPill(g, x, y);
                    break;
                case TileType.PowerPill:
                    DrawPowerPill(g, x, y);
                    break;
                case TileType.Wall:
                    if (LikeWall(m[i - 1, j - 1]))
                        wall |= 1;
                    if (LikeWall(m[i, j - 1]))
                        wall |= 2;
                    if (LikeWall(m[i + 1, j - 1]))
                        wall |= 4;
                    if (LikeWall(m[i - 1, j]))
                        wall |= 8;
                    if (LikeWall(m[i + 1, j]))
                        wall |= 32;
                    if (LikeWall(m[i - 1, j+1]))
                        wall |= 64;
                    if (LikeWall(m[i, j+1]))
                        wall |= 128;
                    if (LikeWall(m[i + 1, j+1]))
                        wall |= 256;
                    DrawWall(g, wall, x, y);
                    break;
                case TileType.BadguyDoor:
                    if (LikeWall(m[i - 1, j]))
                        DrawHorizontalDoor(g, x, y);
                    else
                        DrawVerticalDoor(g, x, y);
                    break;
            }
        }

        // Internal Methods

        private bool LikeWall(TileType t)
        {
            return ((t == TileType.Wall) || (t== TileType.BadguyDoor));
        }

        private void DrawPill(Graphics g, int x, int y)
        {
            Rectangle rect = new Rectangle(x + m_blockSize / 2 - m_pillRadius, 
                    y + m_blockSize / 2 - m_pillRadius, 
                    m_pillRadius * 2, 
                    m_pillRadius * 2);
            g.FillEllipse(m_brPill, rect);
        }

        private void DrawPowerPill(Graphics g, int x, int y)
        {
            Rectangle rect = new Rectangle(x + m_blockSize / 2 - m_powerPillRadius,
                    y + m_blockSize / 2 - m_powerPillRadius,
                    m_powerPillRadius * 2,
                    m_powerPillRadius * 2);
            g.FillEllipse(m_brPill, rect);
        }

        private void DrawWall(Graphics g, int wall, int x, int y)
        {
            switch (wall)
            {
                case 511:
                    return;
                case 27:
                    goto case 26;
                case 26:
                    DrawUpLeftCorner(g, x, y);
                    return;
            }
            if (wall == 511)
            {
                return;
            }
            else if ((wall == 26) || (wall == 27) || (wall == 218) || (wall == 510))
            {
                DrawUpLeftCorner(g, x, y);
            }
            else if ((wall == 54) || (wall == 50) || (wall == 434) || (wall == 507))
            {
                DrawUpRightCorner(g, x, y);
            }

            else if ((wall == 152) || (wall == 155) || (wall == 216) || (wall == 440) || (wall == 447))
            {
                DrawDownLeftCorner(g, x, y);
            }

            else if ((wall == 176) || (wall == 182) || (wall == 248) || (wall == 255) || (wall == 432))
            {
                DrawDownRightCorner(g, x, y);
            }
            else if (((wall & 2) > 0) && ((wall & 128) > 0))
            {
                DrawVerticalWall(g, x, y);
            }
            else
            {
                DrawHorizontalWall(g, x, y);
            }
        }


        private void DrawUpLeftCorner(Graphics g, int x, int y)
        {
            Rectangle rect = new Rectangle(x - m_blockSize / 2 - 1,
                    y - m_blockSize / 2 - 1,
                    m_blockSize + 1,
                    m_blockSize + 1);

            g.DrawArc(m_pWall, rect, 0, 90);
        }
        private void DrawUpRightCorner(Graphics g, int x, int y)
        {
            Rectangle rect = new Rectangle(x + m_blockSize / 2 - 1,
                    y - m_blockSize / 2 - 1,
                    m_blockSize + 1,
                    m_blockSize + 1);

            g.DrawArc(m_pWall, rect, 90, 90);
        }
        private void DrawDownRightCorner(Graphics g, int x, int y)
        {
            Rectangle rect = new Rectangle(x + m_blockSize / 2 - 1,
                    y + m_blockSize / 2 - 1,
                    m_blockSize + 1,
                    m_blockSize + 1);

            g.DrawArc(m_pWall, rect, 180, 90);
        }
        private void DrawDownLeftCorner(Graphics g, int x, int y)
        {
            Rectangle rect = new Rectangle(x - m_blockSize / 2 - 1,
                    y + m_blockSize / 2 - 1,
                    m_blockSize + 1,
                    m_blockSize + 1);

            g.DrawArc(m_pWall, rect, 270, 90);
        }
        private void DrawHorizontalWall(Graphics g, int x, int y)
        {
            g.DrawLine(m_pWall, x, y + m_blockSize / 2, x + m_blockSize, y + m_blockSize / 2);
        }
        private void DrawVerticalWall(Graphics g, int x, int y)
        {
            g.DrawLine(m_pWall, x + m_blockSize / 2, y, x + m_blockSize / 2, y + m_blockSize);
        }

        private void DrawHorizontalDoor(Graphics g, int x, int y)
        {
            g.DrawLine(m_pDoor, x, y + m_blockSize / 2, x + m_blockSize, y + m_blockSize / 2);
        }
        private void DrawVerticalDoor(Graphics g, int x, int y)
        {
            g.DrawLine(m_pDoor, x + m_blockSize / 2, y, x + m_blockSize / 2, y + m_blockSize);
        }
    }
}
