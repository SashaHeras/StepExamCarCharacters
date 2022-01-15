using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepExamCarCharacters
{
    public class Model
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String VendorId { get; set; }

        public List<Modification> Modifications { get; set; }

        public Model()
        {
            this.Id = Guid.NewGuid();
        }

        public Model(String name,String vendo)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.VendorId = vendo;
        }

        public bool AddModification(Modification m)
        {
            if (Modifications == null)
            {
                Modifications = new List<Modification>();
                Modifications.Add(m);

                return true;
            }

            Modifications.Add(m);
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
