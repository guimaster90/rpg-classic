using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
   public class Inimigos : Personagem
    {
        /// <summary>
        /// Nome dado ao ataque em estado de furia
        /// </summary>
        public string NomeAtaqueDeFuria { get; set; }

        /// <summary>
        /// tempo até poder usar o ataque de furia denovo
        /// </summary>
        public int CoolDown { get; set; }

        /// <summary>
        /// Nome do tipo de sprite
        /// </summary>
        public string SpriteDeBatalha { get; set; }

        public Inimigos(int nivel,string sprite,string nome)
        {
            this.Nivel = nivel;
            this.SpriteDeBatalha = sprite;
            this.Nome = nome;
            this.Atk = (7 * this.Nivel);
            this.Vida = (7 * this.Nivel);
            this.Velo = (7 * this.Nivel);
            this.Def = (7 * this.Nivel);
            this.Sorte = (7 * this.Nivel);
            this.VidaMax = this.Vida;
        }
     
        
      
        public override int AtaqueEspecial()//Ira causar um dano diferente
        {
            double aux = (double)this.Atk * 1.5;
            return (int)aux;
        }
        
        public override bool Critico()
        {
                
            Random randNum = new Random();
            int x = randNum.Next(0, 100);
            if (x <= this.Sorte){//Irá sortear para checar se o ataque foi critico ou não
               return true;
	        }else{
               return false;
            }
        }


        public override int Defender(int AtaAtak)
        {
            if (this.Def >= AtaAtak)//Se a defesa do defensor for amior do que o ataque do atacante só sera causado 1 de dano
            {
                return 1;

            }
            else return (AtaAtak - this.Def); 

        }

        public override bool Esquivar(int VeloAtk)
        {

            if (this.Velo > VeloAtk)//Verificando se a velociada do atacante é menor do que a sua
            {
                Random randNum = new Random();

                int x = randNum.Next(0, 101);

                if(this.Velo - VeloAtk >= x)//Caso for maior ele irá sortear se o personagem conseguiu esquivar
                {
                    return true;//Conseguiu esquivar
                }
                else
                {
                    return false;//Não conseguiu esquivar
                }
                
            }
            else
            {
                return false;//Conseguiu esquivar
            }
        }

        public override int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
            Random randNum = new Random();
            if (!Esquivar(VeloAtk))//Caso o personagem esquive não recebera dano
            {
                if (AtaCrit)//Caso o atk for critico o personagem recebera o dobro de dano
                {
                    return Defender(AtaAtak) * 2;
                }
                else
                {
                  
                    if(Defender(AtaAtak) == 1)//Caso a defesa for maior do que o ataque ele receberá 1 de dano
  
                        return 1;
                    else
                    {
                        float aux = randNum.Next(84, 121);//O ataque pode variar entre 85% a 120% do atk original

                        aux /= 100;

                        aux = (float)Defender(AtaAtak) * aux;
                        return (int)aux;
                    }
                   
                }
            }
            else
            {
                return 0;
                    
            }

        }

        public virtual int Ataques()//quando o inimigo ficar com metade da vida vai dar um ataque especial e quando ele não tiver mais vida vai retorna -1;
        {//enquanto estiver com a vida acima de 50% dará um ataque normal
             int aux = this.VidaMax;
            int aux2 = aux / 2;
            if (this.Vida > 0)
            {
                if (this.Vida > aux2)
                {
                    return this.Atk;
                }
                else
                {
                    return (AtaqueEspecial());
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
