using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace chapter_07.Engine.Sound
{
    public class SoundManager
    {
        private List<SoundEffectInstance> _soundtracks = new List<SoundEffectInstance>();
        private int _soundtrackIndex = -1;

        public void AddSoundtrack(List<SoundEffectInstance> tracks)
        {
            _soundtracks = tracks;
            _soundtrackIndex = _soundtracks.Count - 1;
        }

        public void PlaySoundtrack()
        {
            var nbTracks = _soundtracks.Count;

            if (nbTracks > 0)
            {
                var currentTrack = _soundtracks[_soundtrackIndex];
                var nextTrack = _soundtracks[(_soundtrackIndex + 1) % nbTracks];

                if (currentTrack.State == SoundState.Stopped)
                {
                    nextTrack.Play();
                    _soundtrackIndex++;

                    if (_soundtrackIndex >= _soundtracks.Count)
                    {
                        _soundtrackIndex = 0;
                    }
                }
            }
        }
    }
}
