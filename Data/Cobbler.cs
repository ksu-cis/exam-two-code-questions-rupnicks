/* Author: Nathan Bean
 * Edited by: Samantha Rupnick
 * Class: Cobbler.cs
 * Q1: Implement the INotifyPropertyChanged interface
 * Purpose: Holds the data for the Cobbler (yummy btw)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler for the propertychanged event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private FruitFilling fruit;
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit
        {
            get { return fruit; }
            set
            {
                fruit = value;
                NotifyOfPropertyChanged("Fruit");
            }
        }

        private bool withIceCream = true;
        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream
        {
            get { return withIceCream; }
            set
            {
                withIceCream = value;
                NotifyOfPropertyChanged("WithIceCream");
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else return 4.25;
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }

        /// <summary>
        /// Helper method that invokes the property being passed in as well as the specialinstructions property
        /// </summary>
        /// <param name="property"></param>
        protected void NotifyOfPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }
    }
}
