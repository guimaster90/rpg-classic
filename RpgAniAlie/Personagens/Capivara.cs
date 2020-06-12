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
        public  void ReceberStamina()//A cada ataque a capivara irá recuperar 1 do MedidorEspecial
        {
            if (MedidorEspecial < 10) { 
            this.MedidorEspecial++;
            }
         
        }

        public override int AtaqueEspecial()//Quando tiver mais de 5 de MedidorEspecial a capivara pode usar um ataque especial gastando 5 de medidor especial
        {
            if (this.MedidorEspecial >= 5)
            {
                this.MedidorEspecial-=5;
                int aux = this.Nivel * 6;//Quanto maior o nivel maior é o dano do ataque especial
                return (this.Atk += aux);
            }
            else
            {
                return 0;
            }
        }

    }
}
