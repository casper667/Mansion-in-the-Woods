using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public GameObject[] lights;
    public bool lightsOn;
    public Material bulbOnMaterial;
    public Material bulbOffMaterial;

    private float flickerTimer;
    private bool flickering = false;

    // Start is called before the first frame update
    void Start()
    {
        flickerTimer = Time.time + Random.Range(10f, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsOn && !flickering && Time.time > flickerTimer)
        {
            flickering = true;
            flickerTimer = Time.time + Random.Range(0.5f, 1f);
            foreach(GameObject lightObject in lights)
            {
                lightObject.GetComponent<MeshRenderer>().material = bulbOffMaterial;
                Light flicker = lightObject.GetComponent<Light>();
                flicker.intensity = 0f;
            }
        }
        else if(lightsOn && flickering && Time.time > flickerTimer)
        {
            flickering = false;
            flickerTimer = Time.time + Random.Range(10f, 60f);
            foreach (GameObject lightObject in lights)
            {
                lightObject.GetComponent<MeshRenderer>().material = bulbOnMaterial;
                Light flicker = lightObject.GetComponent<Light>();
                flicker.intensity = 0.5f;
            }
        }
    }

    public void FlipLightSwitch()
    {
        lightsOn = !lightsOn;
        flickering = false;
        if (lightsOn)
        {
            flickerTimer = Time.time + Random.Range(10f, 60f);
            foreach (GameObject lightObject in lights)
            {
                lightObject.GetComponent<MeshRenderer>().material = bulbOnMaterial;
                Light flicker = lightObject.GetComponent<Light>();
                flicker.intensity = 0.5f;
            }
        }
        else
        {
            foreach (GameObject lightObject in lights)
            {
                lightObject.GetComponent<MeshRenderer>().material = bulbOffMaterial;
                Light flicker = lightObject.GetComponent<Light>();
                flicker.intensity = 0f;
            }
        }
    }
}
