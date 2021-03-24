using System;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Practica4
{ 
    public partial class CrazyButton : Button
    {
        public static int LimiteDerecha;
        public static int LimiteIzquierda;
        public static int LimiteArriba;
        public static int LimiteAbajo;
       
        protected override Size DefaultSize => new Size(50, 20);
        TypeB Tipo;

        System.Windows.Forms.Timer timer;
        Random GRandom;
        int Value;

        Point EsquinaSupDerecha;
        Point EsquinaSupIzquierda;
        Point EsquinaInfDerecha;
        Point EsquinaInfIzquierda;
        Point[] Esquinas;



        Direcciones DireccionActual;
        

        public CrazyButton(TypeB tipo)
        {
            GRandom = new Random();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Tick;
            timer.Interval = 100;
            timer.Start();
            
            Tipo = tipo;
            CalcularValor();
            Text = Value.ToString();

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

        }
 
        private void Tick(object sender, EventArgs e)
        {

            Avanzar();
        }
        
        enum Direcciones
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
    public enum TypeB
    {
        Par, Impar
    }

}
