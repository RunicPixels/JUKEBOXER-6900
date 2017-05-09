using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour {

    public AudioClip[] foreGroundAudio;
    public AudioClip[] midGroundAudio;
    public AudioClip[] backGroundAudio;

    public Button playButton;

    public bool canSpam = false;

    AudioSource myAudioSource;
    bool canPlay = true;

	// Use this for initialization
	void Start () {
        myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetCanPlay()
    {
        playButton.interactable = true;
        canPlay = true;
    }

    public void PlayRandom()
    {
        if (canPlay) // Als de audio gespeeld kan worden
        {
            int playedAudioFront = Random.Range(0, 6);
            int playedAudioMid = Random.Range(0, 6);
            int playedAudioBack = Random.Range(0, 6);

            // Speel ...GroundAudio[playedAudio...]
            myAudioSource.volume = 1f;
            myAudioSource.PlayOneShot(foreGroundAudio[playedAudioFront]);
            myAudioSource.volume = 0.7f;
            myAudioSource.PlayOneShot(midGroundAudio[playedAudioMid]);
            myAudioSource.volume = 0.5f;
            myAudioSource.PlayOneShot(backGroundAudio[playedAudioBack]);

            Invoke("SetCanPlay",10f);
            if (canSpam == false)
            {
                playButton.interactable = false;
                canPlay = false;
            }
        }
    }
}
