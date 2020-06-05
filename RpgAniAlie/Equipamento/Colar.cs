using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Equipamento
{
    public class Colar : Equip
    {
        public int Sorte { get; set; }

     
        public Colar(){
            this.AtaqueItem = 0;
            this.VeloAtaqueDoItem = 0;
            this.DefesaDoItem = 0;
            }
            
        
    }
}
