using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Pacman
{
    public class CharacterRenderer
    {
        // Constants

        private const int MaxFrames = 2;
        private const int Degrees = 60;

        // Fields

        private int m_frame;
        private int m_blockSize;
        private int m_headerSize;
        private Brush m_brChar;

        // Constructor

        public CharacterRenderer(int blockSize, int headerSize)
        {
            m_brChar = new SolidBrush(Color.Yellow);
            m_blockSize = blockSize;
            m_headerSize = headerSize;
        }

        // Methods

        public void Render(Graphics g, Character c)
        {
            int x, y;

            x = c.Location.X * m_blockSize;
            y = m_headerSize + c.Location.Y * m_blockSize;

            if (m_frame == 0)
            {
                RenderClosed(g, x, y);
            }
            else
            {
                if (c.Direction == Direction.Up)
                {
                    RenderUp(g, x, y);
                }
                else if (c.Direction == Direction.Right)
                {
                    RenderRight(g, x, y);
                }
                else if (c.Direction == Direction.Down)
                {
                    RenderDown(g, x, y);
                }
                else
                {
                    RenderLeft(g, x, y);
                }
            }

            m_frame = (m_frame + 1) % MaxFrames;
        }

        // Internal Methods

        private void RenderClosed(Graphics g, int x, int y)
        {
            g.FillEllipse(m_brChar, GetRect(x, y));
        }
        private void RenderUp(Graphics g, int x, int y)
        {
            g.FillPie(m_brChar, GetRect(x, y), -90 + Degrees / 2, 360 - Degrees);
        }
        public void RenderRight(Graphics g, int x, int y)
        {
            g.FillPie(m_brChar, GetRect(x, y), Degrees / 2, 360 - Degrees);
        }
        private void RenderDown(Graphics g, int x, int y)
        {
            g.FillPie(m_brChar, GetRect(x, y), 90 + Degrees/2, 360 - Degrees);
        }
        private void RenderLeft(Graphics g, int x, int y)
        {
            g.FillPie(m_brChar, GetRect(x, y), 180 + Degrees / 2, 360 - Degrees);
        }

        private Rectangle GetRect(int x, int y)
        {
            return new Rectangle(x - m_blockSize / 4,
                    y - m_blockSize / 4,
                    m_blockSize * 3 / 2,
                    m_blockSize * 3 / 2);
        }

    }
}
