/*Author: Nathan Bean
 * Edited By: Samantha Rupnick
 * Q2: Add tests to check that class implements the INotifyPropertyChanged interface
 *  and that when a property is changed, the event handler is invoked
 *  Class: CobblerUnitTest.cs
 *  Purpose: Tests for the Cobbler class
 */

using System;
using System.ComponentModel;
using ExamTwoCodeQuestions.Data;
using Xunit;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        /// <summary>
        /// Tests to see if the cobbler implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChangedInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cobbler);
        }

        /// <summary>
        /// Tests to see if changing the fruit filling invokes INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ChangingFruitFillingShouldInvokeINotifyPropertyChanged()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Fruit", () => { cobbler.Fruit = FruitFilling.Cherry; });
            Assert.PropertyChanged(cobbler, "Fruit", () => { cobbler.Fruit = FruitFilling.Blueberry; });
            Assert.PropertyChanged(cobbler, "Fruit", () => { cobbler.Fruit = FruitFilling.Peach; });
        }

        /// <summary>
        /// Tests to see if changing the fruit filling invokes INotifyPropertyChanged for special instructions
        /// </summary>
        [Fact]
        public void ChangingFruitFillingShouldInvokeINotifyPropertyChangedForSpecialInstructions()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () => { cobbler.Fruit = FruitFilling.Cherry; });
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () => { cobbler.Fruit = FruitFilling.Blueberry; });
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () => { cobbler.Fruit = FruitFilling.Peach; });
        }

        /// <summary>
        /// Tests to see if holding ice cream invokes INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamShouldInvokeINotifyPropertyChanged()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "WithIceCream", () => { cobbler.WithIceCream = false; });
        }

        /// <summary>
        /// Tests to see if changing the fruit filling invokes INotifyPropertyChanged for special instructions
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamShouldInvokeINotifyPropertyChangedForSpecialInstructions()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () => { cobbler.WithIceCream = false; });
        }
    }
}
