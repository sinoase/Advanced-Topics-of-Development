using System;
using System.Windows.Forms;
using System.Threading;
using _1_Button;

namespace ConsoleApplication
{

    class Program
    {
        FormB form1;//Campo del programa 

        static void Main(string[] args)
        {                      
            Program p = new Program();
            //Se crea y se inicia el hilo que va a cargar el form
            Thread t1 = new Thread(p.Start);
            t1.Start();
            Thread.Sleep(500);
            /////////////////
            p.Move();            
        }

        void Start()
        {
            form1 = new FormB();
            form1.Init();
            Application.EnableVisualStyles();//Hace que se vea más chido
            Application.Run(form1);//Corre el formulario y lo muestra en pantalla
        }

        void Move()
        {
            Random random = new Random();
            while (true)
            {
                    Direcciones dir = (Direcciones)random.Next(0, 8);
                    int largo = random.Next(30,400);
                    form1.but.Go(dir,largo);                               
            }
        }
    
        class FormB :Form
        {
            public CrazyButton but;           
            public void Init()
            {
                
                SetBounds(500, 500, 600, 400);//Para cambiar la posición
                but = new CrazyButton();
                but.Init(Width,Height);                                           
                Controls.Add(but);//Agrega el botón al form
                Visible = true;
                
            }
         
           
        }
        
        
  
    }
}
