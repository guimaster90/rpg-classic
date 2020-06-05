using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    class Boss : Inimigos
    {
        private int AtaqueNervoso()
        {
            double aux = (double)this.Atk * 1.2;
            return (int)aux;
        }
        public void VidaBoss()
        {
            double aux = this.Vida / 100;
            double aux2 = aux * 60 ;
            double aux3 = aux * 30;
            while(this.Vida > 0)
            {
                if (this.Vida > aux2)
                {
                    Ataque();
                }else if(this.Vida<aux2 && this.Vida > aux3)
                {
                    AtaqueNervoso();
                }else if (this.Vida < aux3)
                {
                    AtaqueDeFuria();
                }

            }

        }


    }
}
