namespace Project1
{
     using System.Collections.Generic;

     public class ComputerAI
     {
          public void getComputerMove(DraughtsBoard i_Board, out DraughtsChecker o_FromChecker, out DraughtsChecker o_ToChecker)
          {
               List<DraughtsMove> computerPossibleMoves = new List<DraughtsMove>();
               List<DraughtsChecker> checkerBelongToComputer = new List<DraughtsChecker>();
               DraughtsMove possibleMove = null, pickedComputerMove = null;

               getPlayerCheckers(i_Board, ref checkerBelongToComputer);
               foreach (DraughtsChecker computerChecker in checkerBelongToComputer)
               {
                    i_Board.MakePlayerJumps(ref computerPossibleMoves, computerChecker);
                    i_Board.MakePlayerSteps(ref computerPossibleMoves, computerChecker);

                    for (int i = 0; i < computerPossibleMoves.Count; i++)
                    {
                         if (computerPossibleMoves[i].IsBackJump() || computerPossibleMoves[i].IsForwardJump())
                         {
                              pickedComputerMove = computerPossibleMoves[i];
                              goto foundMove;
                         }

                         if (computerPossibleMoves[i].FromDraughtChecker.RowPosition != 0
                            && computerPossibleMoves[i].FromDraughtChecker.RowPosition != i_Board.Size - 1)
                         {
                              pickedComputerMove = computerPossibleMoves[i];
                         }

                         possibleMove = computerPossibleMoves[i];
                    }

                    computerPossibleMoves.Clear();
               }
               pickedComputerMove = possibleMove;

          foundMove:
               o_FromChecker = pickedComputerMove.FromDraughtChecker;
               o_ToChecker = pickedComputerMove.ToDraughtChecker; 
          }

          private void getPlayerCheckers(DraughtsBoard i_Board, ref List<DraughtsChecker> io_PlayerCheckers)
          {
               byte boardSize = i_Board.Size;

               for (byte i = 0; i < boardSize; i++)
               {
                    for (byte j = 0; j < boardSize; j++)
                    {
                         DraughtsChecker currentChecker = i_Board.GetCheckerFromBoard(i, j);

                         if (currentChecker.PawnContent.IsPlayer2())
                         {
                              io_PlayerCheckers.Add(currentChecker);
                         }
                    }
               }
          }
     }
}
