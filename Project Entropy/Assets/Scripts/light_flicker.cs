using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class light_flicker : MonoBehaviour
{
    public Light2D campfire;
    public Color fire1;
    float duration = 1.0f;
    public Color fire2;

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        campfire.color = Color.Lerp(fire1, fire2, t);
    }
}
