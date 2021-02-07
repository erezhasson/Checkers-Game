namespace Project1
{
     public class DraughtsPlayer
     {
          private string m_Name;
          private readonly string r_PawnType;
          private byte m_PawnAmount, m_KingAmount;
          private int m_Score;

          public DraughtsPlayer(string i_Name, string i_PawnType)
          {
               m_Name = i_Name;
               r_PawnType = i_PawnType;
               m_Score = 0;
               m_KingAmount = 0;
          }

          public string Name
          {
               get
               {
                    return m_Name;
               }
               set
               {
                    m_Name = value;
               }
          }

          public string PawnType
          {
               get
               {
                    return r_PawnType;
               }
          }

          public int Score
          {
               get
               {
                    return m_Score;
               }

               set
               {
                    m_Score = value;
               }
          }

          public byte PawnAmount
          {
               get
               {
                    return m_PawnAmount;
               }
               set
               {
                    m_PawnAmount = value;
               }
          }

          public byte KingAmount
          {
               get
               {
                    return m_KingAmount;
               }
               set
               {
                    m_KingAmount = value;
               }
          }
     }

}


