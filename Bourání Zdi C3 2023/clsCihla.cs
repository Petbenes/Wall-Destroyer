﻿//#####################################################################################
//
// třída cihly
// - vytvořeno 19.4.2023
// - upraveno 19.4.2023
// - autor: 
//
//#####################################################################################

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		bool mblJeVidet;
		public bool mblOdrazCihly;

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
			mblJeVidet = true;

        }
		//------------------------------------------------
		// vykreslení cihly
		//------------------------------------------------

		public void NakresliSe()
		{
			// test viditelnosti cihly
			if (mblJeVidet == false) return;

			// vykreslení cihly
			mobjGrafika.FillRectangle(Brushes.Orange, mintXCihly, mintYCihly, mintSirkaCihly, mintVyskaCihly);
		}

		//------------------------------------------------
		// test kolize cihly s kulickou
		// - vrací true pokud došlo ke kolizi
		//------------------------------------------------

		public bool TestKolize(int intXK, int intYK, int intWK, int intHK)
		{
			// test viditelnosti cihly
			if (mblJeVidet == false) return false;

            Rectangle rcKulicka = new Rectangle(intXK, intYK, intWK, intHK);
            Rectangle rcCihla = new Rectangle(mintXCihly, mintYCihly, mintSirkaCihly, mintVyskaCihly);

            if (rcKulicka.IntersectsWith(rcCihla))
            {
                mblOdrazCihly = true;
                mblJeVidet = false; 
				return true;
            }
            else
			{
				// nedošlo ke kolizi
				return false;
			}
        }
    }
}
