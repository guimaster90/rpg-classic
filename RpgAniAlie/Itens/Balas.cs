using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Itens
{
    class Balas//munição
    {

        public int DanoExtra { get; set; }

        public Balas()
        {//pode sofrer modificação dependendo de uma mecanica ainda sendo discutida
            this.DanoExtra = 20;
        }
    }
}

