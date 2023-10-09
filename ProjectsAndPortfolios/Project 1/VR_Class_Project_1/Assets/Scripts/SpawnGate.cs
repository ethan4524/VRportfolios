using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpawnGate : MonoBehaviour
{
    public Vector3 closed;
    public Vector3 opened;
    public float duration = 2.0f;
    bool open;
    float increment;
    public AudioSource source;

    private void Start()
    {
        this.transform.position = closed;
        float startTime = Time.time;
        float distance = Mathf.Abs(transform.position.y - opened.y);
        increment = distance / 60f;
        CloseGate();
    }

    public void Reset()
    {
        CloseGate();
    }

    public void OpenGate()
    {
        open = true;
        source.Play();
    }
    public void CloseGate()
    {
        open = false;
        source.Play();
    }
    private void FixedUpdate()
    {
        if (open)
        {
            if (transform.position.y < opened.y)
            {
                transform.position += new Vector3(0, increment, 0);
            } 
        } else
        {
            transform.position = closed;
        }
        
            
    }
}
