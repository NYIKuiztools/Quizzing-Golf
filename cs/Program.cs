namespace QuizzingGolf
{
	internal class Program
	{
		public static int totalWords = 0;
		static void Main( string[] args)
		{
			Random rand = new Random();

			//Gets books
			Console.WriteLine("What year are you quizzing?");

			string year = Console.ReadLine().ToLower().Trim();
			string path = "..\\..\\..\\..\\";

			bool cntu;
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

			string[][] cards = GetWords(path + "\\" + year + ".csv", "single", min, max);

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

			// Establishes variables for game
			int index, guessChapter, guessVerse, refrenceChapter, firstVerse, secondVerse, thirdVerse;
			int points = 0;
			int round = 0;
			int i;
			int errors = 0;
			string[] line = new string[5];
			string word, guess;

			string[] score = new string[totalRounds];

			
			while (gameCNTU == true)
			{
				index = rand.Next(0, totalWords);
				if (round == totalRounds) { break; }


				//Gets word and Refrence
				line = cards[index];

				word = line[1];
				Console.Clear();
				refrenceChapter = Convert.ToInt32(line[2]);

				firstVerse = Convert.ToInt32(line[3]);
				try
				{
					secondVerse = Convert.ToInt32(line[4]);
				}
				catch (FormatException)
				{
					secondVerse = 0;
				}
				catch (IndexOutOfRangeException)
				{
					secondVerse = 0;
				}

				try
				{
					thirdVerse = Convert.ToInt32(line[5]);
				}
				catch (FormatException)
				{
					thirdVerse = 0;
				}
				catch (IndexOutOfRangeException)
				{
					thirdVerse = 0;
				}

				// Gets guess
				Console.WriteLine(word);
				guess = Console.ReadLine().Trim().ToLower();

				if (guess == "stop!") { break; } // Provides way to skip the rest of the rounds.
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
					if (guessVerse == firstVerse)
					{
						points = points + 0;
						score[round] = (round + 1) + ": 0";
					}
					if (guessVerse > firstVerse)
					{
						points = points + (guessVerse - firstVerse);
						score[round] = (round + 1) + ": " + Convert.ToString(guessVerse - firstVerse);
						Console.WriteLine("It was in " + year + " " + refrenceChapter + ":" + firstVerse + ".");
					}
					if (guessVerse < firstVerse)
					{
						points = points + (firstVerse - guessVerse);
						score[round] = (round + 1) + ": " + Convert.ToString(firstVerse - guessVerse);
						Console.WriteLine("It was in " + year + " " + refrenceChapter + ":" + firstVerse + ".");
					}
				}
				else
				{
					score[round] = "x";
					Console.WriteLine("It was in " + year + " " + refrenceChapter + ":" + firstVerse + ".");
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

			// Prints Scorecard
			i = 0;
			while (i <= round - 1)
			{
				Console.Write(score[i]);
				i++;
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine("Press any key to close.");
			Console.ReadLine();
			Console.Clear();
		}

		static string[][] GetWords(string path, string type, int minChapter, int maxChapter)
		{

			int LinesAmt = File.ReadAllLines(path).Length; // Loads all lines from file into array Lines

			// Loads all lines into string[] lines
			string[] lines = new string[LinesAmt];
			lines = File.ReadAllLines(path);

			// Splits 'lines' into string[][] file
			// - and + 1 are to remove header row from year.csv
			string[][] file = new string[LinesAmt][];
			for (int i = 0; i < LinesAmt - 1; i++)
			{
				file[i] = lines[i + 1].Split(',');
			}

			// Gets the number of times type is equal to type in file[][0]
			int typeAmt = 0;

			for (int i = 0; i < LinesAmt - 1; i++)
			{
				if (file[i][0] == type)
				{
					typeAmt++;
				}
			}

			// Gets all words of a certain type in file[][0]
			string[][] allWords = new string[typeAmt][];
			int iteration = 0;

			for (int i = 0; i < LinesAmt - 1; i++)
			{
				if (file[i][0] == type)
				{
					allWords[iteration] = file[i];
					iteration++;
				}
			}
			// Gets all needed words in allWords[][2]
			int rangeAmt = 0;

			for (int i = 0; i < allWords.Length; i++)
			{
				if (Convert.ToInt32(file[i][2]) >= minChapter && Convert.ToInt32(file[i][2]) <= maxChapter)
				{
					rangeAmt++;
				}
			}


			string[][] neededWords = new string[rangeAmt][];
			iteration = 0;

			for (int i = 0; i < allWords.Length; i++)
			{
				if (Convert.ToInt32(file[i][2]) >= minChapter && Convert.ToInt32(file[i][2]) <= maxChapter)
				{
					neededWords[iteration] = allWords[i];
					iteration++;
				}
			}
			totalWords = rangeAmt;

			return neededWords;
		}
	}
}