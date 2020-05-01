using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTool
{
    class Music
    {
        private MediaPlayer.MediaPlayer mediaPlayer = new MediaPlayer.MediaPlayer();

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="path">路径</param>
        public Music(string path)
        {
            mediaPlayer.FileName = path;
        }

        /// <summary>
        /// 播放
        /// </summary>
        public void Play()
        {
            mediaPlayer.Play();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            mediaPlayer.Pause();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            mediaPlayer.Stop();
        }

        /// <summary>
        /// Cancel
        /// </summary>
        public void Cancel()
        {
            mediaPlayer.Cancel();
        }

        /// <summary>
        /// 当前进度
        /// </summary>
        /// <returns></returns>
        public double CurrentPosition()
        {
            return mediaPlayer.CurrentPosition;
        }

        /// <summary>
        /// 快进
        /// </summary>
        public void FastForward()
        {
            mediaPlayer.FastForward();
        }

        /// <summary>
        /// 快退
        /// </summary>
        public void FastReverse()
        {
            mediaPlayer.FastReverse();
        }
    }
}
