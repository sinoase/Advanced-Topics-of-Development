using System.Drawing;

namespace Practica4Final
{
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
public class Ubicacion
{
    public int X { get; set; }
    public int Y { get; set; }
    int ButtonWidth, ButtonHeight;
    public Point EsquinaSupDerecha ;
    public Point EsquinaSupIzquierda;
    public Point EsquinaInfDerecha;
    public Point EsquinaInfIzquierda;
    public Point[] Esquinas;

    public Ubicacion(int x, int y, int buttonWidth, int buttonHeight)
    {
        X = x; Y = y;
        ButtonWidth = buttonWidth;
        ButtonHeight = buttonHeight;

        EsquinaSupIzquierda = new Point(X, Y);
        EsquinaSupDerecha = new Point(X += ButtonWidth, Y);
        EsquinaInfIzquierda = new Point(X, Y += ButtonHeight);
        EsquinaInfDerecha = new Point(X += ButtonWidth, Y += ButtonHeight);

        Esquinas = new Point[4];
        Esquinas[0] = EsquinaSupIzquierda;
        Esquinas[1] = EsquinaSupDerecha;
        Esquinas[2] = EsquinaInfDerecha;
        Esquinas[3] = EsquinaInfIzquierda;

        
    }
    public void Refresh()
    {

        EsquinaSupIzquierda.X = X;
        EsquinaSupIzquierda.Y = Y;

        EsquinaSupDerecha.X = X += ButtonWidth;
        EsquinaSupDerecha.Y = Y;

        EsquinaInfIzquierda.X = X;
        EsquinaInfIzquierda.Y = Y += ButtonHeight;

        EsquinaInfDerecha.X = X += ButtonWidth;
        EsquinaInfDerecha.Y = Y += ButtonHeight;

       
    }
}