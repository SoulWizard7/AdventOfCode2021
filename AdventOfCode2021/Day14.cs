using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AdventOfCode2021
{
    public static class Day14
    {
        public static void Day14Puzzle2()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day14_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day14_Input.txt");

            string template = lines[0];

            List<string> pairs = new List<string>();
            for (int i = 2; i < lines.Length; i++)
            {
                pairs.Add(lines[i]);
            }
            
            List<string> inputPairs = new List<string>();
            List<string> outputFromPair = new List<string>();
            
            for (int i = 2; i < lines.Length; i++)
            {
                inputPairs.Add(lines[i].Substring(0, 2));
                outputFromPair.Add(lines[i].Substring(6, 1));
            }
            
            
            List<string> templateChunks = new List<string>();
            List<string> elements = new List<string>();
            for (int i = 0; i < template.Length - 2; i++)
            {
                templateChunks.Add(template.Substring(i, 3));
                elements.Add(template.Substring(i, 1));
            }

            List<BigInteger> elementAmounts = new List<BigInteger>();

            List<string> elementTypes = new List<string>();
            for (int i = 0; i < elements.Count; i++)
            {
                if (!elementTypes.Contains(elements[i]))
                {
                    elementTypes.Add(elements[i]);
                }
            }
            
            string curChunkLine = String.Empty;

            //loop start?

            for (int curChunk = 0; curChunk < templateChunks.Count; curChunk++)
            {
                List<string> newChunks = new List<string>();
                List<string> nextChunks = new List<string>();
                
                newChunks.Add(templateChunks[curChunk].Substring(0, 2));
                newChunks.Add(templateChunks[curChunk].Substring(1, 2));
                
                for (int x = 0; x < 40; x++)
                {
                    Console.WriteLine(x);
                    for (int i = 0; i < newChunks.Count; i++)
                    {
                        //Console.WriteLine(newChunks.Count);
                        
                        for (int j = 0; j < inputPairs.Count; j++)
                        {
                            if (newChunks[i] == inputPairs[j])
                            {
                                char[] chars = {inputPairs[j].ToCharArray()[0], outputFromPair[j].ToCharArray()[0]};
                                nextChunks.Add(new string(chars));
                                if (i == newChunks.Count - 1)
                                {
                                    char c = inputPairs[j].ToCharArray()[1];
                                    string lastLetter = c.ToString();
                                    nextChunks.Add(lastLetter);
                                    //Console.WriteLine("added last letter : " + c);
                                    break;
                                }
                            }
                        }
                    }
                    curChunkLine = String.Empty;
                    curChunkLine = string.Join(String.Empty ,nextChunks);
                    //Console.WriteLine(curChunkLine);
                    
                    newChunks.Clear();
                    nextChunks.Clear();
                    
                    for (int i = 0; i < curChunkLine.Length - 1; i++)
                    {
                        newChunks.Add(curChunkLine.Substring(i, 2));
                    }
                    //Console.ReadKey();
                }
                
                curChunkLine = string.Join(String.Empty ,nextChunks);
                Console.WriteLine("current chunk line lenght: " + curChunkLine.Length);
                Console.ReadKey();

                for (int i = 0; i < curChunkLine.Length; i++)
                {
                    string currChar = curChunkLine.Substring(i, 1);
                    for (int j = 0; j < elementTypes.Count; j++)
                    {
                        if (currChar == elementTypes[j])
                        {
                            elementAmounts[j]++;
                        }
                    }
                }
                
                
            }

            for (int i = 0; i < elementTypes.Count; i++)
            {
                Console.WriteLine("There are " + elementAmounts[i] + " of element " + elementTypes[i]);
            }
            
            
            
        }
        
        public static void Day14Puzzle1()
        {
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\niklas.hognabba\RiderProjects\AdventOfCode2021\AdventOfCode2021\Day14_Input.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mother of Dragons\AdventOfCode2021\AdventOfCode2021\AdventOfCode2021\Day14_Input.txt");

            string template = lines[0];

            List<string> pairs = new List<string>();
            for (int i = 2; i < lines.Length; i++)
            {
                pairs.Add(lines[i]);
            }

            //loop start?

            for (int x = 0; x < 10; x++)
            {
                List<string> templateChunk = new List<string>();
                List<string> templateNewChunk = new List<string>();
                Console.WriteLine("current iteration: " + (x + 1));
                Console.WriteLine("template lenght: " + template.Length);
                
                for (int i = 0; i < template.Length - 1; i++)
                {
                    templateChunk.Add(template.Substring(i, 2));
                }
            
                for (int i = 0; i < templateChunk.Count; i++)
                {
                    for (int j = 0; j < pairs.Count; j++)
                    {
                        string input = pairs[j].Substring(0, 2);
                        if (templateChunk[i] == input)
                        {
                            var output = pairs[j].Substring(6, 1);
                            //Console.WriteLine(templateChunk[i] + ": template chunk = input: " + input + ", output:" + output);
                            char a = input.ToCharArray()[0];
                            char b = output.ToCharArray()[0];
                            //char c = input.ToCharArray()[1];
                            char[] chars = {a, b};
                            string newPair = new string(chars);
                            templateNewChunk.Add(newPair);
                            if (i == templateChunk.Count - 1)
                            {
                                char c = input.ToCharArray()[1];
                                string lastLetter = c.ToString();
                                templateNewChunk.Add(lastLetter);
                                Console.WriteLine("added last letter : " + c);  
                            }
                        }
                    }
                }
                //Console.WriteLine(template);
                template = string.Join(String.Empty ,templateNewChunk);
                //Console.WriteLine(template);
                //Console.ReadKey();
            }
            
            
            
            //checking the elements
            
            List<string> elements = new List<string>();
            for (int i = 0; i < template.Length; i ++)
            {
                elements.Add(template.Substring(i, 1));
            }

            List<string> elementTypes = new List<string>();
            for (int i = 0; i < elements.Count; i++)
            {
                if (!elementTypes.Contains(elements[i]))
                {
                    elementTypes.Add(elements[i]);
                }
            }

            for (int i = 0; i < elementTypes.Count; i++)
            {
                int hits = 0;
                for (int j = 0; j < elements.Count; j++)
                {
                    if (elementTypes[i] == elements[j])
                    {
                        hits++;
                    }
                }
                Console.WriteLine($"There are {hits} of element " + elementTypes[i]);
            }


        }
    }
}