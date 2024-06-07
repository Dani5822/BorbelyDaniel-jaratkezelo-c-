using JaratKezeloProject;
using static JaratKezeloProject.JaratKezelo;
namespace TestJaratKezeloProject
{
    public class Tests
    {
        JaratKezelo Jarat;

        [SetUp]
        public void Setup()
        {
           Jarat = new JaratKezelo();
        }

        [Test]
        public void ujjarathelyesadattal()
        {
            Jarat.ujJarat("555","Madrid","Monaco",DateTime.Now);
        }

        [Test]

        public void ujjaratugyanazajaratszamnemlehet()
        {
            Jarat.ujJarat("555", "Madrid", "Monaco", DateTime.Now);
            Assert.Throws<ArgumentException>(() => Jarat.ujJarat("555", "Budapest", "Debrecen", DateTime.Now));
        }

        [Test]
        public void jaratkeseshozzaadasa()
        {
            Jarat.ujJarat("555", "Madrid", "Monaco", DateTime.Now);
            Jarat.Keses("555", 15);
        }

        [Test]
        public void jarattobbkeseshozzaadasa()
        {
            Jarat.ujJarat("555", "Madrid", "Monaco", DateTime.Now);
            Jarat.Keses("555", 15);
            Jarat.Keses("555", 15);
            Assert.That(Jarat.mikorIndul("555").Minute, Is.EqualTo(DateTime.Now.AddMinutes(30).Minute));
        }

        [Test]
        public void jarattobbkeseshozzaadasaminusz()
        {
            Jarat.ujJarat("555", "Madrid", "Monaco", DateTime.Now);
            Jarat.Keses("555", 15);
            Jarat.Keses("555", -15);
            Assert.That(Jarat.mikorIndul("555").Minute, Is.EqualTo(DateTime.Now.Minute));
        }
        [Test]
        
        public void jarattobbkeseshozzaadasaminuszbamegy()
        {
            Jarat.ujJarat("555", "Madrid", "Monaco", DateTime.Now);
            
            Assert.Throws<NegativKesesException>(() =>Jarat.Keses("555", -15));
        }

        [Test]
        public void repterszures()
        {
            Jarat.ujJarat("555", "Madrid", "Monaco", DateTime.Now);
            Jarat.ujJarat("557", "Madrid", "Budapest", DateTime.Now);
            Jarat.ujJarat("556", "Bukarest", "Budapest", DateTime.Now);
            Assert.That(Jarat.jaratokRepuloterrol("Madrid").Count(), Is.EqualTo(2));
        }


    }
}