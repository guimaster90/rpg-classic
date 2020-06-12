using System;
using System.Collections.Generic;
using System.Text;
using RpgAniAlie.Player;

namespace RpgAniAlie.Personagens
{
    public class Macaco : Aliados
    {
        public Macaco(string sprite, string nome) : base(sprite, nome)
        {

        }
        public bool Recarregar()
        {
            if (Inventario.QtdBala > 0 && this.MedidorEspecial == 0)
            {
                while (MedidorEspecial != 3 && Inventario.QtdBala > 0)
                {
                    MedidorEspecial++;
                    Inventario.QtdBala--;
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
            if (this.MedidorEspecial > 0)
            {
                this.MedidorEspecial--;
                int aux = this.Nivel * 5;//Quanto maior o nivel maior é o dano do ataque especial
                return (this.Atk += aux);
            }
            else
            {
                return 0;
            }
        }
    }
}