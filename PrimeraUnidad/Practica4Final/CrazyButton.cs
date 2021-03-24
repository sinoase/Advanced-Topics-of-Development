using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica4Final
{
    public partial class CrazyButton : Button
    {
        public static int LimiteDerecha;
        public static int LimiteIzquierda;
        public static int LimiteArriba;
        public static int LimiteAbajo;

        public static int ContadorBotones = 0;

        int ID;
        int Speed;
        int DistanciaRecorrida;
        bool RecorridoFinalizado;
        bool HuboChoque;
        int Distancia;
        int Value;

        protected override Size DefaultSize => new Size(30, 20);

        TypeB Tipo;

        Timer timer;


        Ubicacion BUbicacion;
        static IDictionary <int,Ubicacion> BUbicaciones;

        Random GRandom;

        Direcciones DireccionActual;

       static CrazyButton()
        {
            BUbicaciones = new Dictionary<int, Ubicacion>();
        }

        public CrazyButton(TypeB tipo)
        {
            GRandom = new Random();
            Speed = 3;
            SetBounds(200, 200, Width, Height);
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Tick;
            timer.Interval = 3;
            timer.Start();

            Tipo = tipo;
            CalcularValor();
            BUbicacion = new Ubicacion(Bounds.X,Bounds.Y,Width,Height);
            Text = Value.ToString();
            RecorridoFinalizado = true;

            ID = ContadorBotones;
            BUbicaciones.Add(ID,BUbicacion);
            ContadorBotones++;
        }



        void CalcularValor()
        {
            int n = GRandom.Next(0, 11);
            if (Tipo == TypeB.Par) while (n % 2 != 0) n = GRandom.Next(0, 11);

            else while (n % 2 == 0) n = GRandom.Next(0, 11);

            Value = n;
        }


       

        void Avanzar()
        {

            Point nuevaPos = new Point(Bounds.X + 1, Bounds.Y);
            switch ((int)DireccionActual)
            {
                case 0:  nuevaPos.Y += Speed;   break;

                case 1:  nuevaPos.X += Speed; nuevaPos.Y -= Speed;  break;
                                      
                case 2:  nuevaPos.X += 1;break;
                                      
                case 3:  nuevaPos.X += Speed; nuevaPos.Y += Speed;  break;
                                      
                case 4:  nuevaPos.Y += Speed; break;

                case 5:  nuevaPos.X -= Speed; nuevaPos.Y += Speed;  break;

                case 6:  nuevaPos.X -= Speed; break;

                case 7:  nuevaPos.X -= Speed; nuevaPos.Y -= Speed;  break;

            }
            SetBounds(nuevaPos.X, nuevaPos.Y, Width, Height);
            BUbicacion.X = nuevaPos.X;
            BUbicacion.Y = nuevaPos.Y;
            BUbicacion.Refresh();
            DistanciaRecorrida++;
            //Para que el botón no se quede trabado: 
            if (Bounds.X >= LimiteDerecha)
            {
                nuevaPos.X -= Speed;
                HuboChoque = true;
            }
            else if (Bounds.X <= LimiteIzquierda)
            {
                nuevaPos.X += Speed;
                HuboChoque = true;
            }
            else if (Bounds.Y <= LimiteArriba)
            {
                nuevaPos.Y += Speed;
                HuboChoque = true;

            }
            else if (Bounds.Y >= LimiteAbajo)
            {
                nuevaPos.Y -= Speed;
                HuboChoque = true;
            }
            SetBounds(nuevaPos.X, nuevaPos.Y, Width, Height);

        }
        void ReiniciarAvance()
        {
            
            DireccionActual = (Direcciones)GRandom.Next(0, 8);
            Distancia = GRandom.Next(50, LimiteDerecha);
            DistanciaRecorrida = 0;
            HuboChoque = false;
            RecorridoFinalizado = false;

        }
        Ubicacion ComprobarColision()
        {
            for(int i=0;i<BUbicaciones.Count;i++)
            {
                if (i == ID) continue;

                if (Math.Abs(BUbicacion.EsquinaSupIzquierda.X - BUbicaciones[i].EsquinaSupDerecha.X) <= 3)
                    if (Math.Abs(BUbicacion.EsquinaSupIzquierda.Y - BUbicaciones[i].EsquinaSupDerecha.Y) <= 20)
                    {
                        //Console.WriteLine("Button {0}: Colision",i);
                        return BUbicaciones[i];
                    }
                
            }
            return null;

        }
        private void Tick(object sender, EventArgs e)
        {
            if (RecorridoFinalizado || HuboChoque)
                ReiniciarAvance();
            Avanzar();
            ComprobarColision();
            if (Distancia <= DistanciaRecorrida) RecorridoFinalizado = true;
 
        }

       

    }
}