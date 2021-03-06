using System;
using System.Windows.Forms;
using System.Threading;
namespace ConsoleApplication
{
    class Program
    {
        FormB form1;

        static void Main(string[] args)
        {
            
          
            Program p = new Program();
            Thread t1 = new Thread(p.Start);
            t1.Start();
            Thread.Sleep(500);
            p.Move();
            

        }
        void Start()
        {
            form1 = new FormB();
            form1.Init();
            Application.EnableVisualStyles();
            Application.Run(form1);
        }
        void Move()
        {
            Random random = new Random();
            //Direccion anterior=(Direccion)random.Next(0,8);
            while (true)
            {
                
                Direccion dir = (Direccion)random.Next(0, 8);
                
                //if (anterior != dir)
                //{
                    Console.WriteLine(dir);
                  //  anterior = dir;
                    form1.but.Go(dir);
                    //form1.but.Return(dir);
                //}
               
            }
        }
    
        class FormB :Form
        {
            public CrazyButton but;
            
            public void Init()
            {
                
                SetBounds(500, 500, 600, 400);
                but = new CrazyButton();
                but.Init(Width,Height);
             

                
                
                Controls.Add(but);
                Visible = true;
                
            }
         
           
        }
        class CrazyButton : Button
        {
            int LimiteDerecha, LimiteIzquierda;
            int LimiteArriba, LimiteAbajo;
           

            public void Init(int width, int height)
            {
                SetBounds((width / 2) - 50, (height / 2) - 40, 100, 50);
                Visible = true;
                Text = "Hola";
                LimiteDerecha = width-115 ;
                LimiteIzquierda = 0 ;
                LimiteArriba =0;
                LimiteAbajo = height -89;

            }

            bool HuboChoque() => Bounds.X > LimiteDerecha || Bounds.X < LimiteIzquierda || Bounds.Y < LimiteArriba || Bounds.Y > LimiteAbajo;

           
            public void Go(Direccion dir)
            {
                do
                {
                 

                    Thread.Sleep(1);
                    switch ((int)dir)
                    {
                        case 0:
                            SetBounds(Bounds.X, Bounds.Y - 1, Width, Height);
                            break;
                        case 1:
                            SetBounds(Bounds.X + 1, Bounds.Y - 1, Width, Height);
                            break;
                        case 2:
                            SetBounds(Bounds.X + 1, Bounds.Y, Width, Height);
                            break;
                        case 3:
                            SetBounds(Bounds.X + 1, Bounds.Y + 1, Width, Height);
                            break;
                        case 4:
                            SetBounds(Bounds.X , Bounds.Y+1, Width, Height);
                            break;
                        case 5:
                            SetBounds(Bounds.X - 1, Bounds.Y + 1, Width, Height);
                            break;
                        case 6:
                            SetBounds(Bounds.X - 1, Bounds.Y, Width, Height);
                            break;
                        case 7:
                            SetBounds(Bounds.X - 1, Bounds.Y - 1, Width, Height);
                            break;

                    }
                } while (!HuboChoque());

                if (Bounds.X >= LimiteDerecha)
                    SetBounds(Bounds.X - 1,Bounds.Y,Width,Height);
                else if(Bounds.X<=LimiteIzquierda)
                    SetBounds(Bounds.X + 1, Bounds.Y, Width, Height);
                else if (Bounds.Y <= LimiteArriba)
                    SetBounds(Bounds.X, Bounds.Y+1, Width, Height);
                else if (Bounds.Y >= LimiteAbajo)
                    SetBounds(Bounds.X, Bounds.Y-1, Width, Height);

            }
                  
        }
        public enum Direccion
        {
            Norte = 0,
            Noreste = 1,
            Este = 2,
            Sureste = 3,
            Sur = 4,
            Suroeste = 5,
            Oeste = 6,
            Noroeste = 7
                

        }
  
    }
}
