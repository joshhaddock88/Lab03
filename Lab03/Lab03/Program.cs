using System;
using System.IO;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChallengeOne();
            //ChallengeTwo();
            //ChallengeThree();
            //int[] inputArray = { 3,2,3,5,45,7,43,3 };
            //ChallengeFour(inputArray);
            //int[] myArray = { 2, 45, 55, 3, 555, 26 };
            //ChallengeFive(myArray);
            string docPath = "../../../words.txt";
            //ChallengeSix(docPath);
            //ChallengeSeven(docPath);
            ChallengeEight(docPath);
            //ChallengeNine();
        }

        static void ChallengeOne()
        {
            Console.WriteLine("Please enter 3 numbers: ");
            string userInput = Console.ReadLine();
            string[] userArray = userInput.Split(' ');
            int product = 1;
            if (userArray.Length == 3)
            {
                foreach (string item in userArray)
                {
                    product *= Convert.ToInt32(item);
                }
            }
            if (userArray.Length > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    product *= Convert.ToInt32(userArray[i]);
                }
            }
            if (userArray.Length < 3)
            {
                product = 0;
            }
            Console.WriteLine($"Product is {product}");
        }

        static void ChallengeTwo()
        {
            Console.WriteLine("Please enter a number between 2 and 10");
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                int total = 0;
                while (userInput > 10 || userInput < 2)
                {
                    Console.WriteLine("Number out of range, try again");
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                for (int i = 0; i < userInput; i++)
                {
                    Console.WriteLine($"Please choose a random number {i + 1} / {userInput}");
                    total += Convert.ToInt32(Console.ReadLine());
                }
                int average = total / userInput;
                Console.WriteLine($"The average of your chosen number is: {average}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ChallengeTwo();
            }
        }

        static void ChallengeThree()
        {
            Console.WriteLine(
                "    *\n" +
                "   ***\n" +
                "  *****\n" +
                " *******\n" +
                "*********\n" +
                " *******\n" +
                "  *****\n" +
                "   ***\n" +
                "    *\n"
                );
        }

        public static int ChallengeFour(int[] arr)
        {
            int[] answerArray = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int answer = 0
                ;
            for (int i = 0; i < arr.Length; i++)
            {
                answerArray[arr[i]]++;
            }
            for (int i = 1; i < answerArray.Length; i++)
            {
                if (answerArray[i] > answerArray[i - 1])
                {
                    answer = i;
                }
            }
            Console.WriteLine(answer);
            Console.ReadLine();
            return answer;
        }

        static void ChallengeFive(int[] array)
        {
            int maxValue = array[0];
            foreach(int item in array)
            {
                if(item > maxValue)
                {
                    maxValue = item;
                }
            }
            Console.WriteLine($"{maxValue}");
        }

        static void ChallengeSix(string file)
        {
            Console.WriteLine("Please enter a word or phrase to enter into the words.txt documnet");
            string phrase = Console.ReadLine();
            File.AppendAllText(file, phrase);
        }

        static void ChallengeSeven(string file)
        {
            string myFileContents = File.ReadAllText(file);
            Console.WriteLine(myFileContents);
        }

        public static void ChallengeEight(string file)
        {
            string fileText = File.ReadAllText(file);
            string[] words = fileText.Split(' ');
            Console.WriteLine("Type a word to remove");
            string badWord = Console.ReadLine();
            for (int i = 0; i < words.GetLength(0); i++)
            {
                if (words[i] == badWord)
                {
                    words[i] = "";
                }
            }
            string newText = String.Join(' ', words);
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    try
                    {
                        sw.Write(newText);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void ChallengeNine()
        {
            Console.WriteLine("Please write a sentence with no punctuation");
            string userInput = Console.ReadLine();
            string[] inputArray = userInput.Split(" ");
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = inputArray[i] + ": " + inputArray[i].Length.ToString();
                Console.WriteLine(inputArray[i]);
            }
        }
    }
}
