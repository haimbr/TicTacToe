using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[5, 5];
            arrayInitialize(board);

            for (int i = 0; i < 5; i++)
            {
                printBoard(board);
                string res = userInput(board);
                board[int.Parse(res[0] + ""), int.Parse(res[1] + "")] = "X ";

                if (i > 3)
                {
                    printBoard(board);
                    Console.WriteLine("The game ended in a draw");
                    break;
                }

                if (CheckColumnAndRow(board, "O ", 2 ,0) || CheckColumnAndRow(board, "O ", 1,0) || CheckDiagonal(board, "O ", 3 , -1) || CheckDiagonal(board, "O ", 1, 1))
                {
                    printBoard(board);
                    Console.WriteLine("you lost the game never mind try again");
                    break;
                }                

                if (CheckColumnAndRow(board, "X ", 2, 0) || CheckColumnAndRow(board, "X ", 1,0) || CheckDiagonal(board, "X ", 3, -1) || CheckDiagonal(board, "X ", 1, 1))
                    continue;
                else if (board[2, 2] == "- ")
                    board[2, 2] = "O ";              
                else if (CheckColumnAndRow(board, "O ", 1, -1) || CheckColumnAndRow(board, "O ", 2, -1))
                    continue;
                else if (CheckColumnAndRow(board, "- ", 2 , 0) || CheckColumnAndRow(board, "- ", 1, 0))
                    continue;
            }
        }

        static bool CheckDiagonal(string[,] board, string type, int j, int first)
        {
            int temp = j, count = 0;
            for (int i = 1; i < 4; i++)
            {
                if (board[i, j] == type)
                {
                    count++;
                    if (count == 2)
                    {
                        type = "- ";
                        i = 0;
                        j = temp - first;
                    }
                    if (count == 3)
                    {
                        board[i, j] = "O ";
                        return true;
                    }
                }
                j += first;
            }
            return false;
        }

        static bool CheckColumnAndRow(string[,] board, string type, int x, int W)
        {
            int count = 0;
            string temp = type, st;
            for (int i = 1; i < 4; i++)
            {
                st = "";
                type = temp;
                count = 0;
                for (int j = 1; j < 4; j++)
                {
                    st = (x > 1 ? board[i, j] : board[j, i]);
                    if (st == type)
                    {
                        count++;
                        if (W < 0)
                        {
                            type = "- ";
                            j = 0;
                            W = 2;
                        }
                        if (count == 2 && W != 2)
                        {
                            type = "- ";
                            j = 0;
                        }

                        if (count > 2)
                        {
                            if (x > 1)
                            {
                                if ((W == 2) && ((board[i, j + 1] == "X " || board[i, j - 1] == "X " || board[i + 1, j] == "X ") || board[i - 1, j] == "X "))
                                    return false;
                                board[i, j] = "O ";
                                return true;
                            }
                               
                            else
                            {                                
                                if ((W == 2) && ((board[j, i + 1] == "X " || board[j, i - 1] == "X " || board[j + 1, i] == "X ") || board[j - 1, i] == "X "))
                                    return false;                                                                
                                board[j, i] = "O ";
                                return true;
                            }                              
                        }
                    }
                }
            }
            return false;
        }

        static string userInput(string[,] board)
        {
            string res;
            while (true)
            {
                res = "";
                Console.WriteLine("please enter the row");
                res += Console.ReadLine();
                if (res.Length == 1 && (res[0] == '1' || res[0] == '2' || res[0] == '3'))
                {
                    Console.WriteLine("please enter the column");
                    res += Console.ReadLine() + " ";
                    if ((res[1] == '1' || res[1] == '2' || res[1] == '3') && (board[int.Parse(res[0] + ""), int.Parse(res[1] + "")] == "- "))
                        break;
                }
                Console.WriteLine("Incorrect input");
            }
            return res;
        }


        static void arrayInitialize(string[,] board)
        {
            board[0, 0] = "  "; board[0, 1] = "1 "; board[0, 2] = "2 "; board[0, 3] = "3 ";
            board[1, 0] = "1 "; board[1, 1] = "- "; board[1, 2] = "- "; board[1, 3] = "- ";
            board[2, 0] = "2 "; board[2, 1] = "- "; board[2, 2] = "- "; board[2, 3] = "- ";
            board[3, 0] = "3 "; board[3, 1] = "- "; board[3, 2] = "- "; board[3, 3] = "- ";
        }

        static void printBoard(string[,] board)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}