﻿using Sigil.NonGeneric;
using System;
using Xunit;

namespace SigilTests
{
    public partial class LoadObject
    {
        [Fact]
        public void SimpleNonGeneric()
        {
            var e1 = Emit.NewDynamicMethod(typeof(DateTime), new [] { typeof(DateTime) });
            e1.LoadArgumentAddress(0);
            e1.LoadObject<DateTime>();
            e1.Return();

            var d1 = e1.CreateDelegate<Func<DateTime, DateTime>>();

            var now = DateTime.UtcNow;

            Assert.Equal(now, d1(now));
        }
    }
}
