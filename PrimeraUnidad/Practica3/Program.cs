using System;
using System.Windows.Forms;
using System.Threading;

using System.Collections.Generic;
using System.Drawing;
namespace Practica3
{
    class Program
    {
        Form form1;
        Button butPrincipal;
        Dictionary<TipoComponente, Control> Controls;
        List<Control> ControlesActivos;
        int[] distanciaRecorrida;
        int[] distancia;
        int[] Speed;
        bool[] recorridoFinalizado;
        int LimiteDerecha, LimiteIzquierda;
        int LimiteArriba, LimiteAbajo;



        Direcciones[] direccion;
        Random r;
        static void Main(string[] args)
        {
            Program p = new Program();
            Thread t1 = new Thread(p.CreateForm);
            t1.Start();
            Thread.Sleep(500);
            /////////////////

            p.Go();

        }

        public Program()
        {
            Controls = new Dictionary<TipoComponente, Control>();
            ControlesActivos = new List<Control>();
            distancia = new int[19];
            distanciaRecorrida = new int[19];
            recorridoFinalizado = new bool[19];
            Speed = new int[19];
            direccion = new Direcciones[19];

            
            for (int i = 0; i < 19; i++)
            {
                distanciaRecorrida[i] = 0;
                recorridoFinalizado[i] = true;
            }

            r = new Random();
        }
        void CreateForm()
        {


            form1 = new Form();
            form1.SetBounds(500, 500, 600, 600);
            butPrincipal = new Button();
            butPrincipal.SetBounds((form1.Width / 2) - 50, (form1.Height / 2) - 40, 100, 50);
            butPrincipal.Visible = true;
            butPrincipal.Text = "Adios";
            butPrincipal.BackColor = Color.Green;
            butPrincipal.ForeColor = Color.Cyan;

            LimiteDerecha = form1.Width - 115;
            LimiteIzquierda = 0;
            LimiteArriba = 0;
            LimiteAbajo = form1.Height - 89;


            Agregar(butPrincipal);

            Application.EnableVisualStyles();//Hace que se vea más chido
            Application.Run(form1);
           
        }


        delegate void AddComponents(Control control);
        void Agregar(Control control)
        {
            if (form1.InvokeRequired) 
            {
              
                AddComponents delegado = new AddComponents(Agregar);
               
                object[] parametros = new object[] { control };
          
                form1.Invoke(delegado, parametros);
            }
            else
            {
       
                form1.Controls.Add(control);
            }

        }
        void Go()
        {
            Controls.Add(TipoComponente.ButtonPrincipal, butPrincipal);
            ControlesActivos.Add(butPrincipal);

            while (true)
            {
                
      
                for(int i=0;i<19;i++)
                {
                    if (Controls.ContainsKey((TipoComponente)i))
                    {
                        if (ControlesActivos.Contains(Controls[(TipoComponente)i]))
                        {
                            setPosition(Controls[(TipoComponente)i], (TipoComponente)i);
                        }
                    }
                }
              
            }



        }
       
        void setPosition(Control component, TipoComponente tipo)
        {
          
           
                int id = (int)tipo;
                bool HuboColisionArriba = false;
                bool HuboColisionAbajo = false;
                bool HuboColisionDer = false;
                bool HuboColisionIzq = false;


                if (recorridoFinalizado[id])
                {
                    recorridoFinalizado[id] = false;
                    
                    distanciaRecorrida[id] = 0;
                    
                    if (r.Next(0,2)==0) distancia[id] = r.Next(500, 1000);
                    else distancia[id] = r.Next(100, 500);
                    direccion[id] = (Direcciones)r.Next(0, 8);


                }
                Thread.Sleep(Speed[id]);
                if (distanciaRecorrida[id] < distancia[id])
                {

                    switch ((int)direccion[id])
                    {
                        case 0:
                            component.SetBounds(component.Bounds.X, component.Bounds.Y - 1, component.Width, component.Height);
                            break;
                        case 1:
                            component.SetBounds(component.Bounds.X + 1, component.Bounds.Y - 1, component.Width, component.Height);
                            break;
                        case 2:
                            component.SetBounds(component.Bounds.X + 1, component.Bounds.Y, component.Width, component.Height);
                            break;
                        case 3:
                            component.SetBounds(component.Bounds.X + 1, component.Bounds.Y + 1, component.Width, component.Height);
                            break;
                        case 4:
                            component.SetBounds(component.Bounds.X, component.Bounds.Y + 1, component.Width, component.Height);
                            break;
                        case 5:
                            component.SetBounds(component.Bounds.X - 1, component.Bounds.Y + 1, component.Width, component.Height);
                            break;
                        case 6:
                            component.SetBounds(component.Bounds.X - 1, component.Bounds.Y, component.Width, component.Height);
                            break;
                        case 7:
                            component.SetBounds(component.Bounds.X - 1, component.Bounds.Y - 1, component.Width, component.Height);
                            break;

                    }
                    distanciaRecorrida[id]++;
                }
                else recorridoFinalizado[id] = true;

                if (component.Bounds.X >= LimiteDerecha)
                {
                    component.SetBounds(component.Bounds.X - 1, component.Bounds.Y, component.Width, component.Height);
                    recorridoFinalizado[id] = true;
                    HuboColisionDer = true;
                }
                else if (component.Bounds.X <= LimiteIzquierda)
                {
                    component.SetBounds(component.Bounds.X + 1, component.Bounds.Y, component.Width, component.Height);
                    recorridoFinalizado[id] = true;
                    HuboColisionIzq = true;
                }
                else if (component.Bounds.Y <= LimiteArriba)
                {
                    component.SetBounds(component.Bounds.X, component.Bounds.Y + 1, component.Width, component.Height);
                    recorridoFinalizado[id] = true;
                    HuboColisionArriba = true;
                }
                else if (component.Bounds.Y >= LimiteAbajo)
                {
                    component.SetBounds(component.Bounds.X, component.Bounds.Y - 1, component.Width, component.Height);
                    recorridoFinalizado[id] = true;
                    HuboColisionAbajo = true;
                }

                if (tipo == TipoComponente.ButtonPrincipal)
                {
                    if (HuboColisionArriba || EsquinaSupDer(component) )
                        Emojis(component);
                    if (HuboColisionAbajo||EsquinaInfDer(component))
                    {

                    Nombres(component);
                       
                    }
                    
                    if(HuboColisionIzq)
                    {
                    for(int i=1;i<19;i++)
                    {
                        if (Controls.ContainsKey((TipoComponente)i))
                            Controls[(TipoComponente)i].Visible=false;
                        else continue;

                        ControlesActivos.Remove(Controls[(TipoComponente)i]);
                    }
                        
                    }
                
                    if(HuboColisionDer&&!EsquinaInfDer(component)&&!EsquinaSupDer(component))
                    {
                        form1.BackColor = Color.Orange;
                        Button[] buttons = new Button[5];
                    int x = 300, y = 0;
                    int R = 0, G = 0, B = 0;
                    if (!Controls.ContainsKey(TipoComponente.Button1))
                        for (int i = 4; i < 9; i++)
                        {
                            buttons[i - 4] = new Button();
                            buttons[i - 4].SetBounds(x, y, 50, 30);
                            buttons[i - 4].Text = (i - 3).ToString();
                            buttons[i - 4].Visible = true;

                            R = r.Next(0, 255);
                            G = r.Next(0, 255);
                            B = r.Next(0, 255);
                            buttons[i - 4].BackColor = Color.FromArgb(R, G, B);
                            ControlesActivos.Add(buttons[i - 4]);
                            Controls.Add((TipoComponente)i, buttons[i - 4]);
                            Agregar(buttons[i - 4]);
                            y += 100;

                        }
                    else
                        for (int i = 4; i < 9; i++)
                        {
                            ControlesActivos.Add(Controls[(TipoComponente)i]);
                            Controls[(TipoComponente)i].Visible = true;
                        }
                            
                    }
                    

                if (HuboColisionArriba && !EsquinaSupDer(component)) form1.BackColor = Color.Yellow;
                if(HuboColisionAbajo&&!EsquinaInfDer(component))form1.BackColor = Color.LightBlue;

                if (ControlesActivos.Count > 1) Speed[id] = 0;
                else Speed[id] = 1;

            }

        }
        void Emojis(Control control)
            {
                if (!EsquinaSupDer(control))
                {
                if (!Controls.ContainsKey((TipoComponente)1))
                {

                    PictureBox[] emojis = new PictureBox[3];
                    string[] paths = new string[3];
                    paths[0] = "sunglasses.png";
                    paths[1] = "sunglasses.png";
                    paths[2] = "sunglasses.png";

                    int x = 200, y = 100;
                    for (int i = 0; i < 3; i++)
                    {
                        emojis[i] = new PictureBox();
                        emojis[i].ImageLocation = paths[i];
                        emojis[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        emojis[i].SetBounds(x, y, 50, 50);
                        emojis[i].Scale(new SizeF(.4f, .4f));
                        emojis[i].Visible = true;
                        ControlesActivos.Add(emojis[i]);
                        Agregar(emojis[i]);
                        y += 100;
                    }
                    try
                    {
                        Controls.Add(TipoComponente.Carita1, emojis[0]);
                        Controls.Add(TipoComponente.Carita2, emojis[1]);
                        Controls.Add(TipoComponente.Carita3, emojis[2]);
                    }
                    catch (Exception)
                    {
                        Controls[TipoComponente.Carita1] = emojis[0];
                        Controls[TipoComponente.Carita2] = emojis[1];
                        Controls[TipoComponente.Carita3] = emojis[2];
                    }
                }
                else
                {
                    for (int i = 1; i < 4; i++)
                    {
                        Controls[(TipoComponente)i].Visible = true;
                        ControlesActivos.Add(Controls[(TipoComponente)i]);
                    }
                }


                   
                }
                else if( EsquinaSupDer(control))
                {
                for (int i = 1; i < 4; i++)
                {
                    if (Controls.ContainsKey((TipoComponente)i))
                        Controls[(TipoComponente)i].Visible = false;
                    else break;

                    ControlesActivos.Remove(Controls[(TipoComponente)i]);



                }
           
                }
                
        }

        void Nombres(Control control)
        {
            if(!EsquinaInfDer(control))
            {
                int x = 0, y = 20;

                Label[] labels = new Label[10];
                if (!Controls.ContainsKey(TipoComponente.Nombre1))
                    for (int i = 9; i < 19; i++)
                    {

                        labels[i - 9] = new Label();
                        labels[i - 9].Text = "Luis Angel Cruz Ruiz";
                        labels[i - 9].SetBounds(x, y, 120, 20);
                        labels[i - 9].Visible = true;
                        Agregar(labels[i - 9]);
                        ControlesActivos.Add(labels[i - 9]);
                        Controls.Add((TipoComponente)i, labels[i - 9]);
                        y += 30;

                    }
                else
                {
                    for (int i = 9; i < 19; i++)
                    {
                        Controls[(TipoComponente)i].Visible = true;
                        ControlesActivos.Add(Controls[(TipoComponente)i]);
                    }
                }
            }
            else
            {
                for (int i = 9; i < 19; i++)
                {
                    if (Controls.ContainsKey((TipoComponente)i))
                        Controls[(TipoComponente)i].Visible = false;
                    else break;
                 
                    ControlesActivos.Remove(Controls[(TipoComponente)i]);
                    


                }
            }
        }

        bool EsquinaSupDer(Control control) => control.Bounds.X > LimiteDerecha - 100 && control.Bounds.Y < LimiteArriba + 100;

        bool EsquinaInfDer(Control control) => control.Bounds.X > LimiteDerecha - 100 && control.Bounds.Y > LimiteAbajo - 100;

        enum TipoComponente
        {
            ButtonPrincipal = 0,
            Carita1 = 1,
            Carita2 = 2,
            Carita3 = 3,

            Button1 = 4,
            Button2 = 5,
            Button3 = 6,
            Button4 = 7,
            Button5 = 8,

            Nombre1=9,
            Nombre2=10,
            Nombre3=11,
            Nombre4=12,
            Nombre5=13,
            Nombre6=14,
            Nombre7=15,
            Nombre8=16,
            Nombre9=17,
            Nombre10=18,


        }

        public enum Direcciones
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
