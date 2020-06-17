﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wardeclarer.Core;
using Wardeclarer.Forms;
using Wardeclarer.Interface;
using Wardeclarer.Properties;
using Wardeclarer.Script;

namespace Wardeclarer
{
    public partial class frmRenderPanel : Form
    {
        private bool isEditMode;
        private Timer timer = new Timer();
        //private WDCScript currentScript;
        private int mouseX;
        private int mouseY;
        private Bitmap worldmap;
        private Engine engine;
        private frmDeveloperConsole developerConsole;

        public Engine Engine
		{
			get { return engine; }
		}
        public frmRenderPanel(WDCScript currentScript)
        {
            InitializeComponent();
            isEditMode = false;
            engine = new Engine();
            engine.Init(currentScript);
            engine.StartNewGame();
            developerConsole = new frmDeveloperConsole();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //TODO: Loop play the music
            engine.MainFormLoaded(this);
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawImage(worldmap, 0, 0, Width, Height);
            if (isEditMode)
            {
                Font font = new Font("Baskerville Old Face", 50);
                e.Graphics.DrawString(string.Format("Mouse X: {0}, Mouse Y: {1}", mouseX, mouseY), font, Brushes.White, 0, 0);
            }
            //Execute run script
            engine.Update(e.Graphics);
            g.Flush();
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isEditMode = !isEditMode;
            }
            else
            {
                engine.MouseClicked(e.X, e.Y);
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;

            engine.MouseMoved(e.X, e.Y);
        }

		public void SetWorldMap(Bitmap worldmap)
		{
            this.worldmap = worldmap;
		}

		private void frmRenderPanel_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.I)
            {
                if (!developerConsole.Visible)
                {
                    developerConsole.Show();
                    developerConsole.BringToFront();
                }
				else
				{
                    developerConsole.Hide();
				}
            }
		}
	}
}
