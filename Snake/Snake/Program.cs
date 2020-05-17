﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            //Задаем рамку
            HorizontalLine upLine = new HorizontalLine(0, 118, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 118, 28, '+');
            VerticalLine leftLine = new VerticalLine(0, 28, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 28, 118, '+');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

            Point p = new Point(4,5, '*');
            p.Draw();

            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(117,27,'$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                } 

                System.Threading.Thread.Sleep(100);
            
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

        }
    }
}
