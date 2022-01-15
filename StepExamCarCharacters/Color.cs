using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepExamCarCharacters
{
    public class Color
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String VendorId { get; set; }

        public Color()
        {
            this.Id = Guid.NewGuid();
        }

        public Color(String name, String vendo)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.VendorId = vendo;
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
