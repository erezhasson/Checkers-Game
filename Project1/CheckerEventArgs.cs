namespace Project1
{
     public class CheckerEventArgs
     {
          private readonly string r_NewContent;

          public CheckerEventArgs(string i_NewContent)
          {
               r_NewContent = i_NewContent;
          }

          public string NewContent
          {
               get
               {
                    return r_NewContent;
               }
          }
     }
}
