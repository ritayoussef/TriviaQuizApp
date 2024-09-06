using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRelations.Models
{
    internal class TextBox : PresentationObject
    {
        //data fields
        private const int DEFAULT_HEIGHT = 100;
        private const int DEFAULT_WIDTH = 200;
        private string textValue;

        //Child method (not part of the parent class)
        public string ChangeText(string newText)
        {
            return textValue = newText;
        }

        public string Text
        {
            get { return textValue; }
        }

        //Constructors
        //:base allow us to call a specific constructor from the base class
        public TextBox() : base(DEFAULT_HEIGHT, DEFAULT_WIDTH)
        {
            textValue = "Sample";
        }

        public TextBox(double textBoxHeight,  double textBoxWidth)
            :base(textBoxHeight, textBoxWidth) 
        {
            textValue = "Sample";
        }

        public TextBox(double textBoxHeight, double textBoxWidth, string text)
            : base(textBoxHeight, textBoxWidth)
        {
            textValue = text;
        }
        //Calls the first constructor which will call the base constructor with the default values of width and height
        public TextBox(string text) : this()
        {
            textValue = text;
            base.ResetShape();
        }
        //Using protected data or methods from parent
        private void ResetTextBox()
        {
            base.ResetShape();// ResetObject() is a protected method in parent - base keyword is optional
            CreatedTime = DateTime.Now;
            textValue = string.Empty;
        }

        //Overriding the ToString method from parent: parent implementation not used.
        public override string ToString()
        {
            return "This is a textbox";
        }

        //Overriding the copy method from parent: parent implementation is used with modification.
        //Note that the use keyword override (possible because the original Copy is marked as virtual)
        //We do not use the keyword virtual again.
        public override string Copy()
        {
            return base.Copy() + " but this is textbox";
        }

        //public override string Link 
        //{ 
        //    get => base.Link; 
        //    set => base.Link = value; 
        //}

        //Overriding the set in the property
        public override string Link
        {
            get { return base.Link; }
            set
            {
                //note: you must use the keyword base here otherwise, you will get a stackover flow.
                if (value != "www.PIII.ca")
                    base.Link = value;
            }

        }

        public override string Draw()
        {
            return "Drawing TextBox...";
        }

        //Note that the abstract method should be implemented with same header: return type Name(argument list) 
        public override void TestMethod(int input)
        {
            //some logic
        }
    }
}
