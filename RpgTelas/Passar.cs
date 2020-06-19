using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgAniAlieLib;
using RpgAniAlieLib.Personagens;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace RpgTelas
{
    public class Passar
    {
        Macaco m = null;
        Capivara ca = null;
        Cobra co = null;
        MediaPlayer t = null;
        public char QualInimigo { get; set; }
        public void DefinirCaco(Macaco m1)
        {
            m = m1;
        }
        public void DefinirCapi(Capivara c1)
        {
            ca = c1;
        }

        public void DefinirCobra(Cobra c1)
        {
            co = c1;
        }

        public void DefinirTocador(MediaPlayer t1)
        {
            t = t1;
        }

        public Macaco RetornaCaco()
        {
            return m;
        }
        public Capivara RetornaCapi()
        {
            return ca;
        }
        public Cobra RetornaCo()
        {
            return co;
        }

        public MediaPlayer RetornaTocador()
        {
            return t;
        }
    }
}
