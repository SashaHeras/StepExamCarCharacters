using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StepExamCarCharacters
{
    public class MainSystem
    {
        public List<Model> Models { get; set; }
        public List<Color> Colors { get; set; }

        public MainSystem()
        {
            Models = new List<Model>();
            Colors = new List<Color>();
        }

        public String GetColor()
        {
            Console.Write(" Enter color to search: ");
            return Console.ReadLine();
        }

        public List<Model> SearchByColor(String color)
        {
            return Models.Where(model => model.Modifications.Exists(n => n.Colors.Exists(c => c.Name.Contains(color)))).ToList();
        }

        public void ShowModelsWithColors(String color)
        {
            List<Model> models = SearchByColor(color);

            foreach(Model mod in models)
            {
                if(mod.Modifications.Exists(n => n.Colors.Exists(c => c.Name.Contains(color)))==true)
                {
                    List<Modification> modif = mod.Modifications.Where(n => n.Colors.Exists(c => c.Name.Contains(color))).ToList();

                    if(modif==null)
                    {
                        Console.WriteLine(" No one model with this color of modification wasn`t founded!");
                    }
                    else
                    {
                        foreach (Modification m in modif)
                        {
                            List<Color> colors = m.Colors.Where(c => c.Name.Contains(color)).ToList();

                            Console.WriteLine($" {"Model".PadRight(15)}  {"Modification".PadRight(15)}  Color");

                            foreach (Color c in colors)
                            {
                                Console.WriteLine($" {mod.Name.PadRight(15)}  {m.Name.PadRight(15)}  {c.VendorId} - {c.Name};");
                            }
                        }
                    }
                }
            }
        }

        public Model GetModel()
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose model:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            return Models.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1);
        }

        public Modification GetModification(Model m)
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose modification:");
            foreach (Modification mod in m.Modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            return m.Modifications.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1);
        }

        public Color GetColor(Modification m)
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose color:");
            foreach (Color c in m.Colors)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of color: ");
            return m.Colors.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1);
        }

        public void AddModel()
        {
            Model m = new Model();

            Console.Write(" Please add model name: ");
            m.Name = Console.ReadLine();

            Console.Write(" Please add model vendor id: ");
            m.VendorId = Console.ReadLine();

            AddModification(m);

            Models.Add(m);

            String guid = m.Id.ToString();
            Logining(" Model with id " + guid + " was added!");
        }

        public void AddModification(Model m)
        {
            Modification mod = new Modification();

            Console.Write(" Please add modification name: ");
            mod.Name = Console.ReadLine();

            Console.Write(" Please add modification vendor id: ");
            mod.VendorId = Console.ReadLine();

            AddColor(mod);

            m.AddModification(mod);

            String guid = mod.Id.ToString();
            Logining(" Modification with id " + guid + " was added!");
        }

        public void AddColor(Modification m)
        {
            Color c = new Color();

            Console.Write(" Please add color name: ");
            c.Name = Console.ReadLine();

            Console.Write(" Please add color vendor id: ");
            c.VendorId = Console.ReadLine();

            m.AddColor(c);

            Colors.Add(c);

            String guid = c.Id.ToString();
            Logining(" Color with id " + guid + " was added!");
        }

        public void EditModel()
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose model to edit:");
            foreach(Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter new name of model: ");
            Models.ElementAt((id - 1)).ChangeName(Console.ReadLine());

            Console.Write(" Enter new vendor id of model: ");
            Models.ElementAt((id - 1)).ChangeVendor(Console.ReadLine());

            String guid = Models.ElementAt((id - 1)).Id.ToString();
            Logining(" Model with id " + guid + " was edited!");
        }

        public void EditModification()
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose model to edit it`s modfication:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            id = Convert.ToInt32(Console.ReadLine());

            List<Modification> modifications = Models.ElementAt((id - 1)).Modifications;

            k = 0;

            Console.WriteLine(" Choose modification to edit:");
            foreach (Modification m in modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of modification: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter new name of modification: ");
            modifications.ElementAt((id - 1)).ChangeName(Console.ReadLine());

            Console.Write(" Enter new vendor id of modification: ");
            modifications.ElementAt((id - 1)).ChangeVendor(Console.ReadLine());

            String guid = modifications.ElementAt((id - 1)).Id.ToString();
            Logining(" Modification with id " + guid + " was edited!");
        }

        public void EditColor()
        {
            int k = 0;
            int id = 0;
            int modId = 0;
            int colorId = 0;

            Console.WriteLine(" Choose model to edit it`s modfication`s color:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            id = Convert.ToInt32(Console.ReadLine());

            List<Modification> modifications = Models.ElementAt((id - 1)).Modifications;

            k = 0;

            Console.WriteLine(" Choose modification to edit it`s color:");
            foreach (Modification m in modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of modification: ");
            modId = Convert.ToInt32(Console.ReadLine());
            List<Color> colors = Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colors;

            k = 0;

            Console.WriteLine(" Choose color to edit:");
            foreach (Color c in colors)
            {
                Console.WriteLine($" {++k} " + c.Show());
            }

            Console.Write(" Enter index of color: ");
            colorId = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter new name of color: ");
            Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colors.ElementAt((colorId - 1)).ChangeName(Console.ReadLine());

            Console.Write(" Enter new vendor id of color: ");
            Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colors.ElementAt((colorId - 1)).ChangeVendor(Console.ReadLine());

            String guid = Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colors.ElementAt((colorId - 1)).Id.ToString();
            Logining(" Color with id " + guid + " was edited!");
            Console.WriteLine(" Color was edited!!!");
        }

        public void DeleteModel()
        {
            int k = 0;

            Console.WriteLine(" Choose model to delete:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            String guid = Models.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1).Id.ToString();
            Models.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);

            Logining(" Model with id " + guid + " was deleted!");
            Console.WriteLine(" Model was deleted!!!");
        }

        public void DeleteModification()
        {
            int k = 0;
            int id = 0;

            Console.WriteLine(" Choose model to delete it`s modfication:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            id = Convert.ToInt32(Console.ReadLine());

            List<Modification> modifications = Models.ElementAt((id - 1)).Modifications;

            k = 0;

            Console.WriteLine(" Choose modification to delete:");
            foreach (Modification m in modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of modification: ");
            String guid = Models.ElementAt((id - 1)).Modifications.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1).Id.ToString();
            Models.ElementAt((id - 1)).Modifications.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);

            Logining(" Modification with id " + guid + " was deleted!");
            Console.WriteLine(" Modification was deleted!!!");
        }

        public void DeleteColor()
        {
            int k = 0;
            int id = 0;
            int modId = 0;
            int colorId = 0;

            Console.WriteLine(" Choose model to delete it`s modfication`s color:");
            foreach (Model m in Models)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of model: ");
            id = Convert.ToInt32(Console.ReadLine());

            List<Modification> modifications = Models.ElementAt((id - 1)).Modifications;

            k = 0;

            Console.WriteLine(" Choose modification to delete it`s color:");
            foreach (Modification m in modifications)
            {
                Console.WriteLine($" {++k} " + m.Show());
            }

            Console.Write(" Enter index of modification: ");
            modId = Convert.ToInt32(Console.ReadLine());
            List<Color> colors = Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colors;

            k = 0;

            Console.WriteLine(" Choose color to delete:");
            foreach (Color c in colors)
            {
                Console.WriteLine($" {++k} " + c.Show());
            }

            Console.Write(" Enter index of color to delete: ");
            colorId = Convert.ToInt32(Console.ReadLine()) - 1;
            String guid = Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colors.ElementAt(colorId).Id.ToString();
            Models.ElementAt((id - 1)).Modifications.ElementAt(modId - 1).Colors.RemoveAt(colorId);

            Logining(" Color with id " + guid + " was deleted!");
            Console.Write(" Color was deleted!!! ");
        }

        public void Logining(String line)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\User\\source\\repos\\StepExamCarCharacters\\StepExamCarCharacters\\loging.txt");
                
                sw.WriteLine(line);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void SerialXML()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Model>));
            using (FileStream fs = new FileStream("models.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, Models);
            }
        }
    }
}
