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
using System.Windows.Forms;

namespace Bourání_Zdi_C3_2023
{
    internal class clsVozicek
    {
        // grafika pro kreslení
        Graphics mobjGrafika;

        // proměnná vozicku
        int mintXVozicku, mintYVozicku;
        int mintVyskaVozicku, mintSirkaVozicku;
        const int mintRychlostVozicku = 4;
        public int mintPohybXVozicku;
        public bool mblOdrazVozicku;

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
            mintPohybXVozicku = mintRychlostVozicku;
        }

        //------------------------------------------------
        // vykreslení vozicku
        //------------------------------------------------
        public void NakresliSe()
        {
            // vykreslení vozicku
            mobjGrafika.FillRectangle(Brushes.Black, mintXVozicku, mintYVozicku, mintSirkaVozicku, mintVyskaVozicku);

            // posun
            mintXVozicku += mintPohybXVozicku;

            // test kolize na hranách
            if (((mintXVozicku + mintSirkaVozicku + mintVyskaVozicku) > mobjGrafika.VisibleClipBounds.Width) ||
                (mintXVozicku < 0))
                mintPohybXVozicku = -mintPohybXVozicku;
        }
        public bool TestKolize(int intXK, int intYK, int intWK, int intHK)
        {
            Rectangle rcKulicka = new Rectangle(intXK, intYK, intWK, intHK);
            Rectangle rcVozicek = new Rectangle(mintXVozicku, mintYVozicku, mintSirkaVozicku, mintVyskaVozicku);

            if (rcKulicka.IntersectsWith(rcVozicek))
            {
                mblOdrazVozicku = true;
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
