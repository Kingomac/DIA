using POIS.Core;

namespace POISTest;

public class Tests
{
    [TestFixture]
    public class TestPOIS {

        [SetUp]
        public void AntesDeCadaTest() {
            p0 = new Poblacion(
                x: 42.434242343,
                y: -7.863454354325,
                nombre : "Ourense",
                numHabs : 100_000
            );
        }

        [Test]
        public void TestPoblación() {
            Assert.AreEqual(42.434242343, p0.X);
            Assert.AreEqual(-7.863454354325, p0.Y);
            Assert.AreEqual("Ourense", p0.Nombre);
            Assert.AreEqual(100_000, p0.NumHabitantes);
        }

        [Test]
        public void TestFactoria() {
            var p0 = POIFactoria.CreaPoblacion(
                x: 42.434242343,
                y: -7.863454354325,
                nombre: "Ourense",
                numHabs: 100_000
            );

            Assert.AreEqual(this.p0.X, p0.X);
            Assert.AreEqual(this.p0.Y, p0.Y);
            Assert.AreEqual(this.p0.Nombre, p0.Nombre);
            Assert.AreEqual(this.p0.NumHabitantes, p0.NumHabitantes);
        }

        private Poblacion p0;
    }
}