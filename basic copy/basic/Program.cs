
internal class Program
{
    static Random R = new();
    static int[] oddSum = { 3, 5, 7, 9, 11 };
    static int[] evenSum = { 2, 4, 6, 8, 10, 12 };
    static int myPoint = 0;
    static int pcPoint = 0;
    static string input = "input.txt";
    static string output = "output.txt";
    static void sayHello()
    {
        WriteInFile(
            "\tBOBSTONES\n" +
            "\tCREATIVE COMPUTING\n" +
            "\tMORRISTOWN, NEW JERSEY" +
            "\n\n\n" +
            "    THIS IS A NUMBER GAME CALLED BOBSTONES.  THE OBJECT OF\n" +
            "BOBSTONES IS TO GUESS THREE THINGS ABOUT THE ROLL OF A PAIR\n" +
            "OF DICE.  ON EACH TURN, THE COMPUTER SIMULATES THE ROLL OF\n" +
            "THE DICE.  THEN, YOU OR THE COMPUTER (YOUR OPPONENT) GUESS\n" +
            "\n" +
            "                                                     SCORE\n" +
            " 1. IF THE SUM OF THE DICE IS ODD OR EVEN           1 POINT\n" +
            " 2. THE SUM OF THE DICE                             2 POINTS\n" +
            " 3. THE NUMBER ON EACH OF THE TWO DICE              3 POINTS\n" +
            "\n" +
            "    THE WINNER IS THE FIRST PLAYER TO SCORE 11 POINTS.  IF A\n" +
            "TIE RESULTS, THE WINNER IS THE FIRST PLAYER TO BREAK THE TIE.\n" +
            "    GOOD LUCK !\n"
            );
    }
    static string OoE()
    {
        while (true)
        {
           // Console.Write("IS THE SUM ODD OR EVEN? ");
            WriteInFile("IS THE SUM ODD OR EVEN?\n");
            switch (GetCommandFromFile())
            {
                case "ODD":
                    return "ODD";
                case "EVEN":
                    return "EVEN";
                default:
                    //Console.WriteLine("/// TYPE THE WORD 'ODD' OR THE WORD 'EVEN'.");
                    WriteInFile("/// TYPE THE WORD 'ODD' OR THE WORD 'EVEN'.\n");
                    break;
            }
        }
    }
    static int NowSum()
    {
        while (true)
        {
            //Console.Write("NOW, GUESS THE SUM ");
            WriteInFile("NOW, GUESS THE SUM\n");
            try
            {
                int sum = Convert.ToInt32(GetCommandFromFile());
                if (sum >= 2 && sum < 13)
                {
                    return sum;
                }
                else
                {
                    WriteInFile("INCORRECT INPUT\n");
                }
            }
            catch
            {
               WriteInFile("INCORRECT INPUT\n");
            }
        }
    }
    static (int, int) WTN()
    {
        while (true)
        {
            WriteInFile("WHAT ARE THE TWO NUMBERS WHICH PRODUCED \n");
            string ansver = GetCommandFromFile();
            string[] strings = ansver.Split(new char[] { ',', '.', ' ' });
            if (strings.Length == 2)
            {
                try
                {
                    return (Convert.ToInt32(strings[0]), Convert.ToInt32(strings[1]));
                }
                catch
                {
                    WriteInFile("/// THE NUMBERS MUST BE BETWEEN 1 AND 6.\n");
                }
            }
            else
            {
                WriteInFile("/// THE NUMBERS MUST BE BETWEEN 1 AND 6.\n");
            }
        }
    }
    static bool RoW()
    {
        while (true)
        {
            WriteInFile("AM I RIGHT OR WRONG \n");
            switch (GetCommandFromFile())
            {
                case "RIGHT":
                    return true;
                case "WRONG":
                    return false;
                default:
                    WriteInFile("/// TYPE THE WORD 'RIGHT' OR THE WORD 'WRONG'.\n");
                    break;
            }
        }
    }
    static bool YoN()
    {
        while (true)
        {
            switch (GetCommandFromFile())
            {
                case "YES":
                    return true;
                case "NO":
                    return false;
                default:
                    WriteInFile("/// TYPE THE WORD 'YES' OR THE WORD 'NO'.\n");
                    break;
            }
        }
    }
    static (int, int) Random()
    {
        return (R.Next(1, 7), R.Next(1, 7));
    }
    static string HowStart()
    {
        while (true)
        {
            WriteInFile("\nYOU FIRST OR ME \n");
            switch (GetCommandFromFile())
            {
                case "YOU":
                    Console.WriteLine();
                    return "PC";
                case "ME":
                    Console.WriteLine();
                    return "ME";
                default:
                    WriteInFile("/// TYPE THE WORD 'YOU' OR THE WORD 'ME'.\n");
                    break;
            }
        }
    }
    static bool loop = true;
    static void printPoint()
    {
        if (myPoint < 11 && pcPoint < 11)
        {
            WriteInFile($"\nTHE SCORE IS ME {pcPoint} - YOU {myPoint}.\n");
        }
        else if (myPoint >= 11)
        {
            WriteInFile($"\nTHE SCORE IS ME {pcPoint} - YOU {myPoint}.\n");
            WriteInFile("YOU WIN! ANOTHER GAME \n");
            bool ansver = YoN();
            if (ansver == true)
            {
                myPoint = 0;
                pcPoint = 0;
                StartGame(HowStart());
            }
            else
            {
                loop = false;
                WriteInFile("SEE YOU LATER.\n");
            }
        }
        else if(pcPoint >= 11)
        {
            WriteInFile($"\nTHE SCORE IS ME {pcPoint} - YOU {myPoint}.\n");
            WriteInFile("I WIN! ANOTHER GAME \n");
            bool ansver = YoN();
            if (ansver == true)
            {
                myPoint = 0;
                pcPoint = 0;
                StartGame(HowStart());
            }
            else
            {
                loop = false;
                WriteInFile("SEE YOU LATER.\n");
            }

        }
       
    }
    static void StartGame(string _who)
    {
        string who = _who;

            while (loop)
            {
                int D1, D2;
                (D1, D2) = Random();
                if (who == "ME")
                {

                    WriteInFile("YOUR TURN.\n");
                    string ansver = OoE();
                    if ((ansver == "ODD" && (D1 + D2) % 2 != 0) ||
                        (ansver == "EVEN" && (D1 + D2) % 2 == 0))
                    {
                        WriteInFile("YOU ARE CORRECT.\n");
                        myPoint += 1;
                    }
                    else
                    {
                        who = "PC";
                        WriteInFile($"SORRY, THE SUM IS {D1 + D2}\n");
                        printPoint();
                        continue;
                    }
                    if (D1 + D2 == NowSum())
                    {
                        myPoint += 1;
                        WriteInFile("YOU ARE CORRECT.\n");
                    }
                    else
                    {
                        who = "PC";
                        WriteInFile($"SORRY, THE SUM IS {D1 + D2}\n");
                        printPoint();
                        continue;
                    }
                    int D1A, D2A;
                    (D1A, D2A) = WTN();
                    if ((D1A, D2A) == (D1, D2) || (D1A, D2A) == (D2, D1))
                    {
                        myPoint += 1;
                        WriteInFile("YOU ARE CORRECT.\n");
                        who = "PC";
                        printPoint();
                        continue;
                    }
                    else
                    {
                        who = "PC";
                        WriteInFile($"SORRY, THE NUMBERS ARE {D1} AND {D2} .\n");
                        printPoint();
                        continue;
                    }

                }
                else if (who == "PC")
                {
                    WriteInFile("MY TURN.\n" +
                        $"*** ON THIS ROLL OF THE DICE, THE TWO NUMBERS ARE {D1} AND {D2} .\n" +
                        $"*** THE SUM IS {D1 + D2}\n");
                    int OoE = R.Next(1, 3);
                    if (OoE == 1)
                    {
                        WriteInFile("MY GUESS IS THAT THE SUM IS ODD.\n");
                    }
                    else
                    {
                        WriteInFile("MY GUESS IS THAT THE SUM IS EVEN.\n");
                    }
                    if (!RoW())
                    {
                        who = "ME";
                        printPoint();
                        continue;
                    }
                    pcPoint += 1;
                    int sum;
                    if (OoE == 1)
                    {
                        sum = oddSum[R.Next(0, 5)];
                    }
                    else
                    {
                        sum = evenSum[R.Next(0, 6)];
                    }
                    WriteInFile($"MY GUESS OF THE SUM IS {sum}\n");
                    if (!RoW())
                    {
                        who = "ME";
                        printPoint();
                        continue;
                    }
                    pcPoint += 1;
                    if (sum > 6)
                    {
                        D1 = R.Next(1, 7);
                        D2 = sum - D1;
                    }
                    else
                    {
                        D1 = R.Next(1, sum);
                        D2 = sum - D1;
                    }
                    WriteInFile($"MY GUESS IS THAT THE NUMBERS ARE {D1} AND {D2} \n");
                    if (!RoW())
                    {
                        who = "ME";
                        printPoint();
                        continue;
                    }
                    pcPoint += 1;
                    who = "ME";
                    printPoint();
                }
            }
    }
    private static void Main(string[] args)
    {

        sayHello();
        Console.WriteLine("GAME START. CHECK BROWSER.");
        StartGame(HowStart());
        ClearFile(output);
        ClearFile(input);
        Console.WriteLine("FILES IS CLEAR.\n///PRESS ANY KEY FOR EXIT...///");
    }




    //мост для веб приолжения

    private static void WriteInFile(string contain)
    {
        while (true) 
        {
            try
            {
                File.AppendAllText(output, contain);
                return;
            }
            catch (System.IO.IOException)
            {
                
            }
          
        }
    }
    private static string GetCommandFromFile()
    {
        string rt = " ";
        while (true)
        {
            if(InputIsEmpty() == false)
            {
                rt =  File.ReadAllText(input);
                ClearFile(input);
                return rt;
            }
        }
    }
    private static void ClearFile(string f)
    {
        while (true)
        {
            try
            {
                File.WriteAllText(f, String.Empty);
                return;
            }
            catch (System.IO.IOException)
            {

            }
        }
    }
    private static bool InputIsEmpty()
    {
        try
        {
            return File.ReadAllText(input) == String.Empty;
        }
        catch (System.IO.IOException)
        {
            return true;
        }
    }
    
}