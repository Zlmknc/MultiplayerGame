using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBg : MonoBehaviour
{
    public float backgroundspeed;
    public Renderer backgroundRenderer;

    private void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundspeed * Time.deltaTime, 0f);
    }
}
