
using System.Windows.Forms;
using System.Threading;
using System;
namespace _1_Button
{
    class CrazyButton : Button
    {
        int LimiteDerecha, LimiteIzquierda;
        int LimiteArriba, LimiteAbajo;
        public int Speed ;
        Random r = new Random();

        public void Init(int width, int height)
        {
            SetBounds((width / 2) - 50, (height / 2) - 40, 100, 50);
            Visible = true;
            Text = "Hola";
            Speed = 1;
         
            LimiteDerecha = width - 115;
            LimiteIzquierda = 0;
            LimiteArriba = 0;
            LimiteAbajo = height - 89;
        

        }
        bool HuboChoque() => Bounds.X > LimiteDerecha || Bounds.X < LimiteIzquierda || Bounds.Y < LimiteArriba || Bounds.Y > LimiteAbajo;

        public void Go()
        {
            while (true)
            {
                int distancia;
               
                Speed = new Random().Next(0, 2);

                if (Speed == 0) distancia = r.Next(150, 400); 
                else distancia = r.Next(30,100);
                Direcciones dir = (Direcciones)r.Next(0, 8);
                
                int pixelesRecorridos = 0;
                do
                {


                    Thread.Sleep(Speed);

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
                            SetBounds(Bounds.X, Bounds.Y + 1, Width, Height);
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

                    pixelesRecorridos++;
                } while (!HuboChoque() && pixelesRecorridos < distancia);
                //Para que el botón no se quede trabado: 
                if (Bounds.X >= LimiteDerecha)
                    SetBounds(Bounds.X - 1, Bounds.Y, Width, Height);
                else if (Bounds.X <= LimiteIzquierda)
                    SetBounds(Bounds.X + 1, Bounds.Y, Width, Height);
                else if (Bounds.Y <= LimiteArriba)
                    SetBounds(Bounds.X, Bounds.Y + 1, Width, Height);
                else if (Bounds.Y >= LimiteAbajo)
                    SetBounds(Bounds.X, Bounds.Y - 1, Width, Height);

            }
        }
        public void Teletransportación()
        {
            int x = r.Next(LimiteIzquierda, LimiteDerecha);
            int y = r.Next(LimiteArriba, LimiteAbajo);
            SetBounds(x, y, Bounds.Width, Bounds.Height);
        }
        
            
        

    }
}
