using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class backgroundMusicPicker : MonoBehaviour {
	public static backgroundMusicPicker instance;
	public AudioMixerGroup mixerGroup;
	public string current_song = String.Empty;
	public Sound[] sounds;
	
	// Use this for initialization
	void Awake () {
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = true;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}
	
	// Update is called once per frame
	void Start () {
		if(sounds.Length > 0 && current_song == String.Empty){
			Play(sounds[0]);
			current_song = sounds[0].name;
		} else if(current_song != String.Empty){
			change_music(current_song);
		}
	}

	public void change_music(string sound){
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		current_song = sound;
		Play(s);
	}
	void Play(Sound s)
	{
		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}
}
