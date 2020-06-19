using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlieLib.Personagens
{
    public class Cobra : Aliados
    {
        public Cobra(string sprite, string nome) : base(sprite, nome)
        {

        }
        public bool RecarregarVeneno()//Ao acabar uma batalha a função será chamada e a cobra irá recuperar 2 de seu medidor especial
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

        public override int AtaqueEspecial()//Qaundo a cobra tiver 3 ou mais de medidor de Especial,ela podera gastar 3 medidores para utilizar um ataque especial
        {
            if (this.MedidorEspecial >= 3)
            {
                this.MedidorEspecial -= 3;
                int aux = this.Nivel * 7;//Quanto maior o nivel maior é o dano do ataque especial
                return (this.Atk + aux);
            }
            else
            {
                return 0;
            }
        }



    }
}
