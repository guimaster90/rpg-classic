using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Equipamento
{
    public class BotaBasico : Equip
    {

        public BotaBasico()
        {
            this.NomeDoItem = "Bota Lixo";
            this.DefesaDoItem = 5;
            this.AtaqueItem = 5;
            this.VeloAtaqueDoItem = 5;
        }
    }
}