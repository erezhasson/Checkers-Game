namespace Project1
{
     using System.Drawing;
     using System.Windows.Forms;

     public delegate void ContentChangedEventHandler(object sender, CheckerEventArgs e);

     public class DraughtsChecker : Button
     {
          private readonly Pawn r_PawnContent;
          private readonly byte r_ColPosition, r_RowPosition;
          public event ContentChangedEventHandler ContentChanged;

          public DraughtsChecker(byte i_CheckerType, byte i_ROWPos, byte i_COLPos, bool i_ActiveChecker)
          {
               r_ColPosition = i_COLPos;
               r_RowPosition = i_ROWPos;
               r_PawnContent = new Pawn(i_CheckerType);
               setButtonAttributes((Pawn.ePawnType)i_CheckerType, i_ActiveChecker);
          }

          public void ChangeContent(string i_NewContent)
          {
               PawnContent.ChangePawnType(i_NewContent);
               OnContentChange(new CheckerEventArgs(i_NewContent));
          }

          protected virtual void OnContentChange(CheckerEventArgs e)
          {
               if (ContentChanged != null)
               {
                    ContentChanged.Invoke(this, e);
               }
          }

          private void setButtonAttributes(Pawn.ePawnType i_CheckerType, bool i_DisabledChecker)
          {
               if (i_DisabledChecker)
               {
                    FlatAppearance.BorderColor = Color.Black;
                    FlatAppearance.BorderSize = 0;
                    UseVisualStyleBackColor = false;
                    BackColor = Color.Gray;
               }

               else
               {
                    UseVisualStyleBackColor = true;
                    BackColor = Color.White;
               }

               Enabled = !i_DisabledChecker;
          }

          public byte ColPosition
          {
               get
               {
                    return r_ColPosition;
               }
          }

          public byte RowPosition
          {
               get
               {
                    return r_RowPosition;
               }
          }

          public Pawn PawnContent
          {
               get
               {
                    return r_PawnContent;
               }
          }
     }
}
