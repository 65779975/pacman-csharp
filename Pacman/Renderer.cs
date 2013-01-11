using System;
using System.Drawing;



namespace Pacman
{
    public class Renderer
    {

        private int m_blockSize;
        private int m_HeaderHeight;
        private int m_FooterHeight;
        private Font m_Font;
        private TileRenderer m_tileRend;
        private CharacterRenderer m_charRend;


        public void Init(Font f)
        {
            m_blockSize = 16;
            m_Font = f;
            m_HeaderHeight = (int) m_Font.GetHeight() * 3;
            m_FooterHeight = 100;
            m_tileRend = new TileRenderer(m_blockSize, m_HeaderHeight);
            m_charRend = new CharacterRenderer(m_blockSize, m_HeaderHeight);
        }


        public void Render(Graphics g, Gamestate gs)
        {
            // Clear the screen
            ClearScreen(g);
            // Draw the score
            DrawScore(g, gs.Score, gs.HighScore);
            // Draw number of lives
            DrawLives(g, gs.Lives, gs.Map.Size.Height * m_blockSize);
            // Draw the map
            DrawMap(g, gs.Map);
            // Draw the pills
            // Draw pacman
            // Draw the baddies
        }

        private void ClearScreen(Graphics g)
        {
            g.Clear(Color.Black);
        }

        private void DrawLives(Graphics g, int lives, int mapHeight)
        {
            int i, x, y;

            y = m_HeaderHeight + mapHeight + m_blockSize / 2;
            for (i = 0; i < lives; i++)
            {
                x = m_blockSize + i * m_blockSize * 2;
                m_charRend.RenderRight(g, x, y);
            }
        }

        private void DrawScore(Graphics g, int score, int highScore)
        {
            Brush brush = new SolidBrush(Color.White);
            g.DrawString("SCORE", m_Font, brush, 40, 5);
            g.DrawString(score.ToString("00000"), m_Font, brush, 40, m_HeaderHeight / 2);

            g.DrawString("HIGH SCORE", m_Font, brush, 100, 5);
            g.DrawString(highScore.ToString("00000"), m_Font, brush, 100, m_HeaderHeight / 2);
        }

        private void DrawMap(Graphics g, Map map)
        {
            int i, j;
            for (i = 0; i < map.Size.Width; i++)
            {
                for (j = 0; j < map.Size.Height; j++)
                {
                    m_tileRend.RenderTile(g, map, i, j);
                }
            }
        }
        

        
        
    }
}
