using System;


using System.Threading;
using System.Windows.Forms;
using Practica3;
namespace Practica3
{
    class Program
    {
        Form form1;
        public CrazyButton but;
        static void Main(string[] args)
        {
            Program p = new Program();
            Thread t1 = new Thread(p.CreateForm);
            t1.Start();
            Thread.Sleep(500);
            /////////////////
            p.but.Go();
        }

        void CreateForm()
        {


            form1 = new Form();
            form1.SetBounds(500, 500, 600, 400);
            form1.Resize += Form1_Resize;
            but = new CrazyButton();
            but.Init(form1.Width, form1.Height);
            but.MouseHover += But_MouseHover;

            form1.Controls.Add(but);

            Application.EnableVisualStyles();//Hace que se vea más chido
            Application.Run(form1);
        }
        void But_MouseHover(object sender, EventArgs e) => but.Teletransportación();
        void Form1_Resize(object sender, EventArgs e) => but.Init(form1.Width, form1.Height);



    }
}
