using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRelations.Models
{
    //Connect the dots: using the classes we created in an app
    internal class PresentationApp
    {
        //Data Fields related to the class
        private int serialNumber;
        private string version;

        //Composition: one-to-one (1:1) relation with the hosting class
        TextBox textBox = new TextBox(); //Objects require initialization [new] operator
        Image image = new Image("image.jpg");

        //Composition: one-to-many (0:*) relation with the hosting class
        private List<TextBox> _textBoxes = new List<TextBox>();
        private List<Image> _images = new List<Image>();


        /* 
         *  TASK: Create a method to add presentation objects to the app
         * 
         *  Objective from demo is to create one method to add to the proper list.
         *  
         *  Utilize "Upcasting" feature to be able to pass objects of the same family to the method
         *  Usually when the upcasting feature is used when the logic of the method requires the use of common methods among all classes.
        */

        public PresentationApp AddPresentationObject(PresentationObject shape)
        {
            //Console.WriteLine(shape.GetType());
            //Console.WriteLine(shape.ToString());
            
            //OLD WAY
            if(shape.GetType() == typeof(TextBox)) 
            { 
                //Some logic
            }

            //using the "is" keyword
            if(shape is Image img)
            {
                _images.Add(img);
            }
            else if (shape is TextBox textBox) 
            {
                _textBoxes.Add(textBox);
            }
            //else if (shape is FancyTextBox fancy) //not needed as a fancyTextbox is a Textbox
            //{
            //    _textBoxes.Add(fancy);
            //}
            else
            {
                //Console.WriteLine("This object cannot be presented");
            }


            /* You can see how different forms of the Copy method is called inside: AddPresentationObject
            * The Copy() method is overridden in each of the derived classes.
            */
            Console.WriteLine(shape.Copy());

            Console.WriteLine(shape.Draw());
            return this;
        }
    }
}
