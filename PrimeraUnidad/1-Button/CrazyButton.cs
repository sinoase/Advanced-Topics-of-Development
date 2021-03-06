
using System.Windows.Forms;
using System.Threading;
namespace _1_Button
{
    class CrazyButton : Button
    {
        //Coordenadas en las que el botón choca con la pared
        int LimiteDerecha, LimiteIzquierda;
        int LimiteArriba, LimiteAbajo;


        public void Init(int width, int height)
        {
            //Coloca el botón más o menos al centro
            SetBounds((width / 2) - 50, (height / 2) - 40, 100, 50);
            Visible = true;
            Text = "Hola";

           
            LimiteDerecha = width - 115;
            LimiteIzquierda = 0;
            LimiteArriba = 0;
            LimiteAbajo = height - 89;

        }
        //Compruba si el botón llegó al tope
        bool HuboChoque() => Bounds.X > LimiteDerecha || Bounds.X < LimiteIzquierda || Bounds.Y < LimiteArriba || Bounds.Y > LimiteAbajo;

        //Dependiendo del parámetro que reciba el botón se moverá en cierta dirección
        public void Go(Direcciones dir,int distancia)
        {
            int i = 0;
            do
            {


                Thread.Sleep(1);
                switch ((int)dir)
                {
                    case 0://0= Norte
                        SetBounds(Bounds.X, Bounds.Y - 1, Width, Height);
                        break;
                    case 1://1=Noreste
                        SetBounds(Bounds.X + 1, Bounds.Y - 1, Width, Height);
                        break;
                    case 2://Etc...
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
                i++;
            } while (!HuboChoque()&&i<distancia);
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
}
