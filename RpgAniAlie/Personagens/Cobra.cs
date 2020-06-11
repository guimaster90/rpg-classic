using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    public class Cobra : Aliados
    {
        public bool RecarregarVeneno()
        {
            if(this.MedidorEspecial< 10)
            {
                for(int i=0; i < 2 && this.MedidorEspecial<10 ; i++)
                {
                    MedidorEspecial++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int AtaqueEspecial()
        {
            if (this.MedidorEspecial > 3)
            {
                this.MedidorEspecial -= 5;
                int aux = this.Nivel * 7;
                return (this.Atk += aux);
            }
            else
            {
                return 0;
            }
        }



    }
}
