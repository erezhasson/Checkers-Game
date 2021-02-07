namespace Project1
{
     public class NameAuthenticator
     {
          private const byte k_MaxNameLength = 8;

          public static bool ValidiateNames(string i_Player1Name, string i_Player2Name, bool i_Player2TextChanged, out string i_Msg)
          {
               return checkPlayerName(i_Player1Name, out i_Msg) && checkPlayerName(i_Player2Name, out i_Msg) && checkIfNamesAreDifferent(i_Player1Name, i_Player2Name, out i_Msg)
                    && namesAreValid(i_Player1Name, i_Player2Name, i_Player2TextChanged,  out i_Msg);
          }

          private static bool namesAreValid(string i_Player1Name, string i_Player2Name, bool i_Player2TextChanged, out string i_Msg)
          {
               bool validName = true;
               
               i_Msg = null;
               if (i_Player1Name.Contains("Computer") || i_Player2Name.Contains("Computer") && i_Player2TextChanged)
               {
                    i_Msg = "You can't pick the name computer.";
                    validName = false;
               }

               return validName;
          }

          private static bool checkIfNamesAreDifferent(string i_Player1Name, string i_Player2Name, out string i_Msg)
          {
               bool validName = i_Player1Name != i_Player2Name;

               i_Msg = null;
               if (!validName)
               {
                    i_Msg = "You can't pick the same name for both players.";
               }

               return validName;
          }

          private static bool checkPlayerName(string i_PlayerName, out string i_Msg)
          {
               bool validName = !string.IsNullOrEmpty(i_PlayerName) && i_PlayerName.Length <= k_MaxNameLength;

               i_Msg = null;
               if (validName)
               {
                    for (int i = 0; i < i_PlayerName.Length; i++)
                    {
                         if (!char.IsLetter(i_PlayerName[i]))
                         {
                              validName = false;
                              break;
                         }
                    }
               }
               else
               {
                    i_Msg = "Names can only contain maximum 8 letters and without spaces.";
               }

               return validName;
          }
     }
}
