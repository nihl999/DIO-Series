using System;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        static RepositorySeries globalSeriesRepository = new RepositorySeries();
        static void Main(string[] args)
        { 
            string userOption = ProcessUserInput().ToUpper();
            while(userOption != "X")
            {
                switch(userOption)
                {
                    case "1":
                    {
                        ListSeries();
                    }break;
                    case "2":
                    {
                        InsertSerie();
                    }break;
                    case "3":
                    {
                        UpdateSerie();
                    }break;
                    case "4":
                    {
                        RemoveSerie();
                    }break;
                    case "5":
                    {
                        ViewSerie();
                    }break;
                    case "C":
                    {
                        Console.Clear();
                    }break;
                    default:
                    {
                        Console.WriteLine("Invalid option: {0}", userOption);
                    }break;
                }
            }
        }


        private static string ProcessUserInput()
        {
            string userOpt = "";
            Console.WriteLine();
			Console.WriteLine("NIHILO Series Service");
			Console.WriteLine("Answer the desired operation: ");

			Console.WriteLine("1- List all series");
			Console.WriteLine("2- Insert a new serie");
			Console.WriteLine("3- Update one serie");
			Console.WriteLine("4- Remove one serie from catalog");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Clean window");
			Console.WriteLine("X- Close app");
			Console.WriteLine();

			userOpt = Console.ReadLine().ToUpper();
			Console.WriteLine();
            return userOpt;
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listing series: ");

            List<Serie> seriesList = globalSeriesRepository.List();
            if (seriesList.Count == 0)
            {
                Console.WriteLine("No series was catalogued. ");
                return;
            }
            foreach(Serie serie in seriesList)
            {
                if(serie.Excluded)
                    continue;
                Console.WriteLine("#ID {0}: {1}", serie.GetId(), serie.GetTitle());
            }
        }
    
        private static void InsertSerie()
		{
			Console.WriteLine("Inserting a serie: ");
			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Select a genre from above options: ");
			Genre serieGenre = (Genre)int.Parse(Console.ReadLine());

			Console.Write("Insert the serie title: ");
			string serieTitle = Console.ReadLine();

			Console.Write("Insert serie debut year: ");
			int serieDebutYear = int.Parse(Console.ReadLine());
			
            Console.Write("Insert serie description: ");
			string serieDescription = Console.ReadLine();

			Serie returnSerie = new Serie(id: globalSeriesRepository.NextId(),
										genre: serieGenre,
										title: serieTitle,
										year: serieDebutYear,
										description: serieDescription);

			globalSeriesRepository.Insert(returnSerie);
		}
        private static void UpdateSerie()
        {
            Console.Write("Insert serie id: ");
			int serieID = int.Parse(Console.ReadLine());
            if(globalSeriesRepository.ReturnById(serieID) == null)
            {
                Console.WriteLine("Inexistent serie with ID: {0}", serieID);
                return;
            }

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			Console.Write("Select a genre from above options: ");
			Genre serieGenre = (Genre)int.Parse(Console.ReadLine());

			Console.Write("Insert the serie title: ");
			string serieTitle = Console.ReadLine();

			Console.Write("Insert serie debut year: ");
			int serieDebutYear = int.Parse(Console.ReadLine());
			
            Console.Write("Insert serie description: ");
			string serieDescription = Console.ReadLine();

			Serie returnSerie = new Serie(id: serieID,
										genre: serieGenre,
										title: serieTitle,
										year: serieDebutYear,
										description: serieDescription);

			globalSeriesRepository.Update(serieID, returnSerie);
        }
        public static void RemoveSerie()
        {
            Console.WriteLine("Insert serie id: ");
			int serieID = int.Parse(Console.ReadLine());
            if(globalSeriesRepository.ReturnById(serieID) == null)
            {
                Console.WriteLine("Inexistent serie with ID: {0}", serieID);
                return;
            }
            Console.WriteLine("Are you sure? Y / N");
            string confirmation = Console.ReadLine().ToUpper();
            if(confirmation == "N")
                return;
			globalSeriesRepository.Exclude(serieID);
        }
        public static void ViewSerie()
        {
            Console.Write("Inset serie id: ");
			int serieID = int.Parse(Console.ReadLine());
            if(globalSeriesRepository.ReturnById(serieID) == null)
            {
                Console.WriteLine("Inexistent serie with ID: {0}", serieID);
                return;
            }
			Serie serie = globalSeriesRepository.ReturnById(serieID);

			Console.WriteLine(serie.ToString());
		}
        
    }
}