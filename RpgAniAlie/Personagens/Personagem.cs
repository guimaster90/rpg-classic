using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie
{
    abstract class Personagem
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Sorte { get; set; }
        public int Velo { get; set; }
        public int Nivel { get; set; }
        public bool Critico{get;set;}

        /// <summary>
        /// Irá calcular quando de dano o personagem irá sofrer
        /// </summary>
        abstract public int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit);

        /// <summary>
        /// Irá calcular a chance de critico do personagem
        /// </summary>
        /// <returns></returns>
        abstract public bool ChecarCritico();

        /// <summary>
        /// Irá realizar o ataque basico do personagem
        /// </summary>
        /// <returns></returns>
        abstract public int Atacar();

        /// <summary>
        /// Irá  o calculo da defesa do personagem
        /// </summary>
        /// <param name="VeloAtk"></param>
        /// <returns></returns>
        abstract public int Defender(int AtaAtak);

        /// <summary>
        ///Irá verificar se o personagem esquivou ou não 
        /// </summary>
        /// <returns></returns>
        abstract public int Esquivar(int VeloAtk);

         public void ReceberDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
            this.Vida -= this.CalcularDano(AtaAtak,  VeloAtk,  AtaCrit);
        }

    }
}
