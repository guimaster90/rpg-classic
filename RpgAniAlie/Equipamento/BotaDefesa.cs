using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Equipamento
{
    public class BotaDefesa : Equip
    {

        public BotaDefesa()
        {
            this.NomeDoItem = "Bota Blindão";
            this.DefesaDoItem = 20;
            this.AtaqueItem = 5;
            this.VeloAtaqueDoItem = 5;
        }
    }
}