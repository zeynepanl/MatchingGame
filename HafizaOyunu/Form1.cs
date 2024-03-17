using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafizaOyunu
{
    public partial class Form1 : Form
    {
        Label res1 = null;
        Label res2 = null;

        Random random = new Random();
        List<string> icons = new List<string>()
        { "!" , "!" , "N" , "N" , "," , "," , "k" , "k" ,"b" , "b" ,
          "v" , "v" , "w" , "w" , "z ", "z" , "ö" , "ö" , "c" , "c" ,  
        };

        private void resimAta()
        {
            foreach(Control item in tableLayoutPanel1.Controls)          //tüm kontrolleri aldı
            {
                Label resim = (Label)item;                       //control olarak almıştık labele çevirdik

                if (item != null)
                {
                    int say = random.Next(icons.Count);           //rastgele sayı oluşturduk
                    resim.Text = icons[say];
                    resim.ForeColor = resim.BackColor;              //arka plan ve ön planın rengini aynı yaptık
                    icons.RemoveAt(say);                                       // bulunan iconu kaldırdık
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            resimAta();
        }

      

        private void label_Click(object sender, EventArgs e)
        {

            if(timer1.Enabled == true)
            { //ikinciyi seçtikten sonra timer başlıyor ikinci seçimden sonra oyuncuyu durdurduk
                return;
            }
            Label secim = (Label)sender;
            if(secim != null )
            {
                if(secim.ForeColor==Color.Black)
                { //resim açıksa bir şey yapma
                    return;
                }
                if (res1 == null)
                {
                    res1 = secim;
                    secim.ForeColor = Color.Black;
                    return;
                }
                res2 = secim;
                res2.ForeColor = Color.Black;

                oyunBittimi();
                if (res1.Text == res2.Text)
                {
                    res1 = null;
                    res2 = null;
                    return;
                }
                timer1.Start();                 //zamanlayıcı tekrar başladı
            }
            

        }
        private void oyunBittimi()
        {
            foreach(Control item in tableLayoutPanel1.Controls)
            {
                Label resim = (Label)item;
                if(resim != null )
                {
                    if (resim.ForeColor == resim.BackColor)                 
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Oyun Bitti.");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            res1.ForeColor = res1.BackColor;    //seçilen resimleri gizledik
            res2.ForeColor = res2.BackColor;

            res1 = null;    //seçimleri kaldırdık
            res2 = null;

        }
    }
}
