using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraFeaturesDrill01
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dnaSource = "Steve Jobs";
            var CloneList = new List<Clone>();
            Console.WriteLine("We must have more {0}es!  How many clones should we create?", dnaSource);
            var numberClones = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Very well, begin the cloning process for {0} {1}es!", numberClones, dnaSource);
            for (int i = 0; i < numberClones; i++)
            {
                var designation = String.Format("Steve Jobsoid {0}", i);
                var newClone = new Clone(designation);
                CloneList.Add(newClone);
            }
            var cloneTotal = CloneList.Count();
            Console.WriteLine("Success!  We have created {0} {1}es!  Now we will have all the i-Things!", cloneTotal, dnaSource);
            Console.ReadLine();
        }
    }
}
