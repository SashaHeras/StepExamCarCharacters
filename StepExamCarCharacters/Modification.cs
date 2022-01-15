using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepExamCarCharacters
{
    public class Modification
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String VendorId { get; set; }

        public List<Color> Colors { get; set; }

        public Modification()
        {
            this.Id = Guid.NewGuid();
        }

        public Modification(String name,String vendo)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.VendorId = vendo;
        }

        public bool AddColor(Color c)
        {
            if (Colors == null) 
            {
                Colors = new List<Color>();
                Colors.Add(c);

                return true;
            }

            Colors.Add(c);
            return true;
        }

        public void ChangeName(String newName)
        {
            this.Name = newName;
        }

        public void ChangeVendor(String newVendor)
        {
            this.VendorId = newVendor;
        }

        public String Show()
        {
            return this.Name.PadRight(15) + this.VendorId;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
