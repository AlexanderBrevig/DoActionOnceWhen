using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AB.Utilities;

namespace AB.Utilities.Tests
{
    [TestClass]
    public class DoActionOnceWhenTest
    {
        [TestInitialize]
        public void TestInit()
        {
            wasCalled = false;
            a = () => wasCalled = true;
            aowt = DoActionOnceWhen.Do(a);
        }

        [TestMethod]
        public void TestFactoryMethodForNullValue()
        {
            DoActionOnceWhen aowtNull = DoActionOnceWhen.Do(null);
            Assert.IsNull(aowtNull);
        }

        [TestMethod]
        public void TestFactoryMethodNonNull()
        {
            DoActionOnceWhen aowtNotNull = DoActionOnceWhen.Do(() => { });
            Assert.IsNotNull(aowtNotNull);
        }

        [TestMethod]
        public void TestWhenFalse()
        {
            Assert.IsFalse(wasCalled);
            aowt.When(() => false);
            Assert.IsFalse(wasCalled);
        }

        [TestMethod]
        public void TestWhenTrueOnlOnce()
        {
            Assert.IsFalse(wasCalled);
            Assert.IsTrue(aowt.When(() => true));
            Assert.IsFalse(aowt.When(() => true));
        }

        [TestMethod]
        public void TestReset()
        {
            Assert.IsFalse(wasCalled);
            Assert.IsTrue(aowt.When(() => true));
            aowt.Reset();
            Assert.IsTrue(aowt.When(() => true));
            Assert.IsFalse(aowt.When(() => true));
        }

        private bool wasCalled;
        private Action a;
        private DoActionOnceWhen aowt;
    }
}
