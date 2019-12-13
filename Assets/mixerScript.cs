using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;




public class mixerScript : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider effectsSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("gameMusicSound", musicSlider.value);
        mixer.SetFloat("soundEffectsSound", effectsSlider.value);



    }
}
