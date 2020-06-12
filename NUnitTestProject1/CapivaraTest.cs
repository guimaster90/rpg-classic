using NUnit.Framework;
using RpgAniAlieLib.Personagens;

namespace Tests
{
    public class Tests6
    {
        [SetUp]
        public void Setup6()
        {

        }

        [Test]
        
        public void Recarregar()
        {
            var capivara = new Capivara("rasteira","cap");
            capivara.MedidorEspecial = 9;
            capivara.ReceberStamina();
            Assert.AreEqual(capivara.MedidorEspecial, 10);
        }

        [Test]
        public void AtaqueEspecial()
        {
            var capivara = new Capivara("rasteira", "cap");
            capivara.MedidorEspecial = 9;
            capivara.Nivel = 1;
            capivara.Atk = 10;
            Assert.AreEqual(capivara.AtaqueEspecial(), 16);
            Assert.AreEqual(capivara.MedidorEspecial, 4);
            Assert.AreEqual(capivara.AtaqueEspecial(), 0);
        }
    }
}