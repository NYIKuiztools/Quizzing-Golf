using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Quizzing_Word_Finder
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random();

			//Gets books
			Console.WriteLine("What year are you quizzing?");

#pragma warning disable CS8602 // Dereference of a possibly null reference. // Throws warning, try catch doesn't resolve. Warning is irrelevent. Crashes program. Resolve later.  
            string year = Console.ReadLine().ToLower().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            string path = "C:\\Users\\kaleb\\OneDrive\\Documents\\GitHub\\NYIQuizzingGolf";

			bool cntu;
			string[] uniqueWords = File.ReadAllLines(path + "\\" + year + ".txt");

			GetWords(path + "\\" + year + ".csv");

			bool Cntu = false;

			// Get min Chapter
			Cntu = false;
			int min = 0;
			while (Cntu == false)
			{
				Console.Clear();

				Console.WriteLine("What is the minimum chapter you would like to go over?");
				cntu = false;
				cntu = int.TryParse(Console.ReadLine(), out min);

				if (cntu == true)
				{
					Cntu = true;

				}

			}

			// Get max Chapter
			Cntu = false;            
			int max = 23;
			while (Cntu == false)
			{
			Console.Clear();

				Console.WriteLine("What is the maximum chapter you would like to go over?");
				cntu = false;
				cntu = int.TryParse(Console.ReadLine(), out max);

				if (cntu == true)
				{
					Cntu = true;

				}

			}
			Console.Clear();

			// Gets totalRounds
            Cntu = false;
            int totalRounds = 20; 
            while (Cntu == false)
            {
            Console.Clear();

                Console.WriteLine("How many questions would you like?");
                cntu = false;
                cntu = int.TryParse(Console.ReadLine(), out totalRounds);
                if (cntu == true)
                {
                    Cntu = true;
                }

            }
            Console.Clear();

            bool gameCNTU = true;

			switch (min)
			{
				case 1:
					{
						min = 0; break;
					}
				case 2:
					{
						min = 69; break;
					}
				case 3:
					{
						min = 116; break;
					}
				case 4:
					{
						min = 216; break;
					}
				case 5:
					{
						min = 260; break;
					}
				case 6:
					{
						min = 287; break;
					}
				case 7:
					{
						min = 343; break;
					}
				case 8:
					{
						min = 379; break;
					}
				case 9:
					{
						min = 442; break;
					}
				case 10:
					{
						min = 490; break;
					}
				case 11:
					{
						min = 528; break;
					}
				case 12:
					{
						min = 598; break;
					}
				case 13:
					{
						min = 676; break;
					}
				case 14:
					{
						min = 175; break;
					}
				case 15:
					{
						min = 751; break;
					}
				case 16:
					{
						min = 779; break;
					}
				case 17:
					{
						min = 826; break;
					}
				case 18:
					{
						min = 853; break;
					}
				case 19:
					{
						min = 884; break;
					}
				case 20:
					{
						min = 914; break;
					}
				case 21:
					{
						min = 955; break;
					}
				case 22:
					{
						min = 1006; break;
					}
				case 23:
					{
						min = 1066; break;
					}
				case 24:
					{
						min = 1138; break;
					}
				default:
					{
						min = 0; break;
					}

			} // Fixes min Chapter
			switch (max)
			{
				case 1:
					{
						max = 68; break;
					}
				case 2:
					{
						max = 117; break;
					}
				case 3:
					{
						max = 215; break;
					}
				case 4:
					{
						max = 259; break;
					}
				case 5:
					{
						max = 288; break;
					}
				case 6:
					{
						max = 342; break;
					}
				case 7:
					{
						max = 378; break;
					}
				case 8:
					{
						max = 441; break;
					}
				case 9:
					{
						max = 489; break;
					}
				case 10:
					{
						max = 527; break;
					}
				case 11:
					{
						max = 597; break;
					}
				case 12:
					{
						max = 675; break;
					}
				case 13:
					{
						max = 714; break;
					}
				case 14:
					{
						max = 750; break;
					}
				case 15:
					{
						max = 778; break;
					}
				case 16:
					{
						max = 825; break;
					}
				case 17:
					{
						max = 852; break;
					}
				case 18:
					{
						max = 883; break;
					}
				case 19:
					{
						max = 913; break;
					}
				case 20:
					{
						max = 954; break;
					}
				case 21:
					{
						max = 1005; break;
					}
				case 22:
					{
						max = 1065; break;
					}
				case 23:
					{
						max = 1137; break;
					}
				case 24:
					{
						max = 1170; break;
					}
				default:
					{
						max = 1170; break;
					}

			} // Fixes max Chapter

            // Establishes variables for game
            int index, guessChapter, guessVerse, refrenceChapter, refrenceVerse;
			int points = 0;
			int round = 0;
			int i;
			int errors = 0;
			string line, word, guess;

			string[] score = new string[totalRounds];
			
			
			while (gameCNTU == true)
			{
				index = rand.Next(min, max);
				if (round == totalRounds) { break; }
				

				//Gets word and Refrence
				line = uniqueWords[index];

				word = line.Split('*')[0];
				refrenceChapter = Convert.ToInt32((line.Split('*')[1]).Split(':')[0]);
				refrenceVerse = Convert.ToInt32((line.Split('*')[1]).Split(':')[1]);

				// Gets guess
				Console.WriteLine(word);
#pragma warning disable CS8602 // Dereference of a possibly null reference. // Throws warning, try catch doesn't resolve. Warning is irrelevent. Crashes program. 
                guess = Console.ReadLine().Trim().ToLower();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                if (guess == "stop") { break; } // Provides way to skip the rest of the rounds.
				//Converts guess to int
				try
				{
					guessChapter = Convert.ToInt32(guess.Split(':')[0]);
					guessVerse = Convert.ToInt32(guess.Split(':')[1]);
					errors = 0;
				}
				catch
				{
					
					Console.WriteLine("Something went wrong."); // Error message
					Console.WriteLine();
					// Prints score as ussual
					i = 0;
					while (i <= round)
					{
						Console.WriteLine(score[i]);
						i++;
					}
					Console.WriteLine();
					Console.WriteLine("You have " + points + " points.");
					Console.WriteLine("Press any key to continue.");
					Console.ReadLine();
					Console.Clear();
					// Ignors round, updates errors to prevent redoing normal rounds.
					errors++;
					if (errors >= 2)
					{
						round++;
					}
					round--;
					continue;
				}
				//Gives points
				if (guessChapter == refrenceChapter)
				{
					if (guessVerse == refrenceVerse)
					{
						points = points + 0;
						score[round] = (round + 1) + ": 0";
					}
					if (guessVerse > refrenceVerse)
					{
						points = points + (guessVerse - refrenceVerse);
						score[round] = (round + 1) + ": " + Convert.ToString(guessVerse - refrenceVerse);
						Console.WriteLine("It was in " + year + " " + refrenceChapter + ":" + refrenceVerse + ".");
					}
					if (guessVerse < refrenceVerse)
					{
						points = points + (refrenceVerse - guessVerse);
						score[round] = (round + 1) + ": " + Convert.ToString(refrenceVerse - guessVerse);
						Console.WriteLine("It was in " + year + " " + refrenceChapter + ":" + refrenceVerse + ".");
					}
				}
				else
				{
					score[round] = "x";
					Console.WriteLine("It was in " + year + " " + refrenceChapter + ":" + refrenceVerse + ".");
				}
                i = 0;
                while (i <= round)
                {
                    Console.WriteLine(score[i]);
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine("You have " + points + " points.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                Console.Clear();
				round++;
            }

			Console.Clear();

			// Prints score after Game ends
			Console.WriteLine("You got " + points + ".");		

			Console.WriteLine();
			Console.WriteLine("Here is your score card: ");

			// Prints Score Card
			i = 0;
			while (i <= round - 1)
			{
				Console.Write(score[i]);
				i++;
				Console.WriteLine();
			}
		}

		static string[] GetWords(string path){

			int LinesAmt = (File.ReadAllLines(path)).Length; // Loads all lines from file into array Lines

			// Loads all lines into string[] lines
			string[] lines = new string[LinesAmt];
			lines = File.ReadAllLines(path);

			// Splits 'lines' into string[][] file
			string[][] file = new string[LinesAmt][];
			for(int i = 0; i < LinesAmt; i++) {
				file[i] = lines[i].Split(',');
				Console.WriteLine(file[i][0], ",",file[i][1], ",",file[i][2], ",",file[i][3], ",",file[i][4]);
			}
			Console.ReadLine();
// FIXME Reading past first col in csv file in GetWords Method
			return null;
		}
	}
}

// TODO Create question work on tracking system
// FIXME Question asking into meathods
// TODO Add Ranking System
// TODO Add option for section headers