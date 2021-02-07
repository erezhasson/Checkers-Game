namespace Project1
{
     using System;
     using System.Drawing;
     using System.Windows.Forms;

     public partial class GameSettings : Form
     {
          private string m_Player1Name = null, m_Player2Name = "Computer";
          private byte m_BoardSize = 6;
          private bool m_FormClosedByXButton = true, m_Player2TextChanged;
          private readonly SoundEffects r_SoundEffects = new SoundEffects();

          public bool wasClosedByXButton
          {
               get
               {
                    return m_FormClosedByXButton;
               }
          }

          public GameSettings()
          {
               InitializeComponent();
          }

          public string Player1Name
          {
               get
               {
                    return m_Player1Name;
               }
          }

          public string Player2Name
          {
               get
               {
                    return m_Player2Name;
               }
          }

          public byte BoardSize
          {
               get
               {
                    return m_BoardSize;
               }
          }

          private void player2CheckBox_CheckedChanged(object sender, EventArgs e)
          {
               r_SoundEffects.PlayClickSound();

               if (player2CheckBox.Checked)
               {
                    player2TextBox.Enabled = true;
                    m_Player2TextChanged = true;
                    player2TextBox.BackColor = Color.White;
                    player2TextBox.Text = string.Empty;
                    player2TextBox.ForeColor = Color.Black;
               }

               else
               {
                    player2TextBox.Enabled = false;
                    m_Player2TextChanged = false;
                    player2TextBox.ForeColor = Color.Gray;
                    player2TextBox.Text = "[Computer]";
               }
          }

          private void DoneButton_Click(object sender, EventArgs e)
          {
               r_SoundEffects.PlayClickSound();

               if (!NameAuthenticator.ValidiateNames(m_Player1Name, m_Player2Name, m_Player2TextChanged, out string msg))
               {
                    MessageBox.Show(msg);                    
               }
               else
               {
                    m_FormClosedByXButton = false;
                    Close();
               }
          }

          private void Button6x6_CheckedChanged(object sender, EventArgs e)
          {
               r_SoundEffects.PlayClickSound();
               m_BoardSize = 6;
          }

          private void Button8x8_CheckedChanged(object sender, EventArgs e)
          {
               r_SoundEffects.PlayClickSound();
               m_BoardSize = 8;
          }

          private void Button10x10_CheckedChanged(object sender, EventArgs e)
          {
               r_SoundEffects.PlayClickSound();
               m_BoardSize = 10;
          }

          private void DoneButton_MouseLeave(object sender, EventArgs e)
          {
               DoneButton.BackColor = Color.White;
          }

          private void player1TextBox_TextChanged(object sender, EventArgs e)
          {   
               m_Player1Name = player1TextBox.Text;
          }

          private void player2TextBox_TextChanged(object sender, EventArgs e)
          {              
               m_Player2Name = player2TextBox.Text == "[Computer]" ? "Computer" : player2TextBox.Text;
          }

          private void player2TextBox_Click(object sender, EventArgs e)
          {
               if (m_Player2TextChanged)
               {
                    r_SoundEffects.PlayClickSound();
               }
          }

          private void player1TextBox_Click(object sender, EventArgs e)
          {
               r_SoundEffects.PlayClickSound();
               player1TextBox.Text = string.Empty;
               player1TextBox.ForeColor = Color.Black;
          }

          private void DoneButton_MouseEnter(object sender, EventArgs e)
          {
               DoneButton.BackColor = Color.AntiqueWhite;
          }
     }
}
