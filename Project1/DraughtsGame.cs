namespace Project1
{
     using System;
     using System.Collections.Generic;

     public class DraughtsGame
     {
          private static DraughtsPlayer s_Player1, s_Player2;
          private static DraughtsBoard s_Board;
          private static eGameModes s_GameMode;
          private static eGameStatus s_GameStatus = eGameStatus.Stillplaying;
          private static int s_MovesCounter;
          private static readonly ComputerAI sr_Computer = new ComputerAI();

          public enum eGameModes
          {
               PvP = 1,
               PvE = 2
          }

          public enum eGameStatus
          {
               Stillplaying = 0,
               Player1Win = 1,
               Player2Win = 2,
               Tie = 3,

          }

          public static ComputerAI Computer
          {
               get
               {
                    return sr_Computer;
               }
          }

          public static DraughtsPlayer Player1
          {
               get
               {
                    return s_Player1;
               }

               set
               {
                    s_Player1 = value;
               }
          }

          public static DraughtsPlayer Player2
          {
               get
               {
                    return s_Player2;
               }

               set
               {
                    s_Player2 = value;
               }
          }

          public static DraughtsBoard Board
          {
               get
               {
                    return s_Board;
               }
          }

          public static eGameStatus GameStatus
          {
               get
               {
                    return s_GameStatus;
               }

               set
               {
                    s_GameStatus = value;
               }
          }

          public static eGameModes GameMode
          {
               get
               {
                    return s_GameMode;
               }

               set
               {
                    s_GameMode = value;
               }
          }

          public static int MovesCounter
          {
               get
               {
                    return s_MovesCounter;
               }
          }

          public static void InitGame(string i_Player1Name, string i_Player2Name, byte i_BoardSize)
          {
               s_Board = new DraughtsBoard(i_BoardSize);
               s_Player1 = new DraughtsPlayer(i_Player1Name, "X");
               s_Player2 = new DraughtsPlayer(i_Player2Name, "O");
               s_GameMode = i_Player2Name == "Computer" ? eGameModes.PvE : eGameModes.PvP;
               
               byte checkersAmount = (byte)((s_Board.Size / 2 - 1) * (s_Board.Size / 2));
               s_Player1.PawnAmount = checkersAmount;
               s_Player2.PawnAmount = checkersAmount;
          }

          public static void PlayGame(DamkaWindow io_Window)
          {
               DraughtsPlayer currentPlayer = s_MovesCounter % 2 == 0 ? s_Player1 : s_Player2;
               DraughtsPlayer lastPlayer = currentPlayer == s_Player1 ? s_Player2 : s_Player1;

               if (s_GameStatus == eGameStatus.Stillplaying)
               {
                    DraughtsMove playerMove = io_Window.GetPlayerMove(s_MovesCounter, currentPlayer, s_Board);

                    if (s_Board.CheckIfLegalCheckers(playerMove) && s_Board.IsLegalGameMove(playerMove))
                    {
                         makePlayerMove(s_Board, playerMove, currentPlayer);                 
                         s_MovesCounter++;
                         swapPlayers(ref lastPlayer, ref currentPlayer);
                         s_GameStatus = checkGameStatus(lastPlayer, currentPlayer);
                    }
                    io_Window.DisplayTurn(currentPlayer, s_Player1, s_Player2);
               }

               if (s_GameStatus != eGameStatus.Stillplaying)
               {
                    if (io_Window.DisplayWinnerAndUpdateScores(lastPlayer, currentPlayer, s_GameStatus, s_MovesCounter))
                    {
                         io_Window.ResetAttributes(s_Player1, s_Player2, s_Board);
                         io_Window.ResetButtons(ref s_Board);
                         resetGame();
                    }
                    else
                    {
                         io_Window.Close();
                    }
               }              
          }

          public static void PlayerForefit(string i_PlayerName)
          {
               DraughtsPlayer currentPlayer = i_PlayerName == s_Player1.Name ? s_Player1 : s_Player2;

               currentPlayer.KingAmount = 0;
               currentPlayer.PawnAmount = 0;
               s_GameStatus = currentPlayer == s_Player1 ? eGameStatus.Player2Win : eGameStatus.Player1Win;
          }

          private static void makePlayerMove(DraughtsBoard i_GameBoard, DraughtsMove i_PlayerMove, DraughtsPlayer i_CurrentPlayer)
          {
               DraughtsChecker fromChecker = i_PlayerMove.FromDraughtChecker, toChecker = i_PlayerMove.ToDraughtChecker;

               toChecker.ChangeContent(fromChecker.PawnContent.CheckerType);
               fromChecker.ChangeContent(" ");

               if (i_GameBoard.CheckIfPawnBecomeKingAndConvert(i_PlayerMove))
               {
                    i_CurrentPlayer.KingAmount++;
                    i_CurrentPlayer.PawnAmount--;
               }

               if (i_PlayerMove.IsForwardJump() || i_PlayerMove.IsBackJump())
               {
                    DraughtsPlayer pawnEatenBelongTo = i_CurrentPlayer.Name == s_Player1.Name ? s_Player2 : s_Player1;
                    List<DraughtsMove> avaliableMoves = new List<DraughtsMove>();

                    DamkaWindow.PlayEatingSound();
                    i_GameBoard.KillPawnAndDecreaseAmount(i_PlayerMove, pawnEatenBelongTo);
                    i_GameBoard.MakePlayerJumps(ref avaliableMoves, toChecker);

                    if (avaliableMoves.Count != 0)
                    {
                         makePlayerMove(i_GameBoard, avaliableMoves[getNextJump(ref avaliableMoves, i_CurrentPlayer)], i_CurrentPlayer);
                    }
               }
          }

          private static int getNextJump(ref List<DraughtsMove> i_AvaliableMoves, DraughtsPlayer i_CurrentPlayer)
          {
               int chosenMove = 0;

               if (i_AvaliableMoves.Count != 1)
               {
                    Random randMoveIndex = new Random();
                    chosenMove = randMoveIndex.Next(0, i_AvaliableMoves.Count - 1);
               }

               if (i_CurrentPlayer.Name != "Computer")
               {
                    DamkaWindow.AlertPlayerAboutAnotherJump(i_AvaliableMoves[chosenMove]);
               }

               return chosenMove;
          }

          private static void swapPlayers(ref DraughtsPlayer io_lastPlayer, ref DraughtsPlayer io_currentPlayer)
          {
               DraughtsPlayer tempPlayerHolder = io_lastPlayer;

               io_lastPlayer = io_currentPlayer;
               io_currentPlayer = tempPlayerHolder;
          }

          private static eGameStatus checkGameStatus(DraughtsPlayer i_LastPlayer, DraughtsPlayer i_CurrentPlayer)
          {
               eGameStatus gameStatus = eGameStatus.Stillplaying;

               if (i_CurrentPlayer.PawnAmount == 0 && i_CurrentPlayer.KingAmount == 0)
               {
                    gameStatus = i_CurrentPlayer == s_Player1 ? eGameStatus.Player2Win : eGameStatus.Player1Win;
               }

               if (!s_Board.CheckIfGameMovesRemaining(i_CurrentPlayer.PawnType))
               {
                    if (!s_Board.CheckIfGameMovesRemaining(i_LastPlayer.PawnType))
                    {
                         gameStatus = eGameStatus.Tie;
                    }

                    else
                    {
                         gameStatus = i_LastPlayer == s_Player1 ? eGameStatus.Player1Win : eGameStatus.Player2Win;
                    }
               }

               return gameStatus;
          }

          private static void resetGame()
          {
               short numOfPawns = (short)((s_Board.Size / 2 - 1) * (s_Board.Size / 2));

               s_Player1.PawnAmount = (byte)numOfPawns;
               s_Player2.PawnAmount = (byte)numOfPawns;
               s_Player1.KingAmount = 0;
               s_Player2.KingAmount = 0;
               s_MovesCounter = 0;
               s_GameStatus = eGameStatus.Stillplaying;
          }
     }
}
