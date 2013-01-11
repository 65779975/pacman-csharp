using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman
{
    public class Gamestate
    {
        private int m_Lives;
        private int m_Level;
        private int m_Score;
        private int m_HighScore;
        private Map m_Map;

        public int Lives
        {
            get { return m_Lives; }
            set { m_Lives = value; }
        }
        public int Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }
        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public int HighScore
        {
            get { return m_HighScore; }
            set { m_HighScore = value; }
        }
        public Map Map
        {
            get { return m_Map; }
            set { m_Map = value; }
        }
    }
}
