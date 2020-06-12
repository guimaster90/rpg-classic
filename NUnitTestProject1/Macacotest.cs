using NUnit.Framework;
using RpgAniAlieLib.Personagens;
using RpgAniAlieLib.Player;

namespace Tests
{
    public class Tests5
    {
        [SetUp]
        public void Setup5()
        {

        }

        [Test]

        public void Recarregar()
        {
            var macaco = new Macaco("pulando", "caco");
            Inventario.QtdBala = 5;
            macaco.MedidorEspecial = 0;
            Assert.IsTrue(macaco.Recarregar());
        }

        [Test]
        public void AtaqueEspecial()
        {
            var macaco = new Macaco("pulando", "caco");
            macaco.MedidorEspecial = 2;
            macaco.Atk = 10;
            macaco.Nivel = 1;
            Assert.AreEqual(macaco.AtaqueEspecial(), 15);
        }
    }
}