using System;
using System.Windows.Forms;
using System.Threading;
using _1_Button;


namespace ConsoleApplication
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

            but = new CrazyButton();
            but.Init(form1.Width, form1.Height);
            but.MouseHover += But_MouseHover;

            form1.Controls.Add(but);

            Application.EnableVisualStyles();//Hace que se vea más chido
            Application.Run(form1);
        }
        void But_MouseHover(object sender, EventArgs e) => but.Teletransportación();

    }
    
}
