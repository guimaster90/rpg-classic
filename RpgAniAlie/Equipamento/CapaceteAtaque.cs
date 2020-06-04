using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Equipamento
{
    public class CapaceteAtaque : Equip
    {
        public CapaceteAtaque() { 
            this.NomeDoItem = "Capacete da Cabeçada";
            this.DefesaDoItem = 5;
            this.AtaqueItem = 20;
            this.VeloAtaqueDoItem = 5;
        }
    }
}
