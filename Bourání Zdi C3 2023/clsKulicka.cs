//#####################################################################################
//
// třída kulicky
// - vytvořeno 19.4.2023
// - upraveno 19.4.2023
// - autor: 
//
//#####################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bourání_Zdi_C3_2023
{
    class clsKulicka
    {
        // grafika pro kreslení
        Graphics mobjGrafika;

        // proměnná kuličky
        int mintXKulicky, mintYKulicky;
        public int mintPohybX, mintPohybY;
        const int mintRKulicky = 15;
        const int mintRychlostPosunu = 2;

        //------------------------------------------------
        // konstruktor
        //------------------------------------------------

        public clsKulicka(Graphics objPlatno)
        {
            mobjGrafika = objPlatno;

            mintXKulicky = (int)objPlatno.VisibleClipBounds.Width / 2;
            mintYKulicky = (int)objPlatno.VisibleClipBounds.Height / 2;
            mintPohybX = mintRychlostPosunu;
            mintPohybY = mintRychlostPosunu;
        }

        // načtení hodnot souřadnic kuličky
        public int intXK
        {
            get { return mintXKulicky; }
        }
        public int intYK { get { return mintYKulicky; } }
        public int intWK { get { return mintRKulicky; } }
        public int intHK { get { return mintRKulicky; } }

        //------------------------------------------------
        // pohyb kulicky po plátně
        //------------------------------------------------

        public void Pohyb()
        {
            // vykreslení kulicky
            mobjGrafika.FillEllipse(Brushes.Red, mintXKulicky, mintYKulicky, mintRKulicky, mintRKulicky);

            // posun
            mintXKulicky += mintPohybX;
            mintYKulicky += mintPohybY;

            // test kolize na hranách
            if (((mintYKulicky + mintRKulicky) > mobjGrafika.VisibleClipBounds.Height) ||
                (mintYKulicky < 0))
                mintPohybY = mintPohybY * (-1);
            if (((mintXKulicky + mintRKulicky) > mobjGrafika.VisibleClipBounds.Width) ||
                (mintXKulicky < 0))
                mintPohybX = mintPohybX * (-1);
        }
    }
}
