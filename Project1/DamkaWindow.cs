using System.Timers;

namespace Project1
{
     using System;
     using System.Drawing;
     using System.Media;
     using System.Windows.Forms;

     public partial class DamkaWindow : Form
     {
          private static readonly SoundEffects sr_GameSoundEffects = new SoundEffects();
          private readonly PawnImages r_PawnsImages = new PawnImages();
          private const byte k_CheckerSize = 35;
          private DraughtsChecker m_FromChecker, m_ToChecker;
          private readonly Timer r_Timer = new Timer();
          private bool m_TimerStop;

          public DamkaWindow(DraughtsPlayer i_Player1, DraughtsPlayer i_Player2, DraughtsBoard io_Board)
          {
               InitializeComponent();
               createbuttons(io_Board);
               ResetAttributes(i_Player1, i_Player2, io_Board);
               r_Timer.Tick += this_TimerTick;
          }

          public void ResetAttributes(DraughtsPlayer i_Player1, DraughtsPlayer i_Player2, DraughtsBoard io_Board)
          {
               resizeDamkaWindow(i_Player1.Name, io_Board.Size);
               changePlayerLabels(i_Player1, i_Player2);
          }

          public void ResetButtons(ref DraughtsBoard io_Board)
          {
               byte i, j, boardSize = io_Board.Size;
               DraughtsChecker[,] checkers = io_Board.Checkers;

               for (i = (byte)(boardSize / 2 + 1); i < boardSize; i++)
               {
                    for (j = 0; j < boardSize; j++)
                    {
                         if((i + j + 1) % 2 != 0)
                         {
                              checkers[i, j].PawnContent.ChangePawnType("X");
                              checkers[i, j].BackgroundImage = r_PawnsImages.BlackPawn;
                         }
                         else
                         {
                              checkers[i, j].PawnContent.ChangePawnType(" ");
                         }
                    }
               }

               for (i = (byte)(boardSize / 2 - 1); i < boardSize / 2 + 1; i++)
               {
                    for (j = 0; j < boardSize; j++)
                    {
                         checkers[i, j].PawnContent.ChangePawnType(" ");
                         checkers[i, j].BackgroundImage = null;
                    }
               }

               for (i = 0; i < boardSize / 2 - 1; i++)
               {
                    for (j = 0; j < boardSize; j++)
                    {
                         if ((i + j + 1) % 2 != 0)
                         {
                              checkers[i, j].PawnContent.ChangePawnType("O");
                              checkers[i, j].BackgroundImage = r_PawnsImages.BrownPawn;
                         }
                         else
                         {
                              checkers[i, j].PawnContent.ChangePawnType(" ");
                         }
                    }
               }
          }

          private void changePlayerLabels(DraughtsPlayer i_Player1, DraughtsPlayer i_Player2)
          {
               player1ScoreLabel.Text = i_Player1.Name + ": " + i_Player1.Score;
               player2ScoreLabel.Text = i_Player2.Name + ": " + i_Player2.Score;
          }

          private void resizeDamkaWindow(string i_Player1Name, byte i_BoardSize)
          {
               int numOfRowsAndColToAdd = (i_BoardSize - 6) * k_CheckerSize;

               Width = 255 + numOfRowsAndColToAdd;
               Height = 370 + numOfRowsAndColToAdd;
               player2ScoreLabel.Location = new Point(130 + numOfRowsAndColToAdd, player2ScoreLabel.Location.Y);
               playerTurnLabel.Top = ClientSize.Height - 50;
               playerTurnLabel.Left = ClientSize.Width / 2 - playerTurnLabel.Width / 2;
               playerTurnLabel.Text = i_Player1Name + "'s Turn(X):";
               forfeitButton.Top = ClientSize.Height - 30;
               forfeitButton.Left = ClientSize.Width / 2 - forfeitButton.Width / 2;
          }

          private void createbuttons(DraughtsBoard o_Board)
          {
               Point startPosition = new Point(20, 63);

               createOButtons(startPosition, o_Board.Checkers, o_Board.Size);
               createSpacesButtons(startPosition, o_Board.Checkers, o_Board.Size);
               createXButtons(startPosition, o_Board.Checkers, o_Board.Size);
          }

          private void createXButtons(Point i_StartPosition, DraughtsChecker[,] o_Checkers, byte i_BoardSize)
          {
               byte i, j;

               for (i = (byte)(i_BoardSize / 2 + 1); i < i_BoardSize; i++)
               {
                    for (j = 0; j < i_BoardSize; j++)
                    {
                         if ((i + j + 1) % 2 != 0)
                         {
                              o_Checkers[i, j] = new DraughtsChecker(2, i, j, (i + j + 1) % 2 == 0);
                              o_Checkers[i, j].BackgroundImage = r_PawnsImages.BlackPawn;
                              o_Checkers[i, j].Click += draughtChecker_Click;
                         }
                         else
                         {
                              o_Checkers[i, j] = new DraughtsChecker(0, i, j, (i + j + 1) % 2 == 0);
                         }

                         addButtonAttributes(o_Checkers[i, j], i, j, i_StartPosition);
                         Controls.Add(o_Checkers[i, j]);
                    }
               }
          }

          private void createSpacesButtons(Point i_StartPosition, DraughtsChecker[,] o_Checkers, byte i_BoardSize)
          {
               byte i, j;

               for (i = (byte)(i_BoardSize / 2 - 1); i < i_BoardSize / 2 + 1; i++)
               {
                    for (j = 0; j < i_BoardSize; j++)
                    {
                         o_Checkers[i, j] = new DraughtsChecker(0, i, j, (i + j + 1) % 2 == 0);

                         if ((i + j + 1) % 2 != 0)
                         {
                              o_Checkers[i, j].Click += draughtChecker_Click;
                         }

                         addButtonAttributes(o_Checkers[i, j], i, j, i_StartPosition);
                         Controls.Add(o_Checkers[i, j]);
                    }
               }
          }

          private void createOButtons(Point i_StartPosition, DraughtsChecker[,] o_Checkers, byte i_BoardSize)
          {
               byte i, j;

               for (i = 0; i < i_BoardSize / 2 - 1; i++)
               {
                    for (j = 0; j < i_BoardSize; j++)
                    {
                         if ((i + j + 1) % 2 != 0)
                         {
                              o_Checkers[i, j] = new DraughtsChecker(1, i, j, (i + j + 1) % 2 == 0);
                              o_Checkers[i, j].Click += draughtChecker_Click;
                              o_Checkers[i, j].BackgroundImage = r_PawnsImages.BrownPawn;
                         }
                         else
                         {
                              o_Checkers[i, j] = new DraughtsChecker(0, i, j, (i + j + 1) % 2 == 0);
                         }

                         addButtonAttributes(o_Checkers[i, j], i, j, i_StartPosition);
                         Controls.Add(o_Checkers[i, j]);
                    }
               }
          }

          private void addButtonAttributes(DraughtsChecker o_Checker, byte i_RowPos, byte i_ColPos, Point i_StartPosition)
          {
               o_Checker.Size = new Size(k_CheckerSize, k_CheckerSize);
               o_Checker.Location = new Point(i_StartPosition.X + i_ColPos * k_CheckerSize, i_StartPosition.Y + i_RowPos * k_CheckerSize);
               o_Checker.ContentChanged += draughtChecker_ContentChanged;
          }

          public static void PlayKingSound()
          {
               sr_GameSoundEffects.PlayKingSound();
          }

          public static void PlayEatingSound()
          {
               sr_GameSoundEffects.PlayEatingSound();
          }

          private void draughtChecker_ContentChanged(object sender, CheckerEventArgs e)
          {
               if(sender is DraughtsChecker changedChecker)
               {
                    if (e.NewContent == "X")
                    {
                         changedChecker.BackgroundImage = r_PawnsImages.BlackPawn;
                    }
                    else if (e.NewContent == "O")
                    {
                         changedChecker.BackgroundImage = r_PawnsImages.BrownPawn;
                    }
                    else if (e.NewContent == "K")
                    {
                         changedChecker.BackgroundImage = r_PawnsImages.BlackKing;
                    }
                    else if (e.NewContent == "U")
                    {
                         changedChecker.BackgroundImage = r_PawnsImages.BrownKing;
                    }
                    else
                    {
                         changedChecker.BackgroundImage = null;
                    }
               }
          }

          private void draughtChecker_Click(object sender, EventArgs e)
          {
               sr_GameSoundEffects.PlayClickSound();
               if (sender is DraughtsChecker clickedChecker && clickedChecker.Enabled)
               {
                    if (clickedChecker.BackColor == Color.White)
                    {
                         clickedChecker.BackColor = Color.Aquamarine;

                         if (m_FromChecker == null)
                         {
                              if (DraughtsMove.CheckerBelongToPlayer(clickedChecker, DraughtsGame.MovesCounter))
                              {
                                   m_FromChecker = clickedChecker;
                              }
                              else
                              {
                                   DisplayErrorMsg("Checker doesn't belong to player.");
                                   clickedChecker.BackColor = Color.White;
                              }

                         }
                         else if (m_ToChecker == null)
                         {
                              m_ToChecker = clickedChecker;
                              DraughtsGame.PlayGame(this);
                              m_ToChecker.BackColor = Color.White;
                              m_FromChecker.BackColor = Color.White;

                              if (DraughtsGame.GameStatus == DraughtsGame.eGameStatus.Stillplaying)
                              {
                                   if (DraughtsGame.MovesCounter % 2 == 1 && DraughtsGame.Player2.Name == "Computer")
                                   {
                                        DraughtsGame.PlayGame(this);
                                   }
                              }

                              m_ToChecker = null;
                              m_FromChecker = null;
                         }
                         else
                         {
                              clickedChecker.BackColor = Color.White;
                              MessageBox.Show("You cannot pick more then one checker.");
                         }
                    }
                    else
                    {
                         clickedChecker.BackColor = Color.White;
                         m_FromChecker = null;
                    }
               }
          }

          private void this_TimerTick(object sender, EventArgs e)
          {
               r_Timer.Stop();
               m_TimerStop = true;
          }

          public void DisplayTurn(DraughtsPlayer i_CurrentPlayer, DraughtsPlayer i_Player1, DraughtsPlayer i_Player2)
          {
               if (i_CurrentPlayer == i_Player1)
               {
                    playerTurnLabel.Text = i_CurrentPlayer.Name + "'s Turn(X):";
               }
               else if (i_CurrentPlayer.Name != "Computer")
               {
                    playerTurnLabel.Text = i_Player2.Name + "'s Turn(O): ";
               }
               else
               {
                    playerTurnLabel.Text = "Now it's computer's turn..";
                    m_ToChecker.BackColor = Color.White;
                    m_FromChecker.BackColor = Color.White;
                    m_TimerStop = false;
                    r_Timer.Interval = 2000;
                    r_Timer.Start();
                    while (m_TimerStop == false)
                    {
                         Application.DoEvents();
                    }
               }
          }

          public DraughtsMove GetPlayerMove(int i_Counter, DraughtsPlayer i_Player, DraughtsBoard i_Board)
          {
               DraughtsChecker fromChecker, toChecker;

               if (i_Player.Name == "Computer")
               {
                    DraughtsGame.Computer.getComputerMove(i_Board, out fromChecker, out toChecker);
               }
               else
               {
                    fromChecker = m_FromChecker;
                    toChecker = m_ToChecker;
               }

               return new DraughtsMove(fromChecker, toChecker);
          }

          public bool DisplayWinnerAndUpdateScores(DraughtsPlayer i_WinningPlayer, DraughtsPlayer i_LosingPlayer, DraughtsGame.eGameStatus i_GameStatus, int i_NumOfMoves)
          {
               string message;
               string caption = "Damka";

               if (i_GameStatus == DraughtsGame.eGameStatus.Tie)
               {
                    message = "Game finished as draw, no winner is decided." + Environment.NewLine + "Another round?";
               }
               else
               {
                    sr_GameSoundEffects.PlayWinSound();
                    i_WinningPlayer.Score += (i_WinningPlayer.KingAmount - i_LosingPlayer.KingAmount) * 4
                                             + (i_WinningPlayer.PawnAmount - i_LosingPlayer.PawnAmount);

                    message = "The winner is " + i_WinningPlayer.Name + " in " + i_NumOfMoves + " moves!" + Environment.NewLine + "Another round?";
               }
               DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

               return result == DialogResult.Yes;
          }

          public static void AlertPlayerAboutAnotherJump(DraughtsMove i_ChosenMove)
          {
               DraughtsChecker fromChecker = i_ChosenMove.FromDraughtChecker, toChecker = i_ChosenMove.ToDraughtChecker;
               string theMove = "(" + fromChecker.ColPosition + ", " + fromChecker.RowPosition + ") -> ("
                                + toChecker.ColPosition + ", " + toChecker.RowPosition + ")";
               string message = "Another jump is possible, the computer will preform the following move:" + Environment.NewLine + theMove;
               string caption = "Jump picker";
               MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
          }

          private void forfeitButton_Click(object sender, EventArgs e)
          {
               string playerName = DraughtsGame.MovesCounter % 2 == 0 ? DraughtsGame.Player1.Name : DraughtsGame.Player2.Name;
               string msg = playerName + ", are you sure you want to forfeit?", caption = "Forfeit";
               DialogResult result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

               if (result == DialogResult.Yes)
               {
                    if (m_FromChecker != null)
                    {
                         m_FromChecker.BackColor = Color.White;
                         m_FromChecker = null;
                    }

                    DraughtsGame.PlayerForefit(playerName);
                    DraughtsGame.PlayGame(this);
               }  
          }

          public static void DisplayErrorMsg(string i_Msg)
          {
               MessageBox.Show(i_Msg);
          }
     }   
}    