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
        public int AtaqueNervoso()//aumenta o dano do ataque em 20 porcento
        {
            double aux = (double)this.Atk * 1.2;
            return (int)aux;
        }
        public override int Ataques()//Quanto mais baixo a vida do boss mais dano ele da,sendo que abaixo de 60 % de vida e acima de 30% da 20% amais de dano e quando está com menos de 30% aumenta o dano em 50%
        {//se o boss perde toda a vida ele retorna -1
            double aux = this.VidaMax / 100;
            double aux2 = aux * 60 ;
            double aux3 = aux * 30;
            if (this.Vida > 0)
            {
                if (this.Vida > aux2)
                {
                    return this.Atk;
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
