using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OmiyaGames.Managers;
using OmiyaGames.Audio;

public class Toolbar : MonoBehaviour
{
	[SerializeField]
	SoundEffect sfx;

	[Header("Mutate")]
	[SerializeField]
	Toggle pitch;
	[SerializeField]
	Toggle volume;

	[Header("Time")]
	[SerializeField]
	Slider timeScaleSlider;
	[SerializeField]
	TextMeshProUGUI timeScaleLabel;
	[SerializeField]
	Toggle pauseToggle;

	IEnumerator Start()
	{
		// Setup the audio
		yield return AudioManager.Setup();

		SetupMutateToggls();

		SetupTimeControls();
	}

	void SetupMutateToggls()
	{
		sfx.IsMutatingPitch = pitch.isOn;
		sfx.IsMutatingVolume = volume.isOn;

		pitch.onValueChanged.AddListener((isOn) =>
		{
			sfx.IsMutatingPitch = isOn;
		});
		volume.onValueChanged.AddListener((isOn) =>
		{
			sfx.IsMutatingVolume = isOn;
		});
	}

	void SetupTimeControls()
	{
		// Setup the volume slider
		timeScaleSlider.value = TimeManager.TimeScale;
		UpdateLabels();
		timeScaleSlider.onValueChanged.AddListener((value) =>
		{
			TimeManager.TimeScale = value;
			UpdateLabels();
		});

		// Setup the mute toggle
		pauseToggle.isOn = TimeManager.IsManuallyPaused;
		pauseToggle.onValueChanged.AddListener((isOn) =>
		{
			TimeManager.IsManuallyPaused = isOn;
			UpdateLabels();
		});

		void UpdateLabels()
		{
			float timeScale = TimeManager.TimeScale;
			if (TimeManager.IsManuallyPaused)
			{
				timeScale = 0f;
			}
			timeScaleLabel.text = $"x{timeScale:0.0}";
		}
	}
}
