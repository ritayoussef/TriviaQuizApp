using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRelations.Models
{
    /* Image class:
     * Source
     * height
    * width
    * created date\time
    * link
    * 
    * Copy\Cut\Paste
    */
    internal class Image : PresentationObject
    {
        //Own members
        private string _source;

        public string Source
        {
            get { return _source; }
            set { _source = value; } // Add validation
        }

        private double GetOriginalHeight()
        {
            return 100;
        }

        private double GetOriginalWidth()
        {
            return 200;
        }

        public Image(string source) :base(0, 0)
        {
            Source = source;
            base.ResetSize(GetOriginalHeight(), GetOriginalWidth());
        }

        public override string Copy()
        {
            return $"Image: {Source} is copied to clipboard";
        }

        public override string ToString()
        {
            return "This is an image";
        }

        public override string Draw()
        {
            return "Draw Image";
        }

        public override void TestMethod(int input)
        {
            throw new NotImplementedException();
        }
    }
}
