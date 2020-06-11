using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
     public class InimigoComum : Inimigos
    {

        public override int Ataques()
        {
            int aux = this.Vida;
            int aux2 = aux / 2;
            if (this.Vida > 0)
            {
                if (this.Vida > aux2)
                {
                    return (Ataque());
                }
                else
                {
                    return (AtaqueDeFuria()); // mexer depois de implementar o sistema de turnos
                }
            }
            else
            {
                return -1;
            }
        }
    }
}