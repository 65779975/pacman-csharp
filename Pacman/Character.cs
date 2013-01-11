using System;
using System.Drawing;

namespace Pacman
{
    public class Character
    {
        private Point m_location;
        private Direction m_direction;

        public Point Location
        {
            get { return m_location; }
            set { m_location = value; }
        }
        public Direction Direction
        {
            get { return m_direction; }
            set { m_direction = value; }
        }
    }
}
