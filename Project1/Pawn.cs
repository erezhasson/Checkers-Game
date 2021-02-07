namespace Project1
{
     public class Pawn
     {
          private ePawnType m_Type;

          public enum ePawnType
          {
               NONE = 0,
               O = 1,
               X = 2,
               U = 3,
               K = 4
          }

          public Pawn(byte i_CheckerType)
          {
               m_Type = (ePawnType)i_CheckerType;
          }

          public void ChangePawnType(string i_Type)
          {
               m_Type = ConvertStringToPawnType(i_Type);
          }

          public string CheckerType
          {
               get
               {
                    return m_Type == ePawnType.NONE ? " " : m_Type.ToString();
               }

               set
               {
                    m_Type = (ePawnType)byte.Parse(value);
               }
          }

          public bool IsKing()
          {
               return m_Type == ePawnType.K || m_Type == ePawnType.U;
          }

          public bool IsSoldier()
          {
               return m_Type == ePawnType.X || m_Type == ePawnType.O;
          }

          public bool IsX()
          {
               return m_Type == ePawnType.X;
          }

          public bool IsO()
          {
               return m_Type == ePawnType.O;
          }

          public bool IsU()
          {
               return m_Type == ePawnType.U;
          }

          public bool IsK()
          {
               return m_Type == ePawnType.K;
          }

          public bool IsPlayer1()
          {
               return IsX() || IsK();
          }

          public bool IsPlayer2()
          {
               return IsO() || IsU();
          }

          public bool IsDifferentTeam(Pawn i_OtherPawn)
          {
               return i_OtherPawn.IsPlayer1() && IsPlayer2() || i_OtherPawn.IsPlayer2() && IsPlayer1();
          }

          public bool IsNone()
          {
               return m_Type == ePawnType.NONE;
          }

          private ePawnType ConvertStringToPawnType(string i_PawnTypeInString)
          {
               ePawnType pawnType = ePawnType.NONE;

               if (i_PawnTypeInString == "X")
               {
                    pawnType = ePawnType.X;
               }

               if (i_PawnTypeInString == "O")
               {
                    pawnType = ePawnType.O;
               }

               if (i_PawnTypeInString == "U")
               {
                    pawnType = ePawnType.U;
               }

               if (i_PawnTypeInString == "K")
               {
                    pawnType = ePawnType.K;
               }

               return pawnType;
          }
     }
}



