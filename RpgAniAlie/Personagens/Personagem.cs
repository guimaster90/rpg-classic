using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie
{
    public abstract class Personagem
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Sorte { get; set; }
        public int Velo { get; set; }
        public int Nivel { get; set; }
        public string SpriteDeBatalha { get; set; }
        public bool PegandoFogo { get; set; }
        public bool Envenenado { get; set; }
        public bool Sangrando { get; set; }
        
        /// <summary>
        /// Irá calcular quando de dano o personagem irá sofrer
        /// </summary>
        /// <param name="AtaAtak">Ira receber o atk do atacante</param>
        /// <param name="VeloAtk">Ira receber a velocidade do atacante</param>
        /// <param name="AtaCrit">Ira receber o critico do atacante</param>
        /// <returns></returns>
        abstract public int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit);

        /// <summary>
        /// Irá se o personagem causou um dano
        /// </summary>
        /// <returns></returns>
        abstract public bool Critico();

        
        abstract public int AtaqueEspecial();

        /// <summary>
        /// Irá  o calculo da defesa do personagem
        /// </summary>
        /// <param name="VeloAtk">Ira receber a velocidade do atacante</param>
        /// <returns></returns>
        abstract public int Defender(int AtaAtak);

        /// <summary>
        /// Irá verificar se o personagem esquivou ou não 
        /// </summary>
        /// <param name="VeloAtk">Ira receber a velocidade do atacante</param>
        /// <returns></returns>
        abstract public bool Esquivar(int VeloAtk);

        /// <summary>
        /// Irá dimunuir da vida o dano levado pelo personagem
        /// </summary>
        /// <param name="AtaAtak">Ira receber o atk do atacante</param>
        /// <param name="VeloAtk">Ira receber a velocidade do atacante</param>
        /// <param name="AtaCrit">Ira receber o critico do atacante</param>
        public void ReceberDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
            this.Vida -= this.CalcularDano(AtaAtak,  VeloAtk,  AtaCrit);
        }

        
    }
}
