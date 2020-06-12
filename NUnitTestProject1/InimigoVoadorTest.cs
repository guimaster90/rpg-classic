using NUnit.Framework;
using RpgAniAlie.Personagens;

namespace Tests
{
    public class Tests2
    {
        [SetUp]
        public void Setup2()
        {

        }

        [Test]
        
        public void ReceberDanoVoador()
        {
            var inimigo = new InimigosVoadores(1, "deslizando", "inimig");
            inimigo.Vida = 100;
            inimigo.Velo = 0;
            inimigo.Def = 100;
            inimigo.ReceberDano(125, 1, false);
            Assert.Greater(inimigo.Vida, 79);
            Assert.Less(inimigo.Vida, 95);
        }

    }
}