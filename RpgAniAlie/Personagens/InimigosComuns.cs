using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    class InimigosComuns : Inimigos
    {
        public void AtaqueInimigoComum()
        {
            int aux = this.Vida;
            int aux2 = aux / 2;
            while (this.Vida > 0)
            {
                if (this.Vida > aux2)
                {
                    Ataque();
                }
                else
                {
                    AtaqueDeFuria(); // mexer depois de implementar o sistema de turnos
                }
            }
        }
    }
}