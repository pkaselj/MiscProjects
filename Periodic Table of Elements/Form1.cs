using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StandardniBotun;

namespace Periodni_Sustav_Elemenata
{
    public partial class Form1 : Form
    {
        List<PictureBox> Jezici = new List<PictureBox>();
        public static PictureBox trenutniJezik;
        public static PictureBox s_UKPictureBox;
        public static PictureBox s_DEPictureBox;
        public static PictureBox s_HRPictureBox;

        public static List<Button> Elementi = new List<Button>();

        Detalji Detalji_Float = new Detalji();

        public Form1()
        {
            InitializeComponent();
            Jezici.AddRange(new PictureBox[] {UKPictureBox, DEPictureBox, HRPictureBox });

            foreach (PictureBox p in Jezici)
                p.Click += new EventHandler(ProminiJezik);
            trenutniJezik = UKPictureBox;

            s_UKPictureBox = (PictureBox)UKPictureBox;
            s_DEPictureBox = (PictureBox)DEPictureBox;
            s_HRPictureBox = (PictureBox)HRPictureBox;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProminiJezik(UKPictureBox,e);
            Resursi.Postavi();
            PostaviTablicu();
            PostaviStandardTab();
            PostaviTemperatureTab();
            //TextReader.Ispisi();
            temperatunaTraka_Scroll(temperatunaTraka,e);
            PostaviBoje();
        }

        private void PostaviTooltipove()
        {
            toolTip1.SetToolTip(UKPictureBox, Resursi.Prevedi("Engleski"));
            toolTip1.SetToolTip(DEPictureBox, Resursi.Prevedi("Njemacki"));
            toolTip1.SetToolTip(HRPictureBox, Resursi.Prevedi("Hrvatski"));

            toolTip1.SetToolTip(optionsPictureBox, Resursi.Prevedi("Postavke"));
        }

        private void PostaviTablicu()
        {
            standardTab.Text = Resursi.Prevedi("standardTab");
            temperatureTab.Text = Resursi.Prevedi("temperatureTab");
            //useTab.Text = Resursi.Prevedi("useTab");
            Text = Resursi.Prevedi("Title");

        }

        public void PostaviBoje() {

            if(tabControl1.SelectedTab == standardTab)
                BackColor = CustomColors.standardColor;
            else
                BackColor = CustomColors.temperatureColor;

            s.BackColor = CustomColors.solid;
            l.BackColor = CustomColors.liquid;
            g.BackColor = CustomColors.gas;

            foreach (Control cnt in panel.Controls)
                if(cnt is Button)
                {
                    Button button = cnt as Button;
                    if (button.Tag == "alkalijski")
                        button.BackColor = CustomColors.alkalijski;
                    else if (button.Tag == "zemnoalkalijski")
                        button.BackColor = CustomColors.zemnoalkalijski;
                    else if (button.Tag == "prijelazni")
                        button.BackColor = CustomColors.prijelazni;
                    else if (button.Tag == "post")
                        button.BackColor = CustomColors.postprijelazni;
                    else if (button.Tag == "polumetali")
                        button.BackColor = CustomColors.polumetali;
                    else if (button.Tag == "nemetali")
                        button.BackColor = CustomColors.nemetali;
                    else if (button.Tag == "plemeniti")
                        button.BackColor = CustomColors.plemeniti;
                    else if (button.Tag == "f")
                        button.BackColor = CustomColors.fblok;
                    else
                        button.BackColor = CustomColors.errorColor;
                }

            standardTab.BackColor = CustomColors.standardColor;
            temperatureTab.BackColor = CustomColors.temperatureColor;
        }

        private void PostaviStandardTab()
        {
            Button button;
            foreach (Control btn in panel.Controls)
            {
                if (btn is Button)
                {
                    button = (Button)btn;
                    button.Dock = DockStyle.Fill;
                    button.Text = TextReader.simboli.ElementAt(button.TabIndex);
                    btn.MouseEnter += new EventHandler(MouseHover);
                    btn.MouseLeave += new EventHandler(MouseLeave);
                }
            }
        }

        private void PostaviTemperatureTab()
        {
            s.BackColor = CustomColors.solid;
            l.BackColor = CustomColors.liquid;
            g.BackColor = CustomColors.gas;

            Button button;
            foreach (Control btn in panel2.Controls)
            {
                if (btn is Button && btn.TabIndex < 200)
                {
                    button = (Button)btn;
                    button.Dock = DockStyle.Fill;
                    button.Text = TextReader.simboli.ElementAt(button.TabIndex);
                }
            }
        }


        private void ProminiJezik(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;

            if (trenutniJezik == UKPictureBox)
                UKPictureBox.Image = Properties.Resources.uk;
            else if (trenutniJezik == DEPictureBox)
                DEPictureBox.Image = Properties.Resources.de;
            else
                HRPictureBox.Image = Properties.Resources.hr;

            trenutniJezik = p;

            if (p == UKPictureBox)
            {
                p.Image = Properties.Resources.g_uk;
                TextReader.Ucitaj("en");
            }
            else if (p == DEPictureBox)
            {
                p.Image = Properties.Resources.g_de;
                TextReader.Ucitaj("de");
            }
            else
            {
                p.Image = Properties.Resources.g_hr;
                TextReader.Ucitaj("hr");
            }
            PostaviTablicu();
            PostaviTooltipove();
        }
        public static int Temperatura;

        public void PromijeniBoju(int temp)
        {
            Button button;
            //MessageBox.Show(Double.Parse(TextReader.temperatureIsparavanja.ElementAt(46)).ToString(),"");
            foreach(Control cnt in panel2.Controls) {
                if(cnt is Button && cnt.TabIndex < 200)
                {
                    button = cnt as Button;
                    button.BackColor = CustomColors.solid;
                    if (Double.Parse(TextReader.temperatureTaljenja.ElementAt(button.TabIndex)) < 999998)
                    {
                        if (Double.Parse(TextReader.temperatureTaljenja.ElementAt(button.TabIndex)) < temp)
                            button.BackColor = CustomColors.liquid;
                        if (Double.Parse(TextReader.temperatureIsparavanja.ElementAt(button.TabIndex)) < temp)
                            button.BackColor = CustomColors.gas;
                    }
                    else
                        button.BackColor = CustomColors.errorColor;

                }
            }
        }

        public static int temperature;
        private void temperatunaTraka_Scroll(object sender, EventArgs e)
        {
                TrackBar temperatura = sender as TrackBar;
            temperature = temperatura.Value;
                temperatureLabel.Text = String.Format("Temp.:\n{0} °C\n{1} K", temperature, temperature + 274);
                PromijeniBoju(temperature);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == temperatureTab)
                BackColor = CustomColors.temperatureColor;
            else if (tabControl1.SelectedTab == standardTab)
                BackColor = CustomColors.standardColor;
        }

        private void MouseHover(object sender, EventArgs e)
        {
            Button button = sender as Button;
            try
            {
                Detalji_Float.BackColor = button.BackColor;
                Detalji_Float.Location = new Point(Location.X + button.Location.X + button.Size.Width + 100,Location.Y + button.Location.Y + button.Size.Height);
            }
            catch (Exception ex) {; }

            Detalji_Float.Visible = true;

            int mjesto = button.TabIndex;

            foreach(Control cnt in Detalji_Float.Controls)
            {
                if (cnt is Label)
                {
                    Label labela = cnt as Label;
                    if (labela.Name == "protonskiBroj")
                        labela.Text = TextReader.protonskiBrojevi.ElementAt(mjesto);
                    else if (labela.Name == "maseniBroj")
                        labela.Text = TextReader.maseniBrojevi.ElementAt(mjesto);
                    else if (labela.Name == "simbol")
                        labela.Text = button.Text;
                    else if (labela.Name == "temperaturaTaljenja")
                    {
                        if (Double.Parse(TextReader.temperatureTaljenja.ElementAt(mjesto)) <= 999998)
                            labela.Text = Double.Parse(TextReader.temperatureTaljenja.ElementAt(mjesto)).ToString() + "°C";
                        else
                            labela.Text = Resursi.Prevedi("nepoznato");
                    }
                    else if (labela.Name == "temperaturaIsparavanja")
                    {
                        if (Double.Parse(TextReader.temperatureIsparavanja.ElementAt(mjesto)) <= 999998)
                            labela.Text = Double.Parse(TextReader.temperatureIsparavanja.ElementAt(mjesto)).ToString() + "°C";
                        else
                            labela.Text = Resursi.Prevedi("nepoznato");
                    }
                    else if (labela.Name == "opis")
                        labela.Text = TextReader.opisi.ElementAt(mjesto);
                    else if (labela.Name == "koristenje")
                        labela.Text = TextReader.koristenja.ElementAt(mjesto);
                    else if (labela.Name == "ime")
                        labela.Text = TextReader.imena.ElementAt(mjesto);
                }
            }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            Detalji_Float.Visible = false;
        }

        private void PostavkeClick(object sender, EventArgs e)
        {
            Postavke postavke = new Postavke();
            postavke.parent = this;
            postavke.Show();

        }
    }
}
