using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    public class Boss : Inimigos
    {
        public Boss(int nivel, string sprite, string nome) : base(nivel,sprite,nome)
        {
        }
        public int AtaqueNervoso()
        {
            double aux = (double)this.Atk * 1.2;
            return (int)aux;
        }
        public override int Ataques()
        {
            double aux = this.VidaMax / 100;
            double aux2 = aux * 60 ;
            double aux3 = aux * 30;
            if (this.Vida > 0)
            {
                if (this.Vida > aux2)
                {
                    return(Ataque());
                }
                else if (this.Vida < aux2 && this.Vida > aux3)
                {
                    return(AtaqueNervoso());
                }
                else
                {
                    return(AtaqueEspecial());
                }

            }
            else
            {
                return -1;
            }
        }


    }
}
