﻿using System;
using FixedPoint;
using FluentAssertions;
using NUnit.Framework;

namespace FPTesting
{
    public class fpTests
    {
        [Test]
        public void ToStringTest()
        {
            var originalFp = fp._1 - fp._0_01;
            originalFp.ToString().Should().Be("0.99009");
            
            originalFp = fp._1 - fp._0_01 *fp._0_01;
            originalFp.ToString().Should().Be("0.99999");
            
            originalFp = fp._1;
            originalFp.ToString().Should().Be("1.00000");
            
            originalFp = fp._1 + fp._0_01;
            originalFp.ToString().Should().Be("1.00999");
            
            originalFp = fp._0_01;
            originalFp.ToString().Should().Be("0.00999");
            
            originalFp = fp._0_50;
            originalFp.ToString().Should().Be("0.50004");
        }
        
        [Test]
        public void FromStringTest()
        {
            var parsedFp = fp.Parse("4.05");
            Assert.IsTrue(parsedFp >fp._4           +fp._0_04);
            Assert.IsTrue(parsedFp <fp._4 +fp._0_05 +fp._0_01);

            parsedFp = fp.Parse("334535.98767");
            Assert.IsTrue(parsedFp > fp.Parse(334535)            + fp._0_95);
            Assert.IsTrue(parsedFp < fp.Parse(334535) + fp._0_95 + fp._0_04);
            
            parsedFp = fp.Parse("-.00005");
            Assert.IsTrue(parsedFp < fp._0);
            Assert.IsTrue(parsedFp > -fp._0_01 *fp._0_01);
        }

        [Test]
        public void FromFloatTest()
        {
            var parsedFp = fp.Parse(4.5f);
            Assert.IsTrue(parsedFp > fp._4 + fp._0_50 - fp._0_02);
            Assert.IsTrue(parsedFp < fp._4 + fp._0_50 + fp._0_01);
            
            parsedFp = fp.Parse(335.978655f);
            Assert.IsTrue(parsedFp > fp.Parse(335)            + fp._0_95);
            Assert.IsTrue(parsedFp < fp.Parse(335) + fp._0_95 + fp._0_04);
            
            parsedFp = fp.Parse(-.00005f);
            Assert.IsTrue(parsedFp < fp._0);
            Assert.IsTrue(parsedFp > -fp._0_01 *fp._0_01);
        }
    }
}