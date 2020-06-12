using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
    public class Capivara : Aliados
    {
        public Capivara(string sprite, string nome) : base(sprite, nome)
        {

        }
        public  void ReceberStamina()
        {
            if (MedidorEspecial < 10) { 
            this.MedidorEspecial++;
            }
         
        }

        public override int AtaqueEspecial()
        {
            if (this.MedidorEspecial >= 5)
            {
                this.MedidorEspecial-=5;
                int aux = this.Nivel * 5;
                return (this.Atk += aux);
            }
            else
            {
                return 0;
            }
        }

    }
}
