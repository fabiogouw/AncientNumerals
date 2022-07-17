﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientNumerals
{
    internal class NumberPattern
    {
        public static int NUM_LINES = 13;
        public static int NUM_COLUMNS = 11;
        private char[,] _matrix = new char[NUM_LINES, NUM_COLUMNS];
        private static List<NumberPattern> _patterns = new List<NumberPattern>();

        public int Number { get; private set; }

        private NumberPattern(int number, string pattern)
        {
            Number = number;
            try
            {
                _matrix = ToMatrix(pattern);
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Error while creating pattern for {number}", ex);
            }
        }

        public static char[,] ToMatrix(string pattern)
        {
            var matrix = CreateEmptyMatrix();
            var lines = pattern.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length != NUM_LINES)
            {
                throw new ArgumentException($"Expected a cipher with {NUM_LINES} lines but got {lines.Length}");
            }
            for (int x = 0; x < lines.Length; x++)
            {
                var chars = lines[x].ToCharArray();
                if (chars.Length != NUM_COLUMNS)
                {
                    throw new ArgumentException($"Expected a cipher with the line {x} with {NUM_COLUMNS} chars but got {chars.Length}");
                }
                for (int y = 0; y < chars.Length; y++)
                {
                    matrix[x, y] = chars[y];
                }
            }
            return matrix;
        }

        public static char[,] CreateEmptyMatrix()
        {
            return new char[NUM_LINES, NUM_COLUMNS];
        }

        public bool CanApply(char[,] compared)
        {
            for (int x = 0; x < NUM_LINES; x++)
            {
                for (int y = 0; y < NUM_COLUMNS; y++)
                {
                    if (_matrix[x, y] != ' ' && _matrix[x, y] != compared[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static NumberPattern()
        {
            _patterns.Add(new NumberPattern(0, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(1, @"
.    .----.
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(2, @"
.    .    .
     |     
     |     
     |     
     |---- 
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(3, @"
.    .    .
     |\    
     | \   
     |  \  
     |   \ 
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(4, @"
.    .    .
     |   / 
     |  /  
     | /   
     |/    
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(5, @"
.    .----.
     |   / 
     |  /  
     | /   
     |/    
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(6, @"
.    .    .
     |    |
     |    |
     |    |
     |    |
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(7, @"
.    .----.
     |    |
     |    |
     |    |
     |    |
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(8, @"
.    .    .
     |    |
     |    |
     |    |
     |----|
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(9, @"
.    .----.
     |    |
     |    |
     |    |
     |----|
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(10, @"
.----.    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(20, @"
.    .    .
     |     
     |     
     |     
 ----|     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(30, @"
.    .    .
    /|     
   / |     
  /  |     
 /   |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(40, @"
.    .    .
 \   |     
  \  |     
   \ |     
    \|     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(50, @"
.----.    .
 \   |     
  \  |     
   \ |     
    \|     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(60, @"
.    .    .
|    |     
|    |     
|    |     
|    |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(70, @"
.----.    .
|    |     
|    |     
|    |     
|    |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(80, @"
.    .    .
|    |     
|    |     
|    |     
|----|     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(90, @"
.----.    .
|    |     
|    |     
|    |     
|----|     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(100, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.    .----."));
            _patterns.Add(new NumberPattern(200, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |---- 
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(300, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |   / 
     |  /  
     | /   
     |/    
.    .    ."));
            _patterns.Add(new NumberPattern(400, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |\    
     | \   
     |  \  
     |   \ 
.    .    ."));
            _patterns.Add(new NumberPattern(500, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |\    
     | \   
     |  \  
     |   \ 
.    .----."));
            _patterns.Add(new NumberPattern(600, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |    |
     |    |
     |    |
     |    |
.    .    ."));
            _patterns.Add(new NumberPattern(700, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |    |
     |    |
     |    |
     |    |
.    .----."));
            _patterns.Add(new NumberPattern(800, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |----|
     |    |
     |    |
     |    |
.    .    ."));
            _patterns.Add(new NumberPattern(900, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |----|
     |    |
     |    |
     |    |
.    .----."));
            _patterns.Add(new NumberPattern(1000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
     |     
     |     
     |     
     |     
.----.    ."));
            _patterns.Add(new NumberPattern(2000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
 ----|     
     |     
     |     
     |     
.    .    ."));
            _patterns.Add(new NumberPattern(3000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
 \   |     
  \  |     
   \ |     
    \|     
.    .    ."));
            _patterns.Add(new NumberPattern(4000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
    /|     
   / |     
  /  |     
 /   |     
.    .    ."));
            _patterns.Add(new NumberPattern(5000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
    /|     
   / |     
  /  |     
 /   |     
.    .----."));
            _patterns.Add(new NumberPattern(6000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
|    |     
|    |     
|    |     
|    |     
.    .    ."));
            _patterns.Add(new NumberPattern(7000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
|    |     
|    |     
|    |     
|    |     
.----.----."));
            _patterns.Add(new NumberPattern(8000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
|----|     
|    |     
|    |     
|    |     
.    .    ."));
            _patterns.Add(new NumberPattern(9000, @"
.    .    .
     |     
     |     
     |     
     |     
     |     
.    |    .
     |     
|----|     
|    |     
|    |     
|    |     
.----.    ."));
        }

        public static NumberPattern GetFor(int number)
        {
            var pattern = _patterns.SingleOrDefault(p => p.Number == number);
            if (pattern == null)
            {
                throw new ArgumentException($"There's no pattern configured for {number}");
            }
            return pattern;
        }

        public static IEnumerable<NumberPattern> GetAll()
        {
            return _patterns;
        }
    }
}