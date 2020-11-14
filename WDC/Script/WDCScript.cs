﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardeclarer.Core;

namespace Wardeclarer.Script
{
	public interface WDCScript : IRenderable
	{
		void BeforeRunScript();

		void Init(Engine engine);

		void Render(Graphics g, IRenderer renderer);

		void SetRenderPanel(frmRenderPanel frmRenderPanel);
	}
}