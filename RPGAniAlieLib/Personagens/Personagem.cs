using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlieLib
{
    public abstract class Personagem
    {
        public string Nome { get; set; }
        /// <summary>
        /// Vida atual do personagem
        /// </summary>
        public int Vida { get; set; }
        /// <summary>
        /// Sera a vida Mx do personagem
        /// </summary>
        public int VidaMax { get; set; }
        /// <summary>
        /// Ataque atual do personagem
        /// </summary>
        public int Atk { get; set; }
        /// <summary>
        /// Defesa atual do personagem
        /// </summary>
        public int Def { get; set; }
        /// <summary>
        /// Sorte atual do personagem
        /// </summary>
        public int Sorte { get; set; }
        /// <summary>
        /// Velocidade atual do personagem
        /// </summary>
        public int Velo { get; set; }
        /// <summary>
        /// Nivel atual do personagem
        /// </summary>
        public int Nivel { get; set; }
        
     
        /// <summary>
        /// Irá calcular quando de dano o personagem irá sofrer
        /// </summary>
        /// <param name="AtaAtak">Ira receber o atk do atacante</param>
        /// <param name="VeloAtk">Ira receber a velocidade do atacante</param>
        /// <param name="AtaCrit">Ira receber o critico do atacante</param>
        /// <returns></returns>
        abstract public int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit);

        /// <summary>
        /// Ira sortear de o atk foi critico ou não
        /// </summary>
        /// <returns></returns>
        abstract public bool Critico();

        /// <summary>
        /// Ira realizar um ataque com um dano diferente 
        /// </summary>
        /// <returns></returns>
        abstract public int AtaqueEspecial();

        /// <summary>
        /// Irá  o calculo da defesa do personagem
        /// </summary>
        /// <param name="VeloAtk">Ira receber a velocidade do atacante</param>
        /// <returns></returns>
        abstract public int Defender(int AtaAtak);

        /// <summary>
        /// Irá verificar se o personagem esquivou ou não caso esquevi não recebera dano
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
        public int ReceberDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
           int aux = this.CalcularDano(AtaAtak, VeloAtk, AtaCrit);
            this.Vida -= aux;
            if(this.Vida < 0 )
            {
                this.Vida = 0;
            }
            return aux;
        }

        
    }
}
