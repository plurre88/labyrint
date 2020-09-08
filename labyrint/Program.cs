using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int playerPosX = 0;
            int playerPosY = 0;
            int size = 16;
            int player = size + ((4 * size) * playerPosY) + (4 * playerPosX) + 3;
            int score = 0;
            int randomNumber1 = 2;
            int randomNumber2 = 2;
            
            Boolean quit = true;

            while (quit)
            {
                int pos = 1;
                int treasure = size + ((4 * size) * randomNumber1) + (4 * randomNumber2) + 3;
                int maxNumber = (size / 4);

                Console.Clear();

                for (int i = 0; i < size+1; i++) // Denna for-loop lägger översta raden med X.
                {
                    Console.Write("X");
                }

                for (int i = 1; i <= size; i++) // Denna for-loop gör en ny rad så den flyttar i Y-axeln, och sedan skriver ett X.
                {
                    Console.WriteLine();
                    Console.Write("X");

                    for (int j = 1; j <= size; j++) // Denna for-loop skriver ut i X-axeln.
                    {
                        pos++;

                        if (player == pos)
                        {
                            Console.Write("A");
                        }
                        else if (treasure == pos)
                        {
                            Console.Write("O");
                        }
                        else if (i % 4 == 0)  // Denna kontrolerar vart man ligger i Y-axeln.
                        {
                            Console.Write("X");
                        }
                        else if (j % 4 == 0) // Denna kontrolerar vart man ligger i X-axeln.
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write(" ");
                        }

                    }

                }

                Console.WriteLine();
                Console.Write("SCORE=" + score);

                for (int k = 0; k < size - 12; k++)
                {
                    Console.Write(" ");
                }
                Console.Write("QUIT=Q");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.KeyChar == 'x')  //Detta förstorar spelplanen och ställer tillbaka spelaren till start.
                {
                    size = size + 4;
                    player = size + 3;
                    score = 0;
                    
                }
                else if (key.KeyChar == 'z') // Detta förminskar spelplanen och ställer tillbaka spelaren till start.
                {
                    size = size - 4;
                    player = size + 3;
                    score = 0;

                }
                else if (key.KeyChar == 'w') // Flyttar upp spelaren.
                {
                    if (playerPosY > 0) 
                    {
                        playerPosY--;
                        player = size + ((4 * size) * playerPosY) + (4 * playerPosX) + 3;
                    }
                }
                else if (key.KeyChar == 's') // Flyttar ner spelaren.
                {
                    if (playerPosY < maxNumber -1) 
                    {
                        playerPosY++;
                        player = size + ((4 * size) * playerPosY) + (4 * playerPosX) + 3;
                    }
                }
                else if (key.KeyChar == 'a') // Flyttar spelaren vänster.
                {
                    if (playerPosX > 0) 
                    {
                        playerPosX--;
                        player = size + ((4 * size) * playerPosY) + (4 * playerPosX) + 3;
                    }
                }
                else if (key.KeyChar == 'd') // Flyttar spelaren åt höger.
                {
                    if (playerPosX < maxNumber -1) 
                    {
                        playerPosX++;
                        player = size + ((4 * size) * playerPosY) + (4 * playerPosX) + 3;
                    }
                }
                else if (key.KeyChar == 'q') // Stänger av spelet.
                {
                    quit = false;
                }
                

                if (player == treasure) // Byter plats på Skatten!
                {
                    while (treasure == player)
                    {
                        randomNumber1 = rnd.Next(maxNumber);
                        randomNumber2 = rnd.Next(maxNumber);
                        treasure = size + ((4 * size) * randomNumber1) + (4 * randomNumber2) + 3;
                    }

                    score++;
                    Console.Beep();
                }
            }
        }
    }
}
