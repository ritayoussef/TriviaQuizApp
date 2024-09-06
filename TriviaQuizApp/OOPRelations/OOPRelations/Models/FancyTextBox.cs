using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRelations.Models
{
    //Two layers of inheritance
    class FancyTextBox : TextBox
    {
        private string font;

        public FancyTextBox(string font) : base("Fancy Text box")
        {
            base.CreatedTime = DateTime.Now;
            this.font = font;

        }

        public FancyTextBox() : base()
        {
            base.ChangeText(" Fancy");
        }

        //Overriding the copy method from parent: parent method is used.
        public override string Copy()
        {
            //adding some logic that required the parent Copy implementation.
            string parentCopy = base.Copy();
            //Some logic (for demo )
            if (string.IsNullOrEmpty(parentCopy))
                return "Fancy Text box copied to clip board";
            else
                return "Fancy + TextBox + Presentation obj copied.";
        }

        public void SetFont(string font)
        {

        }

        //Static in parent class
        private static int _count = 0;

        public static int Count
        {
            get { return _count; }
        }

        public override string ToString()
        {
            return "This is a FancyTexbox";
        }

        public override string Draw()
        {
            return base.Draw() + " that is fancy..";
        }

    }
}
