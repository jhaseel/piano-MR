using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class playgame : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject[] vbBtnObj;
    public Animator[] keys;

    public AudioSource soundTarget;
    public AudioClip clipTarget;
    private AudioSource[] allAudioSources;

    private int id = -1;
    private int numkeys = 9;

    private string[] note = new string[] { "do1", "re1", "mi1", "fa1", "sol1", "la1", "si1", "do2", "re2" };

    private string[] buttons = new string[] {"" +
        "button_do1",
        "button_re1",
        "button_mi1",
        "button_fa1",
        "button_sol1",
        "button_la1",
        "button_si1",
        "button_do2",
        "button_re2"
    };

    private string[] sounds = new string[] {"" +
        "sounds/do1",
        "sounds/re1",
        "sounds/mi1",
        "sounds/fa1",
        "sounds/sol1",
        "sounds/la1",
        "sounds/si1",
        "sounds/do2",
        "sounds/re2"
    };

    // Start is called before the first frame update
    void Start()
    {
              
        vbBtnObj = new GameObject[numkeys];
        for (int x = 0; x < numkeys; x++)
        {
            vbBtnObj[x] = new GameObject();
            vbBtnObj[x] = GameObject.Find(buttons[x]);
            vbBtnObj[x].GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
            keys[x].GetComponent<Animator>();
            Debug.Log("id => " + x + "  -----> " + keys[x]);
        }
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log(vb.VirtualButtonName);
        id = -1;
        if (vb.VirtualButtonName == buttons[0]){
            id = 0;
        }else if (vb.VirtualButtonName == buttons[1])
        {
            id = 1;
        }
        else if (vb.VirtualButtonName == buttons[2])
        {
            id = 2;
        }
        else if (vb.VirtualButtonName == buttons[3])
        {
            id = 3;
        }
        else if (vb.VirtualButtonName == buttons[4])
        {
            id = 4;
        }
        else if (vb.VirtualButtonName == buttons[5])
        {
            id = 5;
        }
        else if (vb.VirtualButtonName == buttons[6])
        {
            id = 6;
        }
        else if (vb.VirtualButtonName == buttons[7])
        {
            id = 7;
        }
        else if (vb.VirtualButtonName == buttons[8])
        {
            id = 8;
        }
        Debug.Log("id es => " + id);
        if (id != -1)
        {
            keys[id].Play(note[id]);
            playSound(sounds[id]);
        }

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (id != -1)
        {
            keys[id].Play("none");
            Debug.Log("Button released");
        }

    }

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    void playSound(string ss)
    {
        clipTarget = (AudioClip)Resources.Load(ss);
        soundTarget.clip = clipTarget;
        soundTarget.loop = false;
        soundTarget.playOnAwake = false;
        soundTarget.Play();
    }
}
