﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Game
{
	public class SpriteMovement
    {
        public virtual PointF GetNext()
        {
            return new PointF();
        }

        protected virtual PointF GextNextX()
        {
            return new PointF();
        }

        protected virtual PointF GextNextY()
        {
            return new PointF();
        }
    }
}
