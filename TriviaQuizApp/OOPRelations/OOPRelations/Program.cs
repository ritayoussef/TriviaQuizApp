using OOPRelations.Models;

namespace OOPRelations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InheritanceDemo();
            //CastignDemo();

            PresenationAppDemo();

        }

        static void InheritanceDemo()
        {
            //PresentationObject presentation = new PresentationObject(40, 60); //Became Abstract
            //Console.WriteLine(presentation.ToString());
            //Console.WriteLine(presentation.Copy());

            Console.WriteLine("************");
            TextBox textBox = new TextBox();
            TextBox textBox1 = new TextBox("This is new text ");
            Console.WriteLine(textBox1);
            Console.WriteLine(textBox1.Copy());
            textBox1.Link = "www.abc.com"; //check the use of base keyword in the overriden setter

            TextBox textBox2 = new TextBox(40, 100);
            TextBox textBox3 = new TextBox("Hello world");


            FancyTextBox fancyTextBox = new FancyTextBox();
            Console.WriteLine("************");
            Console.WriteLine(fancyTextBox);
        }

        /* Public static members in the parent class can be accessed from both Parent & Child Classes. */
        static void StaticInInheritance()
        {
            Console.WriteLine(PresentationObject.Count);
            Console.WriteLine(TextBox.Count);
            Console.WriteLine(FancyTextBox.Count);
        }

        static void CastignDemo()
        {
            TextBox textBox = new TextBox("Casting demo");
            PresentationObject shape = textBox;

            /* You create 2 pointers: textBox and shape
             * both are pointing to the same location in memory.
             *      textBox : will be able to see all what a TextBox class can offer.
             *      shape   : will have a limited view  of because it is defined as a PresentationObject class
             * 
             * This is known as upcasting: treating a child object as parent object.     
             */

            textBox.ChangeText("ABC");
            //shape.ChangeText("ABC"); //shape cannot see Change Text as it is point to the parent part

            /*  Both pointers are pointing to the same memory location
             *  Hence a change of data or property using any pointer (variable name) will change the value for both.
             */
            shape.Link = "www.shape.com";
            textBox.Link = "www.Textbox.com";
            //Test it
            Console.WriteLine(shape.Link);
            Console.WriteLine(textBox.Link);

            /* you have been using upcasting without knowing - implicitly. 
             * The WriteLine(object value) methods expects an object. 
             * When you pass any object, the compiler will upcast to the parent of classes, the object class
             */
            Console.WriteLine(shape);
            Console.WriteLine(textBox.ToString());

            Console.WriteLine(shape.Copy());
            Console.WriteLine(textBox.Copy());

            //Destroy the pointer to the TextBox object
            textBox = null;
            //shape is still pointing to the memory block in HEAP so the garbage collector will not delete it.


            //Create new pointer to the same memory location
            //TextBox textBox2 = shape; //we cannot implicitly assign a parent object to a child object
            //as keyword: (down) cast shape to TextBox if possible

            //Create a child object and directly assign to a parent object.
            PresentationObject shape2 = new FancyTextBox();
            Console.WriteLine(shape2.ToString());
            Console.WriteLine(shape2.GetType());

            //FancyTextBox t = shape2;


            //Explicit casting: not safe could throw an exception
            FancyTextBox fancy = (FancyTextBox)shape2;

            //Explicit casting: not safe could throw an exception - in the commented code below an exception will be thrown
            //Image image = (Image)shape2;
            //string x = (string)shape2;

            /*
             *  HOW TO SAFELY DOWN CAST?
             */

            //Method 1: using "is" keyword within if statement
            if (shape2 is Image)
            {
                Image image = (Image)shape2;
                Console.WriteLine("Shape 2 is an image " + image.Source);
            }
            else
                Console.WriteLine("Casting Failed");

            /*
             *  Method 2: using "is" keyword within if statement
             *  if casting is possible create an Image pointer called image3 and point to the memory location of shape2
             */
            if (shape2 is Image image3)
            {
                Console.WriteLine(image3.Source);
            }


            /* Method 3: using "as" key word - which will try to cast
             * If casting is successful: image1 will point to the object in memory otherwise it will be null
             */
            Image image2 = shape2 as Image;
            if(image2 != null)
            {
                Console.WriteLine("Shape 2 is an image " + image2.Source);
                
            }
            else
            {
                Console.WriteLine("Casting Failed");
            }
        }


        static void PresenationAppDemo()
        {
            PresentationApp app = new PresentationApp();
            //PresentationObject shape1 = new PresentationObject(); //Became Abstract
            //app.AddPresentationObject(shape1); //it does not make sense to add it to the app we are creating
            //Another
            //app.AddPresentationObject(new PresentationObject()); //Became Abstract

            //Textbox
            TextBox box = new TextBox("ABC");
            app.AddPresentationObject(box);
            //Fancy
            FancyTextBox fancy = new FancyTextBox();
            app.AddPresentationObject(fancy);
            //Imag
            Image image = new Image("image.jpg");
            app.AddPresentationObject(image);

            
        }
    }
}