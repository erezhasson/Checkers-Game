namespace Project1
{
     public class DraughtsMove
     {
          private readonly DraughtsChecker m_ToChecker, m_FromChecker;
          private const byte m_TurnLength = 5;

          public DraughtsChecker FromDraughtChecker
          {
               get
               {
                    return m_FromChecker;
               }
          }

          public DraughtsChecker ToDraughtChecker
          {
               get
               {
                    return m_ToChecker;
               }
          }

          public bool IsBackJump()
          {
               return FromDraughtChecker.RowPosition - 2 == ToDraughtChecker.RowPosition
                      && (FromDraughtChecker.ColPosition - 2 == ToDraughtChecker.ColPosition
                      || FromDraughtChecker.ColPosition + 2 == ToDraughtChecker.ColPosition);
          }
          public bool IsBackStep()
          {
               return FromDraughtChecker.RowPosition - 1 == ToDraughtChecker.RowPosition
                      && (FromDraughtChecker.ColPosition - 1 == ToDraughtChecker.ColPosition
                          || FromDraughtChecker.ColPosition + 1 == ToDraughtChecker.ColPosition);
          }

          public bool IsForwardMove()
          {
               return IsForwardStep() || IsForwardJump();
          }

          public bool IsBackMove()
          {
               return IsBackStep() || IsBackJump();
          }

          public bool IsKingJump()
          {
               return IsBackJump() || IsForwardJump();
          }

          public bool IsKingStep()
          {
               return IsBackStep() || IsForwardStep();
          }

          public bool IsKingMove()
          {
               return IsKingJump() || IsKingStep();
          }

          public bool IsForwardStep()
          {
               return FromDraughtChecker.RowPosition + 1 == ToDraughtChecker.RowPosition
                      && (FromDraughtChecker.ColPosition - 1 == ToDraughtChecker.ColPosition
                          || FromDraughtChecker.ColPosition + 1 == ToDraughtChecker.ColPosition);
          }
          public bool IsForwardJump()
          {
               return FromDraughtChecker.RowPosition + 2 == ToDraughtChecker.RowPosition
                      && (FromDraughtChecker.ColPosition - 2 == ToDraughtChecker.ColPosition
                          || FromDraughtChecker.ColPosition + 2 == ToDraughtChecker.ColPosition);
          }

          public DraughtsMove(DraughtsChecker i_FromChecker, DraughtsChecker i_ToChecker)
          {
               m_FromChecker = i_FromChecker;
               m_ToChecker = i_ToChecker;
          }

          public static bool CheckerBelongToPlayer(DraughtsChecker i_Checker, int i_Counter)
          {
               Pawn pawnInChecker = i_Checker.PawnContent;

               return i_Counter % 2 == 0 ? pawnInChecker.IsPlayer1() : pawnInChecker.IsPlayer2(); 
          }
     }
}


