namespace Project1
{
     partial class DamkaWindow
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DamkaWindow));
               this.player1ScoreLabel = new System.Windows.Forms.Label();
               this.player2ScoreLabel = new System.Windows.Forms.Label();
               this.label1 = new System.Windows.Forms.Label();
               this.playerTurnLabel = new System.Windows.Forms.Label();
               this.forfeitButton = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // player1ScoreLabel
               // 
               this.player1ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.player1ScoreLabel.AutoSize = true;
               this.player1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
               this.player1ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.player1ScoreLabel.ForeColor = System.Drawing.Color.GhostWhite;
               this.player1ScoreLabel.Location = new System.Drawing.Point(60, 26);
               this.player1ScoreLabel.Name = "player1ScoreLabel";
               this.player1ScoreLabel.Size = new System.Drawing.Size(64, 13);
               this.player1ScoreLabel.TabIndex = 6;
               this.player1ScoreLabel.Text = "Player1: 0";
               // 
               // player2ScoreLabel
               // 
               this.player2ScoreLabel.AutoSize = true;
               this.player2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
               this.player2ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.player2ScoreLabel.ForeColor = System.Drawing.Color.GhostWhite;
               this.player2ScoreLabel.Location = new System.Drawing.Point(200, 26);
               this.player2ScoreLabel.Name = "player2ScoreLabel";
               this.player2ScoreLabel.Size = new System.Drawing.Size(64, 13);
               this.player2ScoreLabel.TabIndex = 7;
               this.player2ScoreLabel.Text = "Player2: 0";
               // 
               // label1
               // 
               this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.label1.AutoSize = true;
               this.label1.BackColor = System.Drawing.Color.Transparent;
               this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.label1.ForeColor = System.Drawing.Color.GhostWhite;
               this.label1.Location = new System.Drawing.Point(12, 339);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(0, 13);
               this.label1.TabIndex = 8;
               this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // playerTurnLabel
               // 
               this.playerTurnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.playerTurnLabel.AutoSize = true;
               this.playerTurnLabel.BackColor = System.Drawing.Color.Transparent;
               this.playerTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.playerTurnLabel.ForeColor = System.Drawing.Color.GhostWhite;
               this.playerTurnLabel.Location = new System.Drawing.Point(102, 323);
               this.playerTurnLabel.Name = "playerTurnLabel";
               this.playerTurnLabel.Size = new System.Drawing.Size(104, 13);
               this.playerTurnLabel.TabIndex = 9;
               this.playerTurnLabel.Text = "Player1\'s Turn(X)";
               // 
               // forfeitButton
               // 
               this.forfeitButton.Location = new System.Drawing.Point(115, 339);
               this.forfeitButton.Name = "forfeitButton";
               this.forfeitButton.Size = new System.Drawing.Size(75, 23);
               this.forfeitButton.TabIndex = 10;
               this.forfeitButton.Text = "Forefit";
               this.forfeitButton.UseVisualStyleBackColor = true;
               this.forfeitButton.Click += new System.EventHandler(this.forfeitButton_Click);
               // 
               // DamkaWindow
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
               this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
               this.ClientSize = new System.Drawing.Size(325, 373);
               this.Controls.Add(this.forfeitButton);
               this.Controls.Add(this.playerTurnLabel);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.player2ScoreLabel);
               this.Controls.Add(this.player1ScoreLabel);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
               this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
               this.MaximizeBox = false;
               this.Name = "DamkaWindow";
               this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Damka";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Label player1ScoreLabel;
          private System.Windows.Forms.Label player2ScoreLabel;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Label playerTurnLabel;
          private System.Windows.Forms.Button forfeitButton;
     }
}