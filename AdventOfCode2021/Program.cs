using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    public static class Extensions
    {
        public static string Filter(this string str, List<char> charsToRemove)
        {
            charsToRemove.ForEach(c => str = str.Replace(c.ToString(), String.Empty));
            return str;
        }

        public static string OutputComparison(string output, string input, string nr)
        {
            string temp = output;
            int count = 0;
            if (input.Length == output.Length)
            {
                List<char> compare = new List<char>(input.ToCharArray());

                for (int l = 0; l < compare.Count; l++)
                {
                    if (output.Contains(compare[l])) count++;
                }
                //Console.WriteLine(count);
                if (count == output.Length)
                {
                    return nr;
                }
                else return temp;
            }
            return temp;
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Day12Puzzle1();
        }

        private static void Day12Puzzle1()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day12_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day12_Input.txt");



        }

        private static void Day11Puzzle2()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day11_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day11_Input.txt");

            int[,] grid = new int[10, 10];

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    grid[x, y] = Convert.ToInt32(lines[x].Substring(y, 1));
                }
            }

            int stepNr = 1;

            for (int i = 0; i < stepNr; i++)
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        grid[x, y] += 1;
                    }
                }

                List<(int, int)> gridPos = new List<(int, int)>();
                int iteration = 2;

                for (int j = 0; j < iteration; j++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (grid[x, y] > 9)
                            {
                                var gridValue = (x, y);
                                if (!gridPos.Contains(gridValue))
                                {
                                    gridPos.Add(gridValue);
                                    iteration++;

                                    if (x - 1 >= 0 && y - 1 >= 0) grid[x - 1, y - 1]++;
                                    if (y - 1 >= 0) grid[x, y - 1]++;
                                    if (y - 1 >= 0 && x + 1 < 10) grid[x + 1, y - 1]++;

                                    if (x - 1 >= 0) grid[x - 1, y]++;
                                    if (x + 1 < 10) grid[x + 1, y]++;

                                    if (x - 1 >= 0 && y + 1 < 10) grid[x - 1, y + 1]++;
                                    if (y + 1 < 10) grid[x, y + 1]++;
                                    if (x + 1 < 10 && y + 1 < 10) grid[x + 1, y + 1]++;
                                }
                            }
                        }
                    }
                }
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (grid[x, y] > 9)
                        {
                            grid[x, y] = 0;
                        }
                    }
                }

                if (gridPos.Count == 100)
                {                    
                    Console.WriteLine("step: " + stepNr);
                    Console.WriteLine("");
                }
                else stepNr++;
                //end of loop
            }
        }

        private static void Day11Puzzle1()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day11_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day11_Input.txt");

            int[,] grid = new int[10, 10];

            int flashes = 0;

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    grid[x, y] = Convert.ToInt32(lines[x].Substring(y, 1));
                }
            }

            for (int i = 0; i < 100; i++)
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        grid[x, y] += 1;
                    }
                }

                List<(int, int)> gridPos = new List<(int, int)>();
                int iteration = 2;

                for (int j = 0; j < iteration; j++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (grid[x, y] > 9)
                            {
                                var gridValue = (x, y);
                                if (!gridPos.Contains(gridValue))
                                {
                                    gridPos.Add(gridValue);
                                    iteration++;

                                    if (x - 1 >= 0 && y - 1 >= 0)       grid[x - 1, y - 1]++;
                                    if (y - 1 >= 0)                     grid[x, y - 1]++;
                                    if (y - 1 >= 0 && x + 1 < 10)       grid[x + 1, y - 1]++;

                                    if (x - 1 >= 0)                     grid[x - 1, y]++;
                                    if (x + 1 < 10)                     grid[x + 1, y]++;

                                    if (x - 1 >= 0 && y + 1 < 10)       grid[x - 1, y + 1]++;
                                    if (y + 1 < 10)                     grid[x, y + 1]++;
                                    if (x + 1 < 10 && y + 1 < 10)       grid[x + 1, y + 1]++;
                                }
                            }
                        }
                    }
                }

                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (grid[x, y] > 9)
                        {
                            grid[x, y] = 0;
                        }
                    }
                }
                flashes += gridPos.Count;
                //end of loop
            }
            Console.WriteLine("total flashes: " + flashes);
        }

        private static void Day9Puzzle2()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day9_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day9_Input.txt");

            int columnLenght = 0;
            for (int i = 0; i < lines[0].Length; i++)
            {
                columnLenght++;
            }

            int[,] grid = new int[lines.Length, columnLenght];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < columnLenght; j++)
                {  
                    grid[i,j] = Convert.ToInt32(lines[i].Substring(j, 1));
                }
            }

            List<int> basins = new List<int>();

            int endResult = 0;

            for (int i = 0; i < lines.Length; i++)
            {                
                for (int j = 0; j < columnLenght; j++)
                {
                    int hits = 0;
                    int duds = 0;
                    if (i - 1 >= 0)
                    {
                        if (grid[i, j] < grid[i - 1, j]) hits++;
                    }
                    else duds++;

                    if (i + 1 < lines.Length)
                    {
                        if (grid[i, j] < grid[i + 1, j]) hits++;
                    }
                    else duds++;

                    if (j - 1 >= 0)
                    {
                        if (grid[i, j] < grid[i, j - 1]) hits++;
                    }
                    else duds++;

                    if (j + 1 < columnLenght)
                    {
                        if (grid[i, j] < grid[i, j + 1]) hits++;
                    }
                    else duds++;

                    if (hits == 4 - duds) 
                    {
                        Console.WriteLine("grid low point: " + i + "," + j + " at value: " + grid[i, j]);

                        List<(int, int)> gridPos = new List<(int, int)>();

                        Search(grid, i, j);

                        void Search(int[,] grid, int x, int y)
                        {
                            if (x - 1 >= 0)
                            {
                                if (grid[x - 1, y] != 9)
                                {
                                    var gridValue = (x - 1, y);
                                    if (!gridPos.Contains(gridValue))
                                    {
                                        gridPos.Add(gridValue);
                                        Search(grid, x-1, y);
                                    }
                                }
                            }

                            if (x + 1 < lines.Length)
                            {
                                if (grid[x + 1, y] != 9)
                                {
                                    var gridValue = (x + 1, y);
                                    if (!gridPos.Contains(gridValue))
                                    {
                                        gridPos.Add(gridValue);
                                        Search(grid, x + 1, y);
                                    }
                                }
                            }

                            if (y - 1 >= 0)
                            {
                                if (grid[x, y - 1] != 9)
                                {
                                    var gridValue = (x, y - 1);
                                    if (!gridPos.Contains(gridValue))
                                    {
                                        gridPos.Add(gridValue);
                                        Search(grid, x, y - 1);
                                    }
                                }
                            }

                            if (y + 1 < columnLenght)
                            {
                                if (grid[x, y + 1] != 9)
                                {
                                    var gridValue = (x, y + 1);
                                    if (!gridPos.Contains(gridValue))
                                    {
                                        gridPos.Add(gridValue);
                                        Search(grid, x, y + 1);
                                    }
                                }
                            }
                        }

                        basins.Add(gridPos.Count);

                    }   
                }                
            }

            BubbleSort(basins);

            for (int i = 0; i < basins.Count; i++)
            {
                Console.WriteLine(basins[i]);
            }

            //endResult = basins[basins.Count] + basins[basins.Count - 1] + basins[basins.Count - 2];

            Console.WriteLine("End Result: " + endResult);
            Console.ReadKey();
        }

        static void BubbleSort(List<int> data)
        {
            bool needsSorting = true;
            for (int i = 0; i < data.Count - 1 && needsSorting; i++)
            {
                needsSorting = false;
                for (int j = 0; j < data.Count - 1 - i; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        needsSorting = true;
                        int tmp = data[j + 1];
                        data[j + 1] = data[j];
                        data[j] = tmp;
                    }
                }
            }
        }


        private static void Day9Puzzle1()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day9_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day9_Input.txt");

            int columnLenght = 0;
            for (int i = 0; i < lines[0].Length; i++)
            {
                columnLenght++;
            }

            int[,] grid = new int[lines.Length, columnLenght];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < columnLenght; j++)
                {                    
                    int y = Convert.ToInt32(lines[i].Substring(j, 1)); 
                    grid[i,j] = y;
                }
            }

            int endResult = 0;

            for (int i = 0; i < lines.Length; i++)
            {                
                for (int j = 0; j < columnLenght; j++)
                {
                    int hits = 0;
                    int duds = 0;
                    if (i - 1 >= 0)
                    {
                        if (grid[i, j] < grid[i - 1, j]) hits++;
                    }
                    else duds++;

                    if (i + 1 < lines.Length)
                    {
                        if (grid[i, j] < grid[i + 1, j]) hits++;
                    }
                    else duds++;

                    if (j - 1 >= 0)
                    {
                        if (grid[i, j] < grid[i, j - 1]) hits++;
                    }
                    else duds++;

                    if (j + 1 < columnLenght)
                    {
                        if (grid[i, j] < grid[i, j + 1]) hits++;
                    }
                    else duds++;

                    if (hits == 4 - duds) 
                    {
                        Console.WriteLine("grid low point: " + i + "," + j + " at value: " + grid[i, j]);
                        endResult += (grid[i, j] + 1); 
                    }   
                }                
            }           

            Console.WriteLine("End Result: " + endResult);
            Console.ReadKey();

            /*
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < columnLenght; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine("");
                Console.ReadKey();
            }*/
        }

        private static void Day8Puzzle2()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day8_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day8_Input.txt");
            List<int> numbers = new List<int>();
            

            char space = ' ';
            string separation = " | ";

            for (int i = 0; i < lines.Length; i++)
            {
                //string[] temp1 = lines[i].Split(separation);
                string[] temp1 = lines[i].Split(separation);
                string[] input = temp1[0].Split(space);
                string[] output = temp1[1].Split(space);
                char[] connections = new char[7];
                for (int j = 0; j < connections.Length; j++)
                {
                    connections[j] = 'x';
                }

                BubbleSortStringLenght(input);

                for (int j = 0; j < input.Length; j++)
                {
                    //Console.WriteLine("." + input[j] + ".");
                }
                
                //one
                List<char> one = new List<char>(input[0].ToCharArray());
                connections[2] = one[0];
                connections[5] = one[1];

                // seven
                string temp = input[1];
                temp = temp.Trim(one[1], one[0]);
                List<char> seven = new List<char>(temp.ToCharArray());
                connections[0] = seven[0];

                // four                
                temp = input[2];
                temp = Extensions.Filter(temp, one);      
                List<char> four = new List<char>(temp.ToCharArray());  
                connections[1] = four[0];
                connections[3] = four[1];

                // eight
                temp = input[9];
                List<char> charsToRemove = new List<char> { connections[0], connections[1], connections[2], connections[3], connections[5] };
                temp = Extensions.Filter(temp, charsToRemove);
                List<char> eight = new List<char>(temp.ToCharArray());
                connections[4] = eight[0];
                connections[6] = eight[1];

                for (int j = 0; j < input.Length; j++)
                {
                    // 0
                    if (input[j].Contains(connections[0]) && 
                        input[j].Contains(connections[2]) && input[j].Contains(connections[5]) &&
                        Either(input[j], connections[1], connections[3]) == 1 && 
                        input[j].Contains(connections[4]) && input[j].Contains(connections[6]))
                    {
                        string nr = "0";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 1
                    else if (input[j].Length == 2)
                    {
                        string nr = "1";                        

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 2
                    else if (input[j].Contains(connections[0]) && 
                             Either(input[j], connections[2], connections[5]) == 1 &&
                             Either(input[j], connections[1], connections[3]) == 1 &&
                             input[j].Contains(connections[4]) && input[j].Contains(connections[6]))
                    {
                        string nr = "2";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 3
                    else if (input[j].Contains(connections[0]) && 
                             input[j].Contains(connections[2]) && input[j].Contains(connections[5]) &&
                             Either(input[j], connections[1], connections[3]) == 1 &&
                             Either(input[j], connections[4], connections[6]) == 1)
                    {
                        string nr = "3";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 4
                    else if (input[j].Length == 4)
                    {
                        string nr = "4";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 5
                    else if (input[j].Contains(connections[0]) && 
                             Either(input[j], connections[2], connections[5]) == 1 &&
                             input[j].Contains(connections[1]) && input[j].Contains(connections[3]) &&
                             Either(input[j], connections[4], connections[6]) == 1)
                    {
                        string nr = "5";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 6 
                    else if (input[j].Contains(connections[0]) && 
                             Either(input[j], connections[2], connections[5]) == 1 &&
                             input[j].Contains(connections[1]) && input[j].Contains(connections[3]) && 
                             input[j].Contains(connections[4]) && input[j].Contains(connections[6]))
                    {
                        string nr = "6";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 7
                    else if (input[j].Length == 3)
                    {
                        string nr = "7";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 8
                    else if (input[j].Length == 7)
                    {
                        string nr = "8";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    // 9
                    else if (input[j].Contains(connections[0]) && 
                             input[j].Contains(connections[2]) && input[j].Contains(connections[5]) &&
                             input[j].Contains(connections[1]) && input[j].Contains(connections[3]) &&
                             Either(input[j], connections[4], connections[6]) == 1)
                    {
                        string nr = "9";

                        for (int k = 0; k < 4; k++)
                        {
                            output[k] = Extensions.OutputComparison(output[k], input[j], nr);
                        }
                    }
                    else { Console.WriteLine("somethings wrong with:" + input[j]); }
                }

                string stringOfNrs = output[0] + output[1] + output[2] + output[3];
                
                for (int j = 0; j < output.Length; j++)
                {
                    Console.WriteLine(output[j]);
                    //stringOfNrs = stringOfNrs.Insert(j, output[j]); 
                }
                
                int numVal = Convert.ToInt32(stringOfNrs);
                numbers.Add(numVal);

                //Console.ReadKey();
            }

            int count = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                count += numbers[i];
            }

            Console.WriteLine("count: " + count);
        }

        public static int Either(string input, char index1, char index2)
        {
            int value = 0;
            if (input.Contains(index1)) value++;
            if (input.Contains(index2)) value++;
            return value;  
        }

        private static void Day8Puzzle1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day8_Input.txt");
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day8_Input.txt");

            List<string> numbers = new List<string>();
            char[] Chars = { ' ', '|'};
            char line = '|';
            char space = ' ';

            int count = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(line);
                string[] other = temp[1].Split(space);

                for (int j = 0; j < other.Length; j++)
                {
                    other[j] = other[j].Trim();
                    Console.WriteLine("." + other[j] + ".");
                    
                    if (other[j].Length == 2 || other[j].Length == 4 || other[j].Length == 3 ||
                        other[j].Length == 7) count++;
                }
            }
            
            Console.WriteLine("count: " + count);
            
        }
        private static void Day7Puzzle2()
        {
            //string line = System.IO.File.ReadAllText(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day7_Input.txt");
            string line = System.IO.File.ReadAllText(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day7_Input.txt");
            
            char comma = ',';
            string[] nrs = line.Split(comma);
            List<int> startingPos = new List<int>();

            for (int i = 0; i < nrs.Length; i++)
            {
                int numVal = Convert.ToInt32(nrs[i]);
                startingPos.Add(numVal);
            }

            int cheapestOutcome = int.MaxValue;

            for (int i = 0; i < 1000; i++)
            {
                int currentFuelIteration = 0;
                
                for (int j = 0; j < startingPos.Count; j++)
                {
                    if (startingPos[j] != i)
                    {
                        int distance = Math.Abs(startingPos[j] - i);
                        int increase = 0;

                        while (distance != 0) 
                        {
                            currentFuelIteration += (increase + 1);
                            increase++;
                            distance--;
                        }
                    }
                }
                if (currentFuelIteration < cheapestOutcome) cheapestOutcome = currentFuelIteration;
            }
            Console.WriteLine("cheapest outcome: " + cheapestOutcome);
        }
        private static void Day7Puzzle1()
        {
            //string line = System.IO.File.ReadAllText(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day7_Input.txt");
            string line = System.IO.File.ReadAllText(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day7_Input.txt");
            
            char comma = ',';
            string[] nrs = line.Split(comma);
            List<int> startingPos = new List<int>();

            for (int i = 0; i < nrs.Length; i++)
            {
                int numVal = Convert.ToInt32(nrs[i]);
                startingPos.Add(numVal);
            }

            int cheapestOutcome = int.MaxValue;

            for (int i = 0; i < 1000; i++)
            {
                int currentFuelIteration = 0;
                
                for (int j = 0; j < startingPos.Count; j++)
                {
                    if (startingPos[j] != i)
                    {
                        currentFuelIteration += Math.Abs(startingPos[j] - i);
                    }
                }
                if (currentFuelIteration < cheapestOutcome) cheapestOutcome = currentFuelIteration;
            }
            Console.WriteLine("cheapest outcome: " + cheapestOutcome);
        }        
        static void BubbleSortStringLenght(string[] data)
        {
            bool needsSorting = true;
            for (int i = 0; i < data.Length - 1 && needsSorting; i++)
            {
                needsSorting = false;
                for (int j = 0; j < data.Length - 1 - i; j++)
                {
                    if (data[j].Length > data[j + 1].Length)
                    {
                        needsSorting = true;
                        string tmp = data[j +1];
                        data[j + 1] = data[j];
                        data[j] = tmp;
                    }
                }
            }
        }
        private static void Day6Puzzle2()
        {
            //string line = System.IO.File.ReadAllText(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day6_Input.txt");
            string line = System.IO.File.ReadAllText(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day6_Input.txt");

            char comma = ',';
            string[] nrs = line.Split(comma);
            List<int> startingFish = new List<int>();
            List<BigInteger> currentFish = new List<BigInteger>();

            for (int i = 0; i < nrs.Length; i++)
            {
                int numVal = Convert.ToInt32(nrs[i]);
                startingFish.Add(numVal);
            }

            Console.WriteLine("");

            BigInteger totalFish = 0;
            
            for (int i = 0; i < 10; i++)
            {
                currentFish.Add(0);
            }
            
            for (int i = 0; i < startingFish.Count; i++)
            {
                currentFish[startingFish[i]] += 1;
            }

            for (int days = 0; days < 256; days++)
            {
                currentFish[7] += currentFish[0];
                currentFish[9] += currentFish[0];
                currentFish[0] = currentFish[1];
                currentFish[1] = currentFish[2];
                currentFish[2] = currentFish[3];
                currentFish[3] = currentFish[4];
                currentFish[4] = currentFish[5];
                currentFish[5] = currentFish[6];
                currentFish[6] = currentFish[7];
                currentFish[7] = currentFish[8];
                currentFish[8] = currentFish[9];
                currentFish[9] = 0;
            }

            for (int i = 0; i < currentFish.Count; i++)
            {
                totalFish += currentFish[i];
            }
            
            Console.WriteLine(totalFish);   
            Console.ReadKey();
        }
        private static void Day6Puzzle1()
        {         
            string line = System.IO.File.ReadAllText(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day6_Input.txt");
            //string line = System.IO.File.ReadAllText(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day6_Input.txt");

            char comma = ',';
            string[] nrs = line.Split(comma);
            List<int> numbers = new List<int>();
            for (int i = 0; i < nrs.Length; i++)
            {
                int numVal = Convert.ToInt32(nrs[i]);
                numbers.Add(numVal);
            }

            for (int i = 0; i < 80; i++)
            {
                for (int fish = 0; fish < numbers.Count; fish++)
                {
                    if(numbers[fish] == 0)
                    {
                        numbers[fish] = 7;
                        numbers.Add(9);
                    }
                    numbers[fish]--;
                }
                Console.WriteLine(numbers.Count);
            }

            Console.WriteLine(numbers.Count);
            Console.ReadKey();
        }
        private static void Day5Puzzle2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day5_Input.txt");
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day5_Input.txt");

            List<Node> nodes = new List<Node>();

            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    nodes.Add(new Node());
                    int yes = x + (y * 1000);
                    nodes[yes].x = x;
                    nodes[yes].y = y;
                }
            }

            char[] chars = new char[] { ',', ' ', '-', '>' };

            List<int> Xnum = new List<int>();
            List<int> Ynum = new List<int>();

            int testnr1;
            int testnr2;
            int testnr3;


            
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(chars);
                List<int> numbers = new List<int>();

                for (int j = 0; j < temp.Length; j++)
                {
                    int numVal;
                    if (int.TryParse(temp[j], out numVal)) numbers.Add(numVal);
                }
                //Console.WriteLine(numbers[0] + ", " + numbers[1] + ", " + numbers[2] + ", " + numbers[3]);
                //Console.WriteLine(numbers.Count);

                int a = 0;
                int b = 0;
                int c = 0;
                int d = 0;                

                if (numbers[0] == numbers[2])
                {
                    if (numbers[1] < numbers[3])
                    {
                        a = numbers[1];
                        b = numbers[3];
                    }
                    else
                    {
                        a = numbers[3];
                        b = numbers[1];
                    }
                    for (int k = 0; k < nodes.Count; k++)
                    {
                        if (nodes[k].x == numbers[0])
                        {
                            if (nodes[k].y >= a && nodes[k].y <= b)
                            {
                                nodes[k].value++;
                            }
                        }
                    }
                }
                else if (numbers[1] == numbers[3])
                {
                    if (numbers[0] < numbers[2])
                    {
                        a = numbers[0];
                        b = numbers[2];
                    }
                    else
                    {
                        a = numbers[2];
                        b = numbers[0];
                    }

                    for (int k = 0; k < nodes.Count; k++)
                    {
                        if (nodes[k].y == numbers[1])
                        {
                            if (nodes[k].x >= a && nodes[k].x <= b)
                            {
                                nodes[k].value++;
                            }
                        }
                    }
                }
                else
                {
                    int increase = Math.Abs(numbers[0] - numbers[2]);

                    if (numbers[0] < numbers[2])
                    {
                        for (int num = 0; num < increase; num++)
                        {
                            Xnum.Add(numbers[0] - num);
                        }
                    }
                    else
                    {
                        for (int num = 0; num < increase; num++)
                        {
                            Xnum.Add(numbers[0] + num);
                        }
                    }

                    if (numbers[1] < numbers[3])
                    {
                        for (int num = 0; num < increase; num++)
                        {
                            Ynum.Add(numbers[1] - num);
                        }
                    }
                    else
                    {
                        for (int num = 0; num < increase; num++)
                        {
                            Ynum.Add(numbers[1] + num);
                        }
                    }
                    //Console.WriteLine(numbers[0] + ", " + numbers[1] + ", " + numbers[2] + ", " + numbers[3]);
                    //Console.WriteLine("");
                    //Console.WriteLine(a + ", " + b + ", " + c + ", " + d);

                    //Console.WriteLine((numbers[0] - numbers[2]) + ", " + (numbers[1] - numbers[3]));
                    //Console.WriteLine((a - c) + ", " + (b - d));

                    
                }
            }

            Console.WriteLine(Xnum.Count);
            Console.WriteLine(Ynum.Count);


            for (int blob = 0; blob < Xnum.Count; blob++)
            {
                for (int k = 0; k < nodes.Count; k++)
                {
                    if (nodes[k].x == Xnum[blob] && nodes[k].y == Ynum[blob])
                    {
                        nodes[k].value++;
                        //Console.WriteLine(blob);
                        break;
                    }
                }
            }            


            int count = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].value >= 2)
                {
                    count++;
                }
            }

            Console.WriteLine("horizontal and vertical lines cross 2 or larger : " + count);
            Console.WriteLine("press any key to exit");
            Console.ReadKey();        
        }
        private static void Day5Puzzle1()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day5_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day5_Input.txt");

            List<Node> nodes = new List<Node>();

            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    nodes.Add(new Node());
                    int yes = x + (y * 1000);
                    nodes[yes].x = x;
                    nodes[yes].y = y;
                }
            }

            char[] chars = new char[] {',', ' ', '-', '>'};

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(chars);
                List<int> numbers = new List<int>();

                for (int j = 0; j < temp.Length; j++)
                {
                    int numVal;
                    if (int.TryParse(temp[j], out numVal)) numbers.Add(numVal);
                }
                //Console.WriteLine(numbers[0] + ", " + numbers[1] + ", " + numbers[2] + ", " + numbers[3]);

                int a = 0;
                int b = 0;
                
                if(numbers[0] == numbers[2])
                {     
                    if (numbers[1] < numbers[3]) 
                    {
                        a = numbers[1];
                        b = numbers[3];
                    }
                    else
                    {
                        a = numbers[3];
                        b = numbers[1];
                    }
                    for (int k = 0; k < nodes.Count; k++)
                    {
                        if (nodes[k].x == numbers[0])
                        {
                            if(nodes[k].y >= a && nodes[k].y <= b)
                            {
                                nodes[k].value++;                                
                            }
                        }
                    }                    
                }

                if (numbers[1] == numbers[3])
                {          
                    if (numbers[0] < numbers[2])
                    {
                        a = numbers[0];
                        b = numbers[2];
                    }
                    else
                    {
                        a = numbers[2];
                        b = numbers[0];
                    }

                    for (int k = 0; k < nodes.Count; k++)
                    {
                        if (nodes[k].y == numbers[1])
                        {
                            if (nodes[k].x >= a && nodes[k].x <= b)
                            {
                                nodes[k].value++;
                            }
                        }
                    }
                }
            }

            int count = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                if(nodes[i].value >= 2)
                {
                    count++;
                }
            }

            Console.WriteLine("horizontal and vertical lines cross 2 or larger : " + count);
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
        private static void Day4Puzzle2()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day4_BingoNrs.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day4_BingoNrs.txt");

            string bingoline = lines[0];
            char comma = ',';
            string[] bingoNrs = bingoline.Split(comma);
            int[] bingoNrsAsInt = new int[bingoNrs.Length];
            for (int i = 0; i < bingoNrs.Length; i++)
            {
                int numVal = Convert.ToInt32(bingoNrs[i]);
                bingoNrsAsInt[i] = numVal;
            }

            List<int> tablesNrs = new List<int>();

            char space = ' ';

            for (int i = 1; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(space);
                for (int j = 0; j < temp.Length; j++)
                {
                    int numVal;
                    if (int.TryParse(temp[j], out numVal)) tablesNrs.Add(numVal);
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

            int unMarked = 0;

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
                            if (boards.Count == 1)
                            {
                                Console.WriteLine("winning nr: " + nr);

                                for (int i = 0; i < boards[board].nodes.Count; i++)
                                {        
                                    if (!boards[board].nodes[i].isMarked)
                                    {
                                        unMarked += boards[board].nodes[i].value;
                                    }
                                }
                                Console.WriteLine("unmarked value: " + unMarked);
                                Console.ReadKey();
                            }

                            boards.RemoveAt(board);
                            board--;
                            break;                       
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
                            if (boards.Count == 1)
                            {
                                Console.WriteLine("winning nr: " + nr);

                                for (int i = 0; i < boards[board].nodes.Count; i++)
                                {
                                    if (!boards[board].nodes[i].isMarked)
                                    {
                                        unMarked += boards[board].nodes[i].value;
                                    }
                                }
                                Console.WriteLine("unmarked value: " + unMarked);
                                Console.ReadKey();
                            }

                            boards.RemoveAt(board);
                            board--;
                            break;
                        }
                        hits = 0;
                    }
                }
            }
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