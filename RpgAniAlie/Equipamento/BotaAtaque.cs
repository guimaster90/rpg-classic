using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Equipamento
{
    public class BotaAtaque : Equip
    {

        public BotaAtaque()
        {
            this.NomeDoItem = "Bota da Rasteira";
            this.DefesaDoItem = 5;
            this.AtaqueItem = 20;
            this.VeloAtaqueDoItem = 5;
        }
    }
}