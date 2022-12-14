using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _5ComputerShaders
{
    public class FrameRateCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI display;

        public enum DisplayMode
        {
            FPS,
            MS
        }

        [SerializeField] private DisplayMode _displayMode = DisplayMode.FPS;

        [SerializeField, Range(0.1f, 2f)] private float sampleDuration = 1f;
        private int frames;
        private float duration, bestDuration = float.MaxValue, worstDuration;

        private void Update()
        {
            float frameDuration = Time.unscaledDeltaTime;
            frames += 1;
            duration += frameDuration;
            // display.SetText("FPS\n{0:0}\n000\n000", frames / duration);

            if (frameDuration < bestDuration)
            {
                bestDuration = frameDuration;
            }

            if (frameDuration > worstDuration)
            {
                worstDuration = frameDuration;
            }

            if (duration >= sampleDuration)
            {
                if (_displayMode == DisplayMode.FPS)
                {
                    display.SetText(
                        "FPS\n{0:0}\n{1:0}\n{2:0}",
                        1f / bestDuration,
                        frames / duration,
                        1f / worstDuration
                    );
                }
                else
                {
                    display.SetText(
                        "MS\n{0:1}\n{1:1}\n{2:1}",
                        1000f * bestDuration,
                        1000f * duration / frames,
                        1000f * worstDuration
                    );
                }

                frames = 0;
                duration = 0;
                bestDuration = float.MaxValue;
                worstDuration = 0f;
            }
        }
    }
}