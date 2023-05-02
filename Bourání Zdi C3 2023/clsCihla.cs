//#####################################################################################
//
// třída cihly
// - vytvořeno 19.4.2023
// - upraveno 19.4.2023
// - autor: 
//
//#####################################################################################

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourání_Zdi_C3_2023
{
    class clsCihla
    {
		// grafika pro kreslení
		Graphics mobjGrafika;

		// proměnná cihly
		int mintXCihly, mintYCihly;
		int mintVyskaCihly, mintSirkaCihly;

		//------------------------------------------------
		// konstruktor
		//------------------------------------------------

		public clsCihla(Graphics objPlatno, int intXCihly, int intYCihly, int intSirkaCihly, int intVyskaCihly)
		{
			mobjGrafika = objPlatno;
			mintXCihly = intXCihly;
			mintYCihly = intYCihly;
			mintVyskaCihly = intVyskaCihly;
			mintSirkaCihly = intSirkaCihly;
		}
		//------------------------------------------------
		// vykreslení cihly
		//------------------------------------------------

		public void NakresliSe()
		{
			mobjGrafika.FillRectangle(Brushes.Orange, mintXCihly, mintYCihly, mintSirkaCihly, mintVyskaCihly);
		}
	}
}
