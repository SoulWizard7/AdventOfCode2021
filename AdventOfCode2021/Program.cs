using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Day4Puzzle1();
        }

        private static void Day4Puzzle1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day4_BingoNrs.txt");
            string bingoline = lines[0];
            char comma = ',';
            string[] bingoNrs = bingoline.Split(comma);
            int[] bingoNrsAsInt = new int[bingoNrs.Length];
            for (int i = 0; i < bingoNrs.Length; i++)
            {
                int numVal = Convert.ToInt32(bingoNrs[i]);
                bingoNrsAsInt[i] = numVal;
                //Console.WriteLine(bingoNrsAsInt[i]);
            }

            List<int> tablesNrs = new List<int>();
            
            char space = ' ';

            for (int i = 1; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(space);
                for (int j = 0; j < temp.Length; j++)
                {
                    int numVal;
                    if(int.TryParse(temp[j], out numVal)) tablesNrs.Add(numVal);
                }
            }

            List<Board> boards = new List<Board>();
            int add = 0;

            for (int i = 0; i < 100; i++)
            {
                Board newBoard = new Board();

                for (int j = 0; j < 25; j++)
                {
                    newBoard.nodes.Add(new Node());
                }
                
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int yes = x + (y * 5);
                        
                        newBoard.nodes[yes].x = x;
                        newBoard.nodes[yes].y = y;
                        newBoard.nodes[yes].value = tablesNrs[add];
                        add++;
                    }
                }
                
                boards.Add(newBoard);
            }

            int iteration = 1;


            foreach (var nr in bingoNrsAsInt)
            {
                for (int board = 0; board < boards.Count; board++)
                {
                    for (int node = 0; node < 25; node++) //for each node
                    {
                        if (nr == boards[board].nodes[node].value)
                        {
                            boards[board].nodes[node].isMarked = true;
                        }
                    }

                    int hits = 0;


                    for (int row = 0; row < 5; row++)
                    {
                        for (int node = 0; node < 25; node++) //for each node
                        {
                            if (boards[board].nodes[node].x == row)
                            {
                                if (boards[board].nodes[node].isMarked) hits++;
                                else
                                {
                                    hits = 0;
                                    break;
                                }
                            }
                        }
                        
                        if (hits == 5)
                        {
                            int bingoNr = nr;
                            int winBoard = board;
                            Console.WriteLine("win on board: " + winBoard);
                            Console.WriteLine("winning nr: " + bingoNr);
                            Console.WriteLine("iteration: " + iteration);
                            
                            for (int i = 0; i < boards[board].nodes.Count; i++)
                            {
                                Console.WriteLine(boards[board].nodes[i].value);
                            }
                            Console.ReadKey();
                        }
                        hits = 0;
                        
                        
                        
                        for (int node = 0; node < 25; node++) //for each node
                        {
                            if (boards[board].nodes[node].y == row)
                            {
                                if (boards[board].nodes[node].isMarked) hits++;
                                else
                                {
                                    hits = 0;
                                    break;
                                }
                            }
                        }
                        if (hits == 5)
                        {
                            int bingoNr = nr;
                            int winBoard = board;
                            Console.WriteLine("win on board: " + winBoard);
                            Console.WriteLine("winning nr: " + bingoNr);
                            Console.WriteLine("iteration: " + iteration);
                            
                            for (int i = 0; i < boards[board].nodes.Count; i++)
                            {
                                Console.WriteLine(boards[board].nodes[i].value);
                            }
                            Console.ReadKey();
                        }
                        hits = 0;
                    }
                }
                iteration++;
            }
        }
        
        public class Node
        {
            public int x;
            public int y;
            public int value;
            public bool isMarked;
        }
        
        public class Board
        {
            public List<Node> nodes = new List<Node>();
        }

        private static void Day3Puzzle2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day3_input.txt");

            // gamma
            
            List<string> linesToKeep = new List<string>();

            foreach (var line in lines)
            {
                linesToKeep.Add(line);
            }

            int iteration = 1;

            for (int i = 0; i < iteration; i++)
            {
                int zero = 0;
                int one = 0;
                List<string> tempLinesToKeep = new List<string>();
                
                for (int j = 0; j < linesToKeep.Count; j++)
                {
                    if (linesToKeep[j].Substring(i, 1) == "1")
                    {
                        one++;
                    }
                    else
                    {
                        zero++;
                    }
                }
                
                //Console.WriteLine("zero: " + zero + " , one: " + one);

                if (one >= zero)
                {
                    for (int j = 0; j < linesToKeep.Count; j++)
                    {
                        if (linesToKeep[j].Substring(i, 1) == "1")
                        {
                            tempLinesToKeep.Add(linesToKeep[j]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < linesToKeep.Count; j++)
                    {
                        if (linesToKeep[j].Substring(i, 1) == "0")
                        {
                            tempLinesToKeep.Add(linesToKeep[j]);
                        }
                    }
                }

                
                linesToKeep = tempLinesToKeep;
                
                Console.WriteLine(linesToKeep.Count);
                Console.WriteLine("iteration: " + iteration);

                if (linesToKeep.Count != 1)
                {
                    iteration++;
                }
                else
                {
                    Console.WriteLine(linesToKeep[0]);
                }
            }
            
            // Epsilon = otherLinesToKeep

            List<string> otherLinesToKeep = new List<string>();
            iteration = 1;
            
            
            foreach (var line in lines)
            {
                otherLinesToKeep.Add(line);
            }
            
            for (int i = 0; i < iteration; i++)
            {
                int zero = 0;
                int one = 0;
                List<string> tempLinesToKeep = new List<string>();
                
                for (int j = 0; j < otherLinesToKeep.Count; j++)
                {
                    if (otherLinesToKeep[j].Substring(i, 1) == "1")
                    {
                        one++;
                    }
                    else
                    {
                        zero++;
                    }
                }
                
                //Console.WriteLine("zero: " + zero + " , one: " + one);

                if (zero <= one)
                {
                    for (int j = 0; j < otherLinesToKeep.Count; j++)
                    {
                        if (otherLinesToKeep[j].Substring(i, 1) == "0")
                        {
                            tempLinesToKeep.Add(otherLinesToKeep[j]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < otherLinesToKeep.Count; j++)
                    {
                        if (otherLinesToKeep[j].Substring(i, 1) == "1")
                        {
                            tempLinesToKeep.Add(otherLinesToKeep[j]);
                        }
                    }
                }

                otherLinesToKeep = tempLinesToKeep;
                
                Console.WriteLine(otherLinesToKeep.Count);
                Console.WriteLine("iteration: " + iteration);

                if (otherLinesToKeep.Count != 1)
                {
                    iteration++;
                }
                else
                {
                    Console.WriteLine(otherLinesToKeep[0]);
                }
            }
        }
        private static void Day3Puzzle1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day3_input.txt");

            string gammaString = null;
            string epsilonString = null;

            for (int i = 0; i < 12; i++)
            {
                int gammaZero = 0;
                int gammaOne = 0;
                
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j].Substring(i, 1) == "0")
                    {
                        gammaZero++;
                    }
                    if (lines[j].Substring(i, 1) == "1")
                    {
                        gammaOne++;
                    }
                }

                if (gammaZero > gammaOne)
                {
                    gammaString = gammaString + "0";
                    epsilonString = epsilonString + "1";
                }
                else
                {
                    gammaString = gammaString + "1";
                    epsilonString = epsilonString + "0";
                }
            }

            Console.WriteLine(gammaString);
            Console.WriteLine(epsilonString);
        }
        private static void Day2Puzzle2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day2_input.txt");

            
            int aim = 0;
            int depth = 0;
            int horizontalPosition = 0;
            

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Substring(0,1) == "f")
                {
                    string nr = Regex.Match(lines[i], @"\d+").Value;
                    int numVal = Convert.ToInt32(nr);
                    horizontalPosition += numVal;
                    depth += (aim * numVal);
                }
                if (lines[i].Substring(0,1) == "d")
                {
                    string nr = Regex.Match(lines[i], @"\d+").Value;
                    int numVal = Convert.ToInt32(nr);
                    aim += numVal;
                }
                if (lines[i].Substring(0,1) == "u")
                {
                    string nr = Regex.Match(lines[i], @"\d+").Value;
                    int numVal = Convert.ToInt32(nr);
                    aim -= numVal;
                }
            }

            Console.WriteLine(horizontalPosition * depth);
            
            
            
        }
        private static void Day2Puzzle1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day2_input.txt");

            int forward = 0;
            int down = 0;
            int up = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Substring(0,1) == "f")
                {
                    string nr = Regex.Match(lines[i], @"\d+").Value;
                    int numVal = Convert.ToInt32(nr);
                    forward += numVal;
                }
                if (lines[i].Substring(0,1) == "d")
                {
                    string nr = Regex.Match(lines[i], @"\d+").Value;
                    int numVal = Convert.ToInt32(nr);
                    down += numVal;
                }
                if (lines[i].Substring(0,1) == "u")
                {
                    string nr = Regex.Match(lines[i], @"\d+").Value;
                    int numVal = Convert.ToInt32(nr);
                    up += numVal;
                }
            }

            int upAndDown = down - up;
            Console.WriteLine(upAndDown * forward);
        }
        private static void Day1Puzzle1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day1_Puzzle1.txt");

            int[] linesAsInts = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                int numVal = Convert.ToInt32(lines[i]);
                linesAsInts[i] = numVal;
                Console.WriteLine(linesAsInts[i]);
            }

            int timesIncreaced = 0;

            for (int i = 0; i < linesAsInts.Length - 1; i++)
            {
                if (linesAsInts[i + 1] > linesAsInts[i])
                {
                    timesIncreaced++;
                }
            }
            Console.WriteLine(timesIncreaced);
        }
        private static void Day1Puzzle2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day1_Puzzle1.txt");

            int[] linesAsInts = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                int numVal = Convert.ToInt32(lines[i]);
                linesAsInts[i] = numVal;
                //Console.WriteLine(linesAsInts[i]);
            }

            int timesIncreaced = 0;

            for (int i = 0; i < linesAsInts.Length - 3; i++)
            {
                
                int first = linesAsInts[i] + linesAsInts[i+1] + linesAsInts[i+2];
                int second = linesAsInts[i+1] + linesAsInts[i+2] + linesAsInts[i+3];

                if (first < second) timesIncreaced++;
            }
            
            
            Console.WriteLine(timesIncreaced);    
        }
    }
}