namespace Project1
{
     using System.Drawing;
     using System.IO;

     public class PawnImages
     {
          private readonly Image r_BlackPawn = Image.FromFile(filePath("BlackPawn.jpg"));
          private readonly Image r_BrownPawn = Image.FromFile(filePath("BrownPawn.jpg"));
          private readonly Image r_BlackKing = Image.FromFile(filePath("BlackKing.jpg"));
          private readonly Image r_BrownKing = Image.FromFile(filePath("BrownKing.jpg"));

          static private string filePath(string fileName)
          {
               string path = Path.Combine(System.Environment.CurrentDirectory.Replace(@"\DamkaGame\bin\Debug", ""), @"ImagesAndSounds\" + fileName);

               return path;
          }

          public Image BlackPawn
          {
               get
               {
                    return r_BlackPawn;
               }
          }

          public Image BrownPawn
          {
               get
               {
                    return r_BrownPawn;
               }
          }

          public Image BlackKing
          {
               get
               {
                    return r_BlackKing;
               }
          }

          public Image BrownKing
          {
               get
               {
                    return r_BrownKing;
               }
          }
     }
}
