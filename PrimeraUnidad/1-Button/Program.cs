using System;
using System.Windows.Forms;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Form1 form1 = new Form1();

            form1.Init();
            Application.EnableVisualStyles();
            Application.Run(form1);

        }
        class Form1 :Form
        {
            private Button but;
            public void Init()
            {
                SetBounds(500, 500, 400, 200);
                but = new Button();
                but.SetBounds(135, 50, 100, 50);
                but.Visible = true;
                but.Text = "GitHub";
                but.Click+= butClicked;
                Controls.Add(but);
                Visible = true;
            }
            public void butClicked(object sender,EventArgs e)
            {
                Console.WriteLine("Hola panas");
                System.Diagnostics.Process.Start("https://github.com/sinoase");
            }
        }
        
    }
}
