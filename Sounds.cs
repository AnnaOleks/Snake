using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Snake
{
    public class Sounds
    {
        private WindowsMediaPlayer bgPlayer = new WindowsMediaPlayer();    // фоновая музыка
        private WindowsMediaPlayer fxPlayer = new WindowsMediaPlayer();    // эффекты
        private string pathToMedia;

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void Play()
        {
            bgPlayer.URL = pathToMedia + "stardust.mp3";
            bgPlayer.settings.volume = 30;
            bgPlayer.controls.play();
            bgPlayer.settings.setMode("loop", true);
        }

        public void Pause()
        {
            bgPlayer.controls.pause();
        }

        public void Resume()
        {
            bgPlayer.controls.play();
        }

        public void PlayEat()
        {
            fxPlayer.settings.setMode("loop", false); // никаких циклов
            fxPlayer.URL = pathToMedia + "click.mp3";
            fxPlayer.settings.volume = 100;
            fxPlayer.controls.play();
        }
        public void PlayGameOver()
        {
            fxPlayer.settings.setMode("loop", false);
            fxPlayer.URL = pathToMedia + "lost.mp3";
            fxPlayer.settings.volume = 100;
            fxPlayer.controls.play();
        }
    }
}
