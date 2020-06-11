using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RpgAniAlie.Equipamento;
using RpgAniAlie.Player;

namespace RpgAniAlie.Personagens
{
    public class Aliados : Personagem
    {
        public Aliados(){
            this.Nivel = 0;
        }
        public int MedidorEspecial { get; set; }
        public int XP { get; set; }
        public double XPProxNlv { get; set; }

        public void GanharXP(int xp)
        {
            this.XP += xp;
            if(this.XP >= this.XPProxNlv)
            {
                this.XPProxNlv *= 1.5;
                this.Nivel++;
            }
        }
        
        public void UparStatus()
        {
            this.Vida *= this.Nivel;
            this.Def *= this.Nivel;
            this.Atk *= this.Nivel;
            this.Velo *= this.Nivel;
            this.Sorte += this.Nivel;
        }
        public int VidaTotal()
        {
            int aux = (Capacete.VidaDoItem * Inventario.NlvArmadura);
            return (aux + this.Vida);
        }
        public int DefesaTotal()
        {
           int aux = (Peitoral.DefesaDoItem * Inventario.NlvArmadura);
            return (aux + this.Def);
        }

        public int AtaqueTotal()
        {
            int aux = (Luva.AtaqueDoItem * Inventario.NlvArmadura);
            return (aux + this.Atk);
        }

        public int VelocidadeTotal()
        {
            int aux = (Bota.VeloAtaqueDoItem* Inventario.NlvArmadura);
            return (aux + this.Velo);
        }

        public int SorteTotal()
        {
            int aux = (Colar.SorteDoItem * Inventario.NlvArmadura);
            return (aux + this.Sorte);
        }
        public override bool Critico()
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 100);//tem que ser balanceado quando tiver feito as armaduras
            if (x <= SorteTotal())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int Defender(int AtaAtak)
        {
            if (DefesaTotal() > AtaAtak)
            {
                return 1;

            }
            else return (AtaAtak - DefesaTotal());
        }

        public override bool Esquivar(int VeloAtk)
        {

            if (this.Velo > VeloAtk)
            {
                Random randNum = new Random();

                int x = randNum.Next(0, 101);

                if (this.Velo - VeloAtk >= x)
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

        public override int CalcularDano(int AtaAtak, int VeloAtk, bool AtaCrit)
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 101);
            if (Esquivar(VeloAtk))
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

                    return (int)aux;
                }
            }
            else
            {
                return 0;

            }

        }

     
        public override int Ataques()
        {
            int aux = this.Atk;
            return aux;
        }

        public override int AtaqueEspecial()
        {
            throw new NotImplementedException();
        }
    }
}

    

