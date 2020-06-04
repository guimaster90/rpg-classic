using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace RpgTelas.Classes
{
    
    class Escala
    {
        public double Largura = ApplicationView.GetForCurrentView().VisibleBounds.Width;
        public double Altura = ApplicationView.GetForCurrentView().VisibleBounds.Height;
        public float escalaLargura, escalaAltura;

    }
}
