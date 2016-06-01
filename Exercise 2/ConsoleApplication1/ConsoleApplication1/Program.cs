using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicLibraryVisitor library = new MusicLibraryVisitor();

            Jazz jazz = new Jazz();
            HeavyMetal heavyMetal = new HeavyMetal();

            jazz.Visit(library);
            jazz.Visit(library);
            jazz.Visit(library);
            jazz.Visit(library);
            jazz.Visit(library);
            heavyMetal.Visit(library);
            heavyMetal.Visit(library);
            heavyMetal.Visit(library);
            heavyMetal.Visit(library);

            Console.WriteLine("Amount of jazz songs: " + library.Jazz.Count());
            Console.WriteLine("Amount of heavy metal songs: " + library.HeavyMetal.Count());

            Console.ReadKey();
        }
    }

    interface ISong
    {
        void Visit(IMusicLibraryVisitor visitor);
    }

    interface IMusicLibraryVisitor
    {
        void OnHeavyMetal(HeavyMetal input);
        void OnJazz(Jazz input);
    }

    class MusicLibraryVisitor : IMusicLibraryVisitor
    {
        public readonly List<HeavyMetal> HeavyMetal = new List<HeavyMetal>();
        public readonly List<Jazz> Jazz = new List<Jazz>();

        public void OnHeavyMetal(HeavyMetal input)
        {
            this.HeavyMetal.Add(input);
        }

        public void OnJazz(Jazz input)
        {
            this.Jazz.Add(input);
        }
    }

    class Jazz : ISong
    {
        public void Visit(IMusicLibraryVisitor visitor)
        {
            visitor.OnJazz(this);
        }
    }

    class HeavyMetal : ISong
    {
        public void Visit(IMusicLibraryVisitor visitor)
        {
            visitor.OnHeavyMetal(this);
        }
    }
}
