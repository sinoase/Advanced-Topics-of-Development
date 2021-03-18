using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PracticaFinal
{
    class CrazyControl : Control
    {

        public CrazyControl(int x,int y, int w, int h)
        {
            SetBounds(x, y, w, h);
            
        }
      
    
     }
    enum TipoComponente { Button, BitMap }
}
    


