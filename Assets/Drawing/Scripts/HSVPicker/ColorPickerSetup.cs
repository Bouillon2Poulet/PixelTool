﻿using UnityEngine;
using TMPro;

namespace HSVPicker
{
    [System.Serializable]
    public class ColorPickerSetup
    {
        public enum ColorHeaderShowing
        {
            Hide,
            ShowColor,
            ShowColorCode,
            ShowAll,
        }

        [System.Serializable]
        public class UiElements
        {
            public RectTransform[] Elements;


            public void Toggle(bool active)
            {
                for (int cnt = 0; cnt < Elements.Length; cnt++)
                {
                    Elements[cnt].gameObject.SetActive(active);
                }
            }

        }

        // public bool isHeightColorPickerSetup = tru
        public bool ShowRgb = true;
        public bool ShowHsv;
        public bool ShowAlpha = true;
        public bool ShowColorBox = true;
        public bool ShowColorSliderToggle = true;

        [Tooltip("Re-initialise the colour picker settings every time the picker is made active.")]
        public bool RegenerateOnOpen = false;
        [Tooltip("Enable the user to add presets, up to the maximum preset limit.")]
        public bool UserCanAddPresets = true;

        public ColorHeaderShowing ShowHeader = ColorHeaderShowing.ShowAll;

        public UiElements RgbSliders;
        public UiElements HsvSliders;
        public UiElements ColorToggleElement;
        public UiElements AlphaSlidiers;


        public UiElements ColorHeader;
        public UiElements ColorCode;
        public UiElements ColorPreview;

        public UiElements ColorBox;
        public TMP_Text SliderToggleButtonText;

        public string PresetColorsId = "default";
        public Color[] DefaultPresetColors;
    }
}
