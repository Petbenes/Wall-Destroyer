//#####################################################################################
//
// třída vozicek
// - vytvořeno 3.5.2023
// - upraveno 3.5.2023
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
    internal class clsVozicek
    {
        // grafika pro kreslení
        Graphics mobjGrafika;

        // proměnná vozicku
        int mintXVozicku, mintYVozicku;
        int mintVyskaVozicku, mintSirkaVozicku;

        //------------------------------------------------
        // konstruktor
        //------------------------------------------------
        public clsVozicek(Graphics objPlatno, int intXVozicku, int intYVozicku, int intSirkaVozicku, int intVyskaVozicku)
        {
            mobjGrafika = objPlatno;
            mintXVozicku = intXVozicku;
            mintYVozicku = intYVozicku;
            mintVyskaVozicku = intVyskaVozicku;
            mintSirkaVozicku = intSirkaVozicku;
        }

        //------------------------------------------------
        // vykreslení vozicku
        //------------------------------------------------
        public void NakresliSe()
        {
            // vykreslení vozicku
            mobjGrafika.FillRectangle(Brushes.Black, mintXVozicku, mintYVozicku, mintSirkaVozicku, mintVyskaVozicku);
        }
    }
}
