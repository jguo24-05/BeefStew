using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampScript : MonoBehaviour
{
    public Sprite lampOn;
    public Sprite lampOff;
    private Sprite current;
    public bool on;
    private SpriteRenderer sr;
    public GameObject gameLight;
    [SerializeField] public float lowerIntensity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = lampOn;
        on = true;
        sr = GetComponent<SpriteRenderer>();
        gameLight = GameObject.Find("Global Light 2D");
        lowerIntensity = 0.20f;
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = current;
    }

    public void SwitchSprite()
    {
        if (current == lampOn)
        {
            current = lampOff;
            on = false;
            gameLight.GetComponent<Light2D>().intensity = lowerIntensity;
        } 
        else
        {
            current = lampOn;
            on = true;
            gameLight.GetComponent<Light2D>().intensity = 1;
        }
    }
}
