using UnityEngine;

public class LampScript : MonoBehaviour
{
    public Sprite lampOn;
    public Sprite lampOff;
    private Sprite current;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = lampOn;
        sr = GetComponent<SpriteRenderer>();
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
        } else
        {
            current = lampOn;
        }
    }
}
