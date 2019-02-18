using System;
using System.Buffers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryExTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUnmanagedMemoryManager()
        {
            TestM<byte>();
            TestM<short>();
            TestM<int>();
            TestM<long>();
        }

        void TestM<T>()
        {
            const int length = 100;
            UnmanagedMemoryManager<T> manager = new UnmanagedMemoryManager<T>(length);
            var span = manager.GetSpan();
            Assert.AreEqual(length, manager.Length);
            Assert.AreEqual(length, span.Length);

            dynamic value = default;

            if (typeof(T) == typeof(byte))
            {
                value = byte.MaxValue;
            }
            if (typeof(T) == typeof(short))
            {
                value = short.MaxValue;
            }
            if (typeof(T) == typeof(int))
            {
                value = int.MaxValue;
            }

            if (typeof(T) == typeof(long))
            {
                value = long.MaxValue;
            }

            span[0] = value;
            var span2 = manager.GetSpan();
            Assert.AreEqual(span2[0], span[0]);

            if (manager is IDisposable disposable)
            {
                disposable.Dispose();

                try
                {
                    var span3 = manager.GetSpan();
                }
                catch (ObjectDisposedException)
                {

                }

                Assert.AreEqual(-1, manager.Length);
            }
        }

        [TestMethod]
        public void TestBYTE()
        {
            byte a = 255;
            sbyte b = (sbyte)a;
            Assert.AreEqual(-1, b);
            a = 0;
            b = (sbyte)a;
            Assert.AreEqual(0, b);
            a = 1;
            b = (sbyte)a;
            Assert.AreEqual(1, b);
            byte[] buffer = new byte[4];
            255.WriteTo(buffer);
            256.WriteTo(buffer);
            65535.WriteTo(buffer);
            65536.WriteTo(buffer);
        }
    }
}
