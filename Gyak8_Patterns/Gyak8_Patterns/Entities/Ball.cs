﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyak8_Patterns
{
    public class Ball:Label
    {
        public Ball()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Ball_Painting;
        }

        private void Ball_Painting(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

        public void MoveBall()
        {
            Left += 1;
        }
    }
}
