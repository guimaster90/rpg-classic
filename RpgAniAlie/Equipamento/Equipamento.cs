using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Equipamento
{
    abstract class  Equipamento 
    {
        public string NomeDoItem { get; set; }
        public int DefesaDoItem { get; set; }
        public int AtaqueItem { get; set; }
        public int VeloAtaqueDoItem { get; set; }
    }
}
