using System;
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
    public partial class Form1 : Form
    {
        Timer timer;
        int LimiteDerecha;
        int LimiteIzquierda;
        int LimiteArriba;
        int LimiteAbajo;
        int HeightButton;
        int WidthButton;

    

        bool started = false;
        Random GRandom;
        Dictionary<int, CrazyButton> CButtons;
        public Form1()
        {
            
            InitializeComponent();
            DefinirLimites();
            timer = new Timer();
            timer.Tick += Form1_TimerTick;
            timer.Start();
            CButtons = new Dictionary<int, CrazyButton>();
           
        }



        void AgregarComponentesIniciales()
        {
            CButtons.Add(0, new CrazyButton(TypeB.Impar));
            System.Threading.Thread.Sleep(10);

            CButtons.Add(1, new CrazyButton(TypeB.Impar));
            System.Threading.Thread.Sleep(10);

            CButtons.Add(2, new CrazyButton(TypeB.Par));
            System.Threading.Thread.Sleep(10);

            CButtons.Add(3, new CrazyButton(TypeB.Par));

            for (int i = 0; i < 4; i++)
                Controls.Add(CButtons[i]);
                
            
            


        }
        void DefinirLimites()
        {
            HeightButton = 20;
            WidthButton = 30;
            CrazyButton.LimiteDerecha = LimiteDerecha = ClientSize.Width -WidthButton;
            CrazyButton.LimiteIzquierda = LimiteIzquierda = 0;
            CrazyButton.LimiteArriba = LimiteArriba = 0;
            CrazyButton.LimiteAbajo = LimiteAbajo = ClientSize.Height - HeightButton;

        }

        private void Form1_TimerTick(Object sender, EventArgs e)
        {
            /////Espera a que  el designer del form inicialice el contenedor de controles/////
            ////              y crea los primeros cuatro componentes                     ////
            //////////////////////////////////////////////////////////////////////////////////
            if (Controls == null)
                return;
            if (Controls.Count < 1) AgregarComponentesIniciales();
            //////////////////////////////////////////////////////////////////////////////////





        }

        private void Form1_ResizeEnd(Object sender, EventArgs e)
        {
            DefinirLimites();
        }


    }
    
}
