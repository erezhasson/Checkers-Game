namespace Project1
{
     using System.Collections.Generic;

     public class DraughtsBoard
     {
          private byte m_RowsColsSize;
          private readonly DraughtsChecker[,] m_Checkers;

          public DraughtsBoard(byte i_Size)
          {
               m_Checkers = new DraughtsChecker[i_Size, i_Size];
               m_RowsColsSize = i_Size;
          }

          public DraughtsChecker[,] Checkers
          {
               get
               {
                    return m_Checkers;
               }
          }

          public byte Size
          {
               get
               {
                    return m_RowsColsSize;
               }
               set
               {
                    m_RowsColsSize = value;
               }
          }

          private bool checkIfPawnHasGameMovesRemaning(DraughtsChecker i_Checker)
          {
               List<DraughtsMove> possibleMoves = new List<DraughtsMove>();

               MakePlayerSteps(ref possibleMoves, i_Checker);
               MakePlayerJumps(ref possibleMoves, i_Checker);

               return possibleMoves.Count != 0;
          }

          public bool CheckIfGameMovesRemaining(string i_PawnType)
          {
               bool hasRemainingMove = false;
               bool isPlayer1 = i_PawnType == "X";  

               for (int i = 0; i < m_RowsColsSize; i++)
               {
                    for (int j = 0; j < m_RowsColsSize; j++)
                    {
                         if (m_Checkers[i, j].PawnContent.IsPlayer1() && isPlayer1 || m_Checkers[i, j].PawnContent.IsPlayer2() && !isPlayer1)
                         {
                              if (checkIfPawnHasGameMovesRemaning(m_Checkers[i, j]))
                              {
                                   hasRemainingMove = true;
                                   goto FOUNDMOVE;
                              }
                         }
                    }
               }

          FOUNDMOVE:
               return hasRemainingMove;
          }

          public bool CheckIfPawnBecomeKingAndConvert(DraughtsMove i_PlayerMove)
          {
               Pawn movingPawn = i_PlayerMove.ToDraughtChecker.PawnContent;
               bool isKing = false;

               if (movingPawn.IsX())
               {
                    if (i_PlayerMove.ToDraughtChecker.RowPosition == 0)
                    {
                         i_PlayerMove.ToDraughtChecker.ChangeContent("K");
                         isKing = true;
                    }
               }
               else if (movingPawn.IsO())
               {
                    if (i_PlayerMove.ToDraughtChecker.RowPosition == m_RowsColsSize - 1)
                    {
                         i_PlayerMove.ToDraughtChecker.ChangeContent("U");
                         isKing = true;
                    }
               }
               if (isKing)
               {
                    DamkaWindow.PlayKingSound();
               }

               return isKing;
          }

          public DraughtsChecker GetCheckerFromBoard(short i_RowPosition, short i_ColPosition)
          {
               DraughtsChecker checkerInBoard = null;

               if (i_RowPosition >= 0 && i_RowPosition < m_RowsColsSize && i_ColPosition >= 0 && i_ColPosition < m_RowsColsSize)
               {
                    checkerInBoard = m_Checkers[i_RowPosition, i_ColPosition];
               }

               return checkerInBoard;
          }

          private bool jumpIsPossible(DraughtsChecker i_FromChecker, DraughtsChecker i_ToChecker)
          {
               DraughtsMove checkersMove = new DraughtsMove(i_FromChecker, i_ToChecker);

               return i_FromChecker != null && i_ToChecker != null && checkDifferenceInJump(i_FromChecker, i_ToChecker)
                      && i_ToChecker.PawnContent.IsNone() && !checkersMove.IsBackStep() && !checkersMove.IsForwardStep();
          }

          private bool stepIsPossible(DraughtsChecker i_FromChecker, DraughtsChecker i_ToChecker)
          {
               DraughtsMove checkersMove = new DraughtsMove(i_FromChecker, i_ToChecker);

               return i_FromChecker != null && i_ToChecker != null && i_ToChecker.PawnContent.IsNone() && !checkersMove.IsForwardJump() && !checkersMove.IsBackJump();
          }

          private List<DraughtsMove> makePawnMoves(DraughtsChecker i_PawnPosition, List<DraughtsChecker> i_CheckersAroundPawn)
          {
               List<DraughtsMove> possibleMoves = new List<DraughtsMove>();

               foreach (DraughtsChecker toCheckerPosition in i_CheckersAroundPawn)
               {
                    bool jumpIsPossible = this.jumpIsPossible(i_PawnPosition, toCheckerPosition), stepIsPossible = this.stepIsPossible(i_PawnPosition, toCheckerPosition);

                    if (jumpIsPossible && !stepIsPossible || !jumpIsPossible && stepIsPossible)
                    {
                         DraughtsMove possibleMove = new DraughtsMove(i_PawnPosition, toCheckerPosition);
                         possibleMoves.Add(possibleMove);
                    }
               }

               return possibleMoves;
          }

          public void MakePlayerSteps(ref List<DraughtsMove> io_availableMoves, DraughtsChecker i_PawnPosition)
          {
               Pawn pawn = i_PawnPosition.PawnContent;
               List<DraughtsChecker> checkersAroundPawn = new List<DraughtsChecker>
          {
               GetCheckerFromBoard((byte)(i_PawnPosition.RowPosition + 1), (byte)(i_PawnPosition.ColPosition - 1)),
               GetCheckerFromBoard((byte)(i_PawnPosition.RowPosition + 1), (byte)(i_PawnPosition.ColPosition + 1)),
               GetCheckerFromBoard((byte)(i_PawnPosition.RowPosition - 1), (byte)(i_PawnPosition.ColPosition - 1)),
               GetCheckerFromBoard((byte)(i_PawnPosition.RowPosition - 1), (byte)(i_PawnPosition.ColPosition + 1))
          };

               if (pawn.IsX())
               {
                    checkersAroundPawn.RemoveRange(0, 2);
               }     
               else if (pawn.IsO())
               {
                    checkersAroundPawn.RemoveRange(2, 2);
               }

               io_availableMoves.AddRange(makePawnMoves(i_PawnPosition, checkersAroundPawn));
          }

          public void MakePlayerJumps(ref List<DraughtsMove> io_availableMoves, DraughtsChecker i_PawnPosition)
          {
               Pawn pawn = i_PawnPosition.PawnContent;
               List<DraughtsChecker> checkersAroundPawn = new List<DraughtsChecker>
          {
               GetCheckerFromBoard((byte)(i_PawnPosition.RowPosition + 2), (byte)(i_PawnPosition.ColPosition - 2)),
               GetCheckerFromBoard((byte)(i_PawnPosition.RowPosition + 2), (byte)(i_PawnPosition.ColPosition + 2)),
               GetCheckerFromBoard((byte)(i_PawnPosition.RowPosition - 2), (byte)(i_PawnPosition.ColPosition - 2)),
               GetCheckerFromBoard((byte)(i_PawnPosition.RowPosition - 2), (byte)(i_PawnPosition.ColPosition + 2))
          };

               if (pawn.IsX())
               {
                    checkersAroundPawn.RemoveRange(0, 2);
               }
               else if (pawn.IsO())
               {
                    checkersAroundPawn.RemoveRange(2, 2);
               }

               io_availableMoves.AddRange(makePawnMoves(i_PawnPosition, checkersAroundPawn));
          }

          public void KillPawnAndDecreaseAmount(DraughtsMove i_PlayerMove, DraughtsPlayer i_PawnEatenBelongTo)
          {
               DraughtsChecker fromChecker = i_PlayerMove.FromDraughtChecker;
               DraughtsChecker toChecker = i_PlayerMove.ToDraughtChecker;
               byte rowIndex = (byte)((fromChecker.RowPosition + toChecker.RowPosition) / 2);
               byte colIndex = (byte)((fromChecker.ColPosition + toChecker.ColPosition) / 2);
               Pawn eatenPawn = GetCheckerFromBoard(rowIndex, colIndex).PawnContent;

               if (eatenPawn.IsKing())
               {
                    i_PawnEatenBelongTo.KingAmount--;
               }
               else
               {
                    i_PawnEatenBelongTo.PawnAmount--;
               }

               GetCheckerFromBoard(rowIndex, colIndex).ChangeContent(" ");
          }

          private bool checkDifferenceInJump(DraughtsChecker i_FromChecker, DraughtsChecker i_ToChecker)
          {
               byte rowIndex = (byte)((i_FromChecker.RowPosition + i_ToChecker.RowPosition) / 2);
               byte colIndex = (byte)((i_FromChecker.ColPosition + i_ToChecker.ColPosition) / 2);
               Pawn fromPawn = i_FromChecker.PawnContent;
               Pawn eatenPawn = GetCheckerFromBoard(rowIndex, colIndex).PawnContent;

               return fromPawn.IsDifferentTeam(eatenPawn) && !eatenPawn.IsNone();
          }

          public bool IsLegalGameMove(DraughtsMove i_PlayerMove)
          {
               Pawn movingPawn = i_PlayerMove.FromDraughtChecker.PawnContent;
               bool legalMove;

               if (i_PlayerMove.IsBackJump() || i_PlayerMove.IsForwardJump())
               {
                    legalMove = checkDifferenceInJump(i_PlayerMove.FromDraughtChecker, i_PlayerMove.ToDraughtChecker);

                    if (legalMove == false)
                    {
                         DamkaWindow.DisplayErrorMsg("Invalid turn - you have to eat only rival's pawns.");
                    }
               }
               else if (!movingPawn.IsKing())
               {
                    legalMove = movingPawn.IsPlayer1() ? i_PlayerMove.IsBackStep() : i_PlayerMove.IsForwardStep();

                    if (legalMove == false)
                    {
                         DamkaWindow.DisplayErrorMsg("Invalid turn - you can move only a single step or jump.");
                    }
               }
               else
               {
                    legalMove = i_PlayerMove.IsKingMove();

                    if (legalMove == false)
                    {
                         DamkaWindow.DisplayErrorMsg("Invalid turn - you can move only a single step or jump.");
                    }
               }

               return legalMove;
          }

          public bool CheckIfLegalCheckers(DraughtsMove i_PlayerMove)
          {
               bool isLegalChecekers = !i_PlayerMove.FromDraughtChecker.PawnContent.IsNone()
                                       && i_PlayerMove.ToDraughtChecker.PawnContent.IsNone();

               if (isLegalChecekers == false)
               {
                    DamkaWindow.DisplayErrorMsg("Invalid turn - you have to move a pawn to empty checker in board.");
               }

               return isLegalChecekers;
          }
     }
}
