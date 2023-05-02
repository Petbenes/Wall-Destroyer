using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bourání_Zdi_C3_2023
{
    public partial class Form1 : Form
    {
        int lintX, lintY;

        // grafika pro kreslení
        Graphics mobjGrafika;

        // třída kulicky
        clsKulicka mobjKulicka;

        // pole cihel
        int mintPocetCihel;
        clsCihla [] mobjCihla;
        const int mintSirkaCihly = 80, mintVyskaCihly = 20;
        const int mintVelikostMezery = 20, mintPocetRadCihel = 3;
        
        // rychlost timeru
        const int mintRychlostTimeru = 10;

        private void Form1_Load(object sender, EventArgs e)
        {
            // init-nahrání timeru
            tmrPrekresli.Interval = mintRychlostTimeru;
            tmrPrekresli.Start();
        }

        public Form1()
        {
            InitializeComponent();

            // init proměnných
            mobjGrafika = pbPlatno.CreateGraphics();

            // vytvoření kulicky
            mobjKulicka = new clsKulicka(mobjGrafika);

            // vytvoreni pole
            mintPocetCihel = mintPocetRadCihel *
                ((pbPlatno.Width - mintVelikostMezery) /
                (mintSirkaCihly + mintVelikostMezery));

            mobjCihla = new clsCihla[mintPocetCihel];

            // vytvoreni cihel
            lintX = lintY = mintVelikostMezery;
            for (int i = 0; i < mintPocetCihel; i++)
            {
				//test změna souřadnic
				if ((lintX  + mintSirkaCihly + mintVelikostMezery) > (pbPlatno.Width))
				{
					lintX = mintVelikostMezery;
					lintY = lintY + mintVelikostMezery + mintVyskaCihly;
				}

				//init jedné cihly
				mobjCihla[i] = new clsCihla(mobjGrafika, lintX, lintY, mintSirkaCihly, mintVyskaCihly);

                //finální změna souřadnic
                lintX = lintX + mintSirkaCihly + mintVelikostMezery;
            }
        }

        private void tmrPrekresli_Tick(object sender, EventArgs e)
        {
            // smazání scény
            mobjGrafika.Clear(Color.White);

            // pohyb kulicky
            mobjKulicka.Pohyb();

			//vykreslení všech cihel
			//for (int i = 0; i < mintPocetCihel; i++) ... {mobjCihla[i].NakresliSe();}
			foreach (clsCihla objCihla in mobjCihla)
            {
				objCihla.NakresliSe();
            }
		}
    }
}
