﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class PictureBoxRedondo : PictureBox
{
    public PictureBoxRedondo()
    {
        this.BackColor = Color.DarkGray;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using (GraphicsPath gp = new GraphicsPath())
        {
            gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
            Region = new Region(gp);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.FromArgb(176, 7, 49)), 3), 0, 0, this.Width-1, this.Height-1);
        }
    }
}