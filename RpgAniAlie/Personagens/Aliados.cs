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
        public Aliados(string sprite, string nome)
        {
            this.Nivel = 1;
            this.Nome = nome;
            this.Atk = 10;
            this.Vida = 10;
            this.Velo = 10;
            this.Def = 10;
            this.Sorte = 10;
            this.VidaMax = this.Vida;
        }
        public int MedidorEspecial { get; set; }
        public int XP { get; set; }
        public double XPProxNlv { get; set; }

        public void UparStatus()
        {
            this.VidaMax *= this.Nivel;
            this.Def *= this.Nivel;
            this.Atk *= this.Nivel;
            this.Velo *= this.Nivel;
            this.Sorte += this.Nivel;
            this.Vida = this.VidaMax;
        }
        public void GanharXP(int xp)
        {
            this.XP += xp;
            if(this.XP >= this.XPProxNlv)
            {
                this.XPProxNlv *= 1.5;
                this.Nivel++;
                UparStatus();
            }
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
            if (x <= this.SorteTotal())
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
            if (this.DefesaTotal() > AtaAtak)
            {
                return 1;

            }
            else return (AtaAtak - this.DefesaTotal());
        }

        public override bool Esquivar(int VeloAtk)
        {

            if (this.VelocidadeTotal() > VeloAtk)
            {
                Random randNum = new Random();

                int x = randNum.Next(0, 101);

                if (this.VelocidadeTotal() - VeloAtk >= x)
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


        public override int AtaqueEspecial()
        {
            throw new NotImplementedException();
        }
    }
}

    

