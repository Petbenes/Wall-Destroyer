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

        // třída a proměnná kulicky
        clsKulicka mobjKulicka;
        int mintPohybX, mintPohybY;

        // třída vozicku
        clsVozicek mobjVozicek;

        // zobrazení vozicku
        int mintXVozicku;
        int mintYVozicku;
        const int mintVyskaVozicku = 70;
        const int mintSirkaVozicku = 20;

        // ovladani
        bool goLeft;
        bool goRight;

        // pole cihel
        int mintPocetCihel;
        clsCihla [] mobjCihla;
        const int mintSirkaCihly = 80, mintVyskaCihly = 20;
        const int mintVelikostMezery = 20, mintPocetRadCihel = 3;
        int mintZniceneCihly = 0;

        // rychlost timeru
        const int mintRychlostTimeru = 10;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }

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

            // vytvoření vozicku
            int mintXVozicku = pbPlatno.Width/2;
            int mintYVozicku = pbPlatno.Height - 50;
            mobjVozicek = new clsVozicek(mobjGrafika, mintXVozicku, mintYVozicku, mintVyskaVozicku, mintSirkaVozicku);

            // vytvoreni pole
            mintPocetCihel = mintPocetRadCihel *
                ((pbPlatno.Width - mintVelikostMezery) /
                (mintSirkaCihly + mintVelikostMezery));

            mobjCihla = new clsCihla[mintPocetCihel];

            // vytvoreni cihel
            lintX = lintY = mintVelikostMezery;
            for (int i = 0; i < mintPocetCihel; i++)
            {
				// test změna souřadnic
				if ((lintX  + mintSirkaCihly + mintVelikostMezery) > (pbPlatno.Width))
				{
					lintX = mintVelikostMezery;
					lintY = lintY + mintVelikostMezery + mintVyskaCihly;
				}

				// init jedné cihly
				mobjCihla[i] = new clsCihla(mobjGrafika, lintX, lintY, mintSirkaCihly, mintVyskaCihly);

                // finální změna souřadnic
                lintX = lintX + mintSirkaCihly + mintVelikostMezery;
            }
        }

        private void tmrPrekresli_Tick(object sender, EventArgs e)
        {
            // smazání scény
            mobjGrafika.Clear(Color.White);

            // obnovení vozicku
            mobjVozicek.NakresliSe();

            // pohyb kulicky
            mobjKulicka.Pohyb();

            // pohyb vozicku
            if (goLeft == true)
            {
                mobjVozicek.mintPohybXVozicku = mobjVozicek.mintPohybXVozicku - 1;
            }
            if (goRight == true)
            {
                mobjVozicek.mintPohybXVozicku = mobjVozicek.mintPohybXVozicku + 1;
            }

            // test kolize vozicku
            mobjVozicek.TestKolize(mobjKulicka.intXK, mobjKulicka.intYK, mobjKulicka.intWK, mobjKulicka.intHK);
            if (mobjVozicek.mblOdrazVozicku == true)
            {
                mobjKulicka.mintPohybY = -mobjKulicka.mintPohybY;
                mobjVozicek.mblOdrazVozicku = false;
            }

                // test kolize všech cihel
                foreach (clsCihla objCihla in mobjCihla)
            {
               objCihla.TestKolize(mobjKulicka.intXK, mobjKulicka.intYK, mobjKulicka.intWK, mobjKulicka.intHK);
               if (objCihla.mblOdrazCihly == true)
                {
                    mintZniceneCihly++;
                    mobjKulicka.mintPohybY = -mobjKulicka.mintPohybY;
                    objCihla.mblOdrazCihly = false;
                }
            }

            // vykreslení všech cihel
            foreach (clsCihla objCihla in mobjCihla)
            {
				objCihla.NakresliSe();
            }

            // podmínky prohry
            if (mobjKulicka.intYK > pbPlatno.Height - 20)
            {
                tmrPrekresli.Stop();
                MessageBox.Show("Game Over");
                this.Close();
            }
            // podmínky výhry
            if (mintZniceneCihly == mintPocetCihel)
            {
                tmrPrekresli.Stop();
                MessageBox.Show("GG");
                this.Close();
            }
        }
    }
}
