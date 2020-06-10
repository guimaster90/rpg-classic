using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RpgAniAlie.Equipamento;

namespace RpgAniAlie.Personagens
{
    public class Aliados : Personagem
    {

        ArrayList inventarioCapacete = new ArrayList ();
        ArrayList inventarioPeitoral = new ArrayList ();
        ArrayList inventarioBota = new ArrayList ();
        ArrayList inventarioLuva = new ArrayList ();
        ArrayList inventarioColar = new ArrayList ();
        ArrayList inventarioPoção = new ArrayList();
        ArrayList inventarioMunição = new ArrayList();
        ArrayList CapaceteEquipado = new ArrayList ();
        ArrayList PeitoralEquipado = new ArrayList ();
        ArrayList BotasEquipado = new ArrayList ();
        ArrayList LuvaEquipado = new ArrayList ();
        ArrayList ColarEquipado = new ArrayList ();

        public Aliados()
        {
            Capacete CapaceteBasico = new Capacete();
            CapaceteBasico.NomeDoItem = "Capacete Lixo";
            CapaceteBasico.DefesaDoItem = 20;
            CapaceteBasico.AtaqueItem = 5;
            CapaceteBasico.VeloAtaqueDoItem = 5;


        public bool AdicionarArmaduraLixo(){//usado no começo do jogo
        inventarioCapacete.Add( new CapaceteBasico());
        inventarioPeitoral.Add(new PeitoralBasico());
        inventarioLuva.Add(new LuvaBasico());
        inventarioBota.Add(new BotaBasico());
        inventarioColar.Add(new ColarDePoucaSorte());
        CapaceteEquipado.Add(new CapaceteBasico());
        PeitoralEquipado.Add(new PeitoralBasico());
        LuvaEquipado.Add(new LuvaBasico());
        BotasEquipado.Add(new BotaBasico());
        ColarEquipado.Add(new ColarDePoucaSorte());
        return true;
        }

        public bool AdicionarArmaduraBlindona(){//usado em algum bau
        inventarioCapacete.Add( new CapaceteDefesa());
        inventarioPeitoral.Add(new PeitoralDefesa());
        inventarioLuva.Add(new LuvaDefesa());
        inventarioBota.Add(new BotaDefesa());
        return true;
        }

        public bool AdicionarArmaduraParruda(){//usado em algum bau
        inventarioCapacete.Add( new CapaceteAtaque());
        inventarioPeitoral.Add(new PeitoralAtaque());
        inventarioLuva.Add(new LuvaAtaque());
        inventarioBota.Add(new BotaAtaque());
        return true;
        }

        public bool AdicionarArmaduraLigeirinho(){//usado em algum bau
        inventarioCapacete.Add( new CapaceteRapido());
        inventarioPeitoral.Add(new PeitoralRapido());
        inventarioLuva.Add(new LuvaRapido());
        inventarioBota.Add(new BotaRapido());
        return true;
        }
        public bool AdicionarColarComSorte(){//usado em algum bau
        inventarioColar.Add(new ColarComSorte());
        return true;
        }
        public bool AdicionarColoarDeMuitaSorte(){//usado em algum bau
            inventarioColar.Add(new ColarDeMuitaSorte());
            return true;
        }

        public bool EquiparCapacete(Equip Cap){//sera mudado futuramente pra receber um objeto via clickevent
            CapaceteEquipado.RemoveAt(0);
            CapaceteEquipado.Add(Cap);
            return true;
        }
        public bool EquiparPeitoral(Equip Peit){//sera mudado futuramente pra receber um objeto via clickevent
            PeitoralEquipado.RemoveAt(0);
            PeitoralEquipado.Add(Peit);
            return true;
        }
        public bool EquiparLuva(Equip Luva){//sera mudado futuramente pra receber um objeto via clickevent
            LuvaEquipado.RemoveAt(0);
            LuvaEquipado.Add(Luva);
            return true;
        }
        public bool EquiparBota(Equip Bota){//sera mudado futuramente pra receber um objeto via clickevent
            BotasEquipado.RemoveAt(0);
            BotasEquipado.Add(Bota);
            return true;
        }
        public bool EquiparColar(Equip Colar) {//sera mudado futuramente pra receber um objeto via clickevent
            ColarEquipado.RemoveAt(0);
            ColarEquipado.Add(Colar);
            return true;
        }

        public override bool Critico()
        {
            Random randNum = new Random();
            int x = randNum.Next(0, 100);//tem que ser balanceado quando tiver feito as armaduras
            if (x <= this.Sorte)
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
            if (this.Def > AtaAtak)
            {
                return 1;

            }
            else return (AtaAtak - this.Def);
        }

        public override bool Esquivar(int VeloAtk)
        {
            return false;

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
    }
}

    

