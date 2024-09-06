using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRelations.Models
{
    /* Inheritance:
    *   How to implement Inheritance?
    *   What happens in the memory?
    *   Constructors: Parent - Child
    *   Base Class - Derived Class Accessibility
    *   Accessing members in the base class
    *   Access modifiers
    *   Overriding methods: (virtual keyword)
    */

    //Parent class - base class
    internal abstract class PresentationObject
    {
        //Common Data members
        private double _height;
        private double _width;

        //full property
        //A property can be virtual in case you need to change the behavior of the set or the get in the derived class.
        private string _link;

        public virtual string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        //Auto-Implemented property
        //protected: can be access in derived classes (only set is protected - get is public)
        public DateTime CreatedTime { get; protected set; }

        //Static in parent class
        private static int _count = 0;

        public static int Count
        {
            get { return _count; }
        }

        //Methods

        /*  A method marked as virtual allow us to override it in derived class
         *  keyword virtual is used only once when the method is introduced for the first time.
         */
        public virtual string Copy()
        {
            return "Presentation object copied to clipboard";
        }

        public PresentationObject ResetSize(double height, double width)
        {
            _height = height;
            _width = width;
            return this;
        }

        //Constructors: with arguments
        public PresentationObject(double height, double width)
        {
            _height = height;
            _width = width;
            CreatedTime = DateTime.Now; 
        }

        public PresentationObject(string link="www.PIII.ca")
        {
            _link = link;
        }

        // Reset Method to back to original state 
        //protected: can be access in derived classes
        protected void ResetShape()
        {
            _height = 0;
            _width = 0;
            CreatedTime = DateTime.Now;
        }
        //Changing the behavior of ToString method that is coming from the Object class
        public override string ToString()
        {
            return "This is a presentation object";
        }

        //public virtual string Draw()
        //{
        //    return "PLEASE CHANGE IMPLIMENTATION IN CHILD";
        //}
        public abstract string Draw(); //When adding an abstract method, the class become Abstract

        public abstract void TestMethod(int input);

    }
    /* Text Box Class:
     * text
     * height
     * width
     * created date\time
     * link
     * 
     * Copy\Cut\Paste
     * 
     */
    /* Image class:
     * Source
     * height
    * width
    * created date\time
    * link
    * 
    * Copy\Cut\Paste
    */

    /* Table class:
     * columns \rows
     * height
    * width
    * created date\time
    * link
    * 
    * Copy\Cut\Paste
    */


}
