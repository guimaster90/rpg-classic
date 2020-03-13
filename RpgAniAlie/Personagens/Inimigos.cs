using System;
using System.Collections.Generic;
using System.Text;

namespace RpgAniAlie.Personagens
{
   public class Inimigos : Personagem
    {
        
        public void AtaqueDeFuria()
        {

        }

        public override bool Critico()
        {
                
            Random randNum = new Random();
            int x = randNum.Next(0, 100);
            if (x <= this.Sorte){
               return true;
	        }else{
               return false;
            }
        }

        
        public override int Defender(int AtaAtak)
        {
            if (this.Def >= AtaAtak)
            {
                return 1;

            }
            else return (AtaAtak - this.Def); 

        }

        public override bool Esquivar(int VeloAtk)
        {

            if (this.Velo > VeloAtk)
            {
                Random randNum = new Random();

                int x = randNum.Next(0, 101);

                if(this.Velo - VeloAtk >= x)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }

        public override int CalcularDano(int AtaAtak, int VeloAtk, Boolean AtaCrit)
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 101);
            if (!Esquivar(VeloAtk))
            {
                if (AtaCrit)
                {
                    return Defender(AtaAtak) * 2;
                }
                else
                {
                    float aux = randNum.Next(84, 121);

                    aux /= 100;

                    aux = (float)Defender(AtaAtak) * aux;
                    if(Defender(AtaAtak) == 1)
  
                        return 1;
                    else
                   return (int)aux; 
                }
            }
            else
            {
                return 0;
                    
            }

        }
    }
}
