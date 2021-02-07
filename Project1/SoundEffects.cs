namespace Project1
{
     using System.IO;
     using System.Media;

     public class SoundEffects
     {
          private readonly SoundPlayer r_ClickSound = new SoundPlayer(filePath("ClickSound.wav"));
          private readonly SoundPlayer r_KingSound = new SoundPlayer(filePath("KingSound.wav"));
          private readonly SoundPlayer r_EatingSound = new SoundPlayer(filePath("EatingSound.wav"));
          private readonly SoundPlayer r_WinningSound = new SoundPlayer(filePath("WinSound.wav"));

          static private string filePath(string fileName)
          {
               string path = Path.Combine(System.Environment.CurrentDirectory.Replace(@"\DamkaGame\bin\Debug", ""), @"ImagesAndSounds\" + fileName);

               return path;
          }

          public void PlayKingSound()
          {
               r_KingSound.Play();
          }

          public void PlayEatingSound()
          {
               r_EatingSound.Play();
          }

          public void PlayClickSound()
          {
               r_ClickSound.Play();
          }

          public void PlayWinSound()
          {
               r_WinningSound.Play();
          }
     }
}
