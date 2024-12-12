using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    private AudioSource startAudio, loopAudio;
    [SerializeField]    
    private AudioClip start, loop;

    // Start is called before the first frame update
    void Start()
    {
        startAudio.clip = start;
        startAudio.Play();
        Invoke("switchToLoop", start.length-1f );
    }

    private void switchToLoop()
    {
        loopAudio.clip = loop;
        loopAudio.Play();
    }
}
