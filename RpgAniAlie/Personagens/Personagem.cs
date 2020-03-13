﻿using System;
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

        /// <summary>
        /// Irá calcular quando de dano o personagem irá sofrer
        /// </summary>
        abstract public int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit);

        /// <summary>
        /// Irá se o personagem causou um dano
        /// </summary>
        /// <returns></returns>
        abstract public bool Critico();



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
        abstract public bool Esquivar(int VeloAtk);

        /// <summary>
        /// Irá dimunuir da vida o dano levado pelo personagem
        /// </summary>
        /// <param name="AtaAtak"></param>
        /// <param name="VeloAtk"></param>
        /// <param name="AtaCrit"></param>
         public void ReceberDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
            this.Vida -= this.CalcularDano(AtaAtak,  VeloAtk,  AtaCrit);
        }

    }
}
