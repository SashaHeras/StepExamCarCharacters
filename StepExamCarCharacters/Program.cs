using System;

namespace StepExamCarCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            MainSystem ms = new MainSystem();

            ms.AddModel();

            //ms.EditModel();

            //ms.EditModification();

            //ms.ShowModelsWithColors(ms.GetColor());

            //ms.DeleteModel();

            //ms.DeleteModification();

            ms.SerialXML();

            Console.ReadKey();
        }
    }
}
