using NUnit.Framework;
using RpgAniAlieLib.Personagens;

namespace Tests
{
    public class Tests7
    {
        [SetUp]
        public void Setup7()
        {

        }

        [Test]
        public void Recarregar()
        {
            var cobra = new Cobra("rateja", "cobra");
            cobra.MedidorEspecial = 9;
            Assert.IsTrue(cobra.RecarregarVeneno());
            cobra.RecarregarVeneno();
            Assert.AreEqual(cobra.MedidorEspecial, 10);
        }

        [Test]
        public void AtaqueTest()
        {
            var cobra = new Cobra("rateja", "cobra");
            cobra.MedidorEspecial = 9;
            cobra.Atk = 10;
            cobra.Nivel = 1;
            Assert.AreEqual(cobra.AtaqueEspecial(), 17);
             cobra.AtaqueEspecial();
            Assert.AreEqual(cobra.MedidorEspecial, 3);
        }
    }
}