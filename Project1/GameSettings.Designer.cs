using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Project1
{
     partial class GameSettings
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private IContainer components = null;

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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettings));
               this.BoardSizeLabel = new System.Windows.Forms.Label();
               this.Button6x6 = new System.Windows.Forms.RadioButton();
               this.Button8x8 = new System.Windows.Forms.RadioButton();
               this.Button10x10 = new System.Windows.Forms.RadioButton();
               this.playerLabel = new System.Windows.Forms.Label();
               this.player1Label = new System.Windows.Forms.Label();
               this.player1TextBox = new System.Windows.Forms.TextBox();
               this.player2CheckBox = new System.Windows.Forms.CheckBox();
               this.player2TextBox = new System.Windows.Forms.TextBox();
               this.DoneButton = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // BoardSizeLabel
               // 
               this.BoardSizeLabel.AutoSize = true;
               this.BoardSizeLabel.BackColor = System.Drawing.Color.Transparent;
               this.BoardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.BoardSizeLabel.ForeColor = System.Drawing.Color.GhostWhite;
               this.BoardSizeLabel.Location = new System.Drawing.Point(12, 9);
               this.BoardSizeLabel.Name = "BoardSizeLabel";
               this.BoardSizeLabel.Size = new System.Drawing.Size(72, 13);
               this.BoardSizeLabel.TabIndex = 0;
               this.BoardSizeLabel.Text = "Board Size:";
               // 
               // Button6x6
               // 
               this.Button6x6.AutoSize = true;
               this.Button6x6.BackColor = System.Drawing.Color.Transparent;
               this.Button6x6.Checked = true;
               this.Button6x6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.Button6x6.ForeColor = System.Drawing.Color.GhostWhite;
               this.Button6x6.Location = new System.Drawing.Point(31, 25);
               this.Button6x6.Name = "Button6x6";
               this.Button6x6.Size = new System.Drawing.Size(45, 17);
               this.Button6x6.TabIndex = 1;
               this.Button6x6.TabStop = true;
               this.Button6x6.Text = "6x6";
               this.Button6x6.UseVisualStyleBackColor = false;
               this.Button6x6.CheckedChanged += new System.EventHandler(this.Button6x6_CheckedChanged);
               // 
               // Button8x8
               // 
               this.Button8x8.AutoSize = true;
               this.Button8x8.BackColor = System.Drawing.Color.Transparent;
               this.Button8x8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.Button8x8.ForeColor = System.Drawing.Color.GhostWhite;
               this.Button8x8.Location = new System.Drawing.Point(92, 25);
               this.Button8x8.Name = "Button8x8";
               this.Button8x8.RightToLeft = System.Windows.Forms.RightToLeft.No;
               this.Button8x8.Size = new System.Drawing.Size(45, 17);
               this.Button8x8.TabIndex = 2;
               this.Button8x8.Text = "8x8";
               this.Button8x8.UseVisualStyleBackColor = false;
               this.Button8x8.CheckedChanged += new System.EventHandler(this.Button8x8_CheckedChanged);
               // 
               // Button10x10
               // 
               this.Button10x10.AutoSize = true;
               this.Button10x10.BackColor = System.Drawing.Color.Transparent;
               this.Button10x10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.Button10x10.ForeColor = System.Drawing.Color.GhostWhite;
               this.Button10x10.Location = new System.Drawing.Point(161, 25);
               this.Button10x10.Name = "Button10x10";
               this.Button10x10.Size = new System.Drawing.Size(59, 17);
               this.Button10x10.TabIndex = 3;
               this.Button10x10.Text = "10x10";
               this.Button10x10.UseVisualStyleBackColor = false;
               this.Button10x10.CheckedChanged += new System.EventHandler(this.Button10x10_CheckedChanged);
               // 
               // playerLabel
               // 
               this.playerLabel.AutoSize = true;
               this.playerLabel.BackColor = System.Drawing.Color.Transparent;
               this.playerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.playerLabel.ForeColor = System.Drawing.Color.GhostWhite;
               this.playerLabel.Location = new System.Drawing.Point(12, 45);
               this.playerLabel.Name = "playerLabel";
               this.playerLabel.Size = new System.Drawing.Size(52, 13);
               this.playerLabel.TabIndex = 4;
               this.playerLabel.Text = "Players:";
               // 
               // player1Label
               // 
               this.player1Label.AutoSize = true;
               this.player1Label.BackColor = System.Drawing.Color.Transparent;
               this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.player1Label.ForeColor = System.Drawing.Color.GhostWhite;
               this.player1Label.Location = new System.Drawing.Point(22, 70);
               this.player1Label.Name = "player1Label";
               this.player1Label.Size = new System.Drawing.Size(53, 13);
               this.player1Label.TabIndex = 5;
               this.player1Label.Text = "Player1:";
               // 
               // player1TextBox
               // 
               this.player1TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
               this.player1TextBox.Location = new System.Drawing.Point(102, 67);
               this.player1TextBox.Name = "player1TextBox";
               this.player1TextBox.Size = new System.Drawing.Size(100, 20);
               this.player1TextBox.TabIndex = 6;
               this.player1TextBox.Text = "Maximum 8 letters.";
               this.player1TextBox.Click += new System.EventHandler(this.player1TextBox_Click);
               this.player1TextBox.TextChanged += new System.EventHandler(this.player1TextBox_TextChanged);
               // 
               // player2CheckBox
               // 
               this.player2CheckBox.AutoSize = true;
               this.player2CheckBox.BackColor = System.Drawing.Color.Transparent;
               this.player2CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.player2CheckBox.ForeColor = System.Drawing.Color.GhostWhite;
               this.player2CheckBox.Location = new System.Drawing.Point(25, 95);
               this.player2CheckBox.Name = "player2CheckBox";
               this.player2CheckBox.Size = new System.Drawing.Size(72, 17);
               this.player2CheckBox.TabIndex = 7;
               this.player2CheckBox.Text = "Player2:";
               this.player2CheckBox.UseVisualStyleBackColor = false;
               this.player2CheckBox.CheckedChanged += new System.EventHandler(this.player2CheckBox_CheckedChanged);
               // 
               // player2TextBox
               // 
               this.player2TextBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
               this.player2TextBox.Enabled = false;
               this.player2TextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
               this.player2TextBox.Location = new System.Drawing.Point(102, 92);
               this.player2TextBox.Name = "player2TextBox";
               this.player2TextBox.Size = new System.Drawing.Size(100, 20);
               this.player2TextBox.TabIndex = 8;
               this.player2TextBox.Text = "[Computer]";
               this.player2TextBox.Click += new System.EventHandler(this.player2TextBox_Click);
               this.player2TextBox.TextChanged += new System.EventHandler(this.player2TextBox_TextChanged);
               // 
               // DoneButton
               // 
               this.DoneButton.BackColor = System.Drawing.Color.White;
               this.DoneButton.Location = new System.Drawing.Point(140, 137);
               this.DoneButton.Name = "DoneButton";
               this.DoneButton.Size = new System.Drawing.Size(75, 23);
               this.DoneButton.TabIndex = 9;
               this.DoneButton.Text = "Done";
               this.DoneButton.UseVisualStyleBackColor = false;
               this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
               this.DoneButton.MouseEnter += new System.EventHandler(this.DoneButton_MouseEnter);
               this.DoneButton.MouseLeave += new System.EventHandler(this.DoneButton_MouseLeave);
               // 
               // GameSettings
               // 
               this.AcceptButton = this.DoneButton;
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
               this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
               this.ClientSize = new System.Drawing.Size(227, 172);
               this.Controls.Add(this.DoneButton);
               this.Controls.Add(this.player2TextBox);
               this.Controls.Add(this.player2CheckBox);
               this.Controls.Add(this.player1TextBox);
               this.Controls.Add(this.player1Label);
               this.Controls.Add(this.playerLabel);
               this.Controls.Add(this.Button10x10);
               this.Controls.Add(this.Button8x8);
               this.Controls.Add(this.Button6x6);
               this.Controls.Add(this.BoardSizeLabel);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
               this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "GameSettings";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "GameSettings";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private Label BoardSizeLabel;
          private RadioButton Button6x6;
          private RadioButton Button8x8;
          private RadioButton Button10x10;
          private Label playerLabel;
          private Label player1Label;
          private TextBox player1TextBox;
          private CheckBox player2CheckBox;
          private TextBox player2TextBox;
          private Button DoneButton;
     }
}