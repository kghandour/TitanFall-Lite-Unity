using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ChosenTitan : MonoBehaviour
{
    public static int selectedTitan=0;
    public Canvas pauseCanvas;
    public Canvas endgameCanvas;
    public Canvas gameoverCanvas;

    public GameObject pilot;
    public GameObject gamePlaySoundSource;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pilot.GetComponent<health_and_call_titan_script>().health > 0 && (endgameCanvas==null || !endgameCanvas.isActiveAndEnabled ) && (gameoverCanvas == null || !gameoverCanvas.isActiveAndEnabled))
        {

            gamePlaySoundSource.GetComponent<AudioSource>().Stop();
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ChooseTitan(int n)
    {
        selectedTitan = n;
    }
}
