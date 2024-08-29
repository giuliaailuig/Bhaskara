using Microsoft.VisualStudio.TestTools.UnitTesting;
using BhaskaraApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhaskaraApp.Tests
{
    [TestClass()]
    public class BhaskaraTests
    {
        [TestMethod()]
        [DataRow(1, -3, 2, 2, 1)] // Delta = 1, Raízes: 2 e 1
        [DataRow(1, -4, 3, 3, 1)] // Delta = 4, Raízes: 3 e 1
        [DataRow(1, -5, 6, 3, 2)] // Delta = 1, Raízes: 3 e 2
        [DataRow(2, 3, 1, -0.5, -1)] // Delta = 1, Raízes: -0.5 e -1
        public void CalcularRaizesUnitTest_Raizes(double a, double b, double c, double e1, double e2)
        {
            var bhaskara = new Bhaskara(a, b, c);

            var (raiz1, raiz2) = bhaskara.CalcularRaizes();

            raiz1.ToString();
            raiz2.ToString();

            string esperado = e1.ToString() + "/" + e2.ToString();
            string obtido = raiz1 + "/" + raiz2;

            Assert.AreEqual(esperado, obtido);
        }

        [TestMethod()]
        [DataRow(1, -3, 2, true)]    // Delta = 1, Raízes reais
        [DataRow(1, -4, 3, true)]    // Delta = 4, Raízes reais
        [DataRow(2, -4, 1, true)]    // Delta = 4, Raízes reais
        [DataRow(1, 2, 1, false)]    // Delta = 0, apenas uma raiz real (não conta como duas)
        [DataRow(2, 4, 5, false)]    // Delta = -4, nenhuma raiz real
        [DataRow(3, 5, 7, false)]    // Delta = -47, nenhuma raiz real
        public void TemRaizesReaisUnitTest(double a, double b, double c, bool esperado)
        {
            var bhaskara = new Bhaskara(a, b, c);

            bool obtido = bhaskara.TemRaizesReais();

            Assert.AreEqual(esperado, obtido);
        }

        [TestMethod()]
        [DataRow(1, -3, 2, 1)]    // Delta = 1
        [DataRow(1, -4, 3, 4)]    // Delta = 4
        [DataRow(2, 4, 1, 8)]     // Delta = 8
        [DataRow(1, 2, 1, 0)]     // Delta = 0
        [DataRow(3, 5, 7, -59)]   // Delta = -59
        [DataRow(1, -4, 4, 0)]    // Delta = 0
        [DataRow(2, -8, 6, 16)]   // Delta = 16
        public void CalcularDeltaTest_NoException(double a, double b, double c, double esperado)
        {
            var bhaskara = new Bhaskara(a, b, c);

            double obtido = bhaskara.CalcularDelta();

            Assert.AreEqual(esperado, obtido);
        }
    }
}
