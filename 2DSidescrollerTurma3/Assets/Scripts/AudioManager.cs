using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public Slider SFXSlider;
    public Slider MusicSlider;

    void Start () {
		//PlayerPrefs.DeleteAll ();

		if (PlayerPrefs.HasKey ("sfx")) {
			SFXSlider.value = PlayerPrefs.GetFloat ("sfx");
		} else {
			SFXSlider.value = SFXSlider.maxValue;
		}
		if (PlayerPrefs.HasKey ("music")) {
			MusicSlider.value = PlayerPrefs.GetFloat ("music");
		} else {
			MusicSlider.value = MusicSlider.maxValue;
		}
			

        SFXSlider.onValueChanged.AddListener(delegate { SFXVolumeChange(); });
        MusicSlider.onValueChanged.AddListener(delegate { MusicVolumeChange(); });
    }

    public void SFXVolumeChange() {
		PlayerPrefs.SetFloat ("sfx", SFXSlider.value);
        SoundManager.SetVolumeSFX(SFXSlider.value);
    }

    public void MusicVolumeChange() {
		PlayerPrefs.SetFloat ("music", MusicSlider.value);
        SoundManager.SetVolumeMusic(MusicSlider.value);
    }

    public void PlayMusic(string connection) {
        SoundManager.PlayConnection(connection);
    }
}
