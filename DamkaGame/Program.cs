using System;
using System.Windows.Forms;

namespace DamkaGame
{
     using Project1;

     public class Program
     {
          public static void Main()
          {
               GameSettings gameSettingWindow = new GameSettings();

               gameSettingWindow.ShowDialog();
               if (gameSettingWindow.wasClosedByXButton == false)
               {
                    DraughtsGame.InitGame(gameSettingWindow.Player1Name, gameSettingWindow.Player2Name, gameSettingWindow.BoardSize);
                    DamkaWindow gameWindow = new DamkaWindow(DraughtsGame.Player1, DraughtsGame.Player2, DraughtsGame.Board);
                    gameWindow.ShowDialog();
               }
          }
     }
}
