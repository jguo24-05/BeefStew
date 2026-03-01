using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;

public class DoorScript : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeOut()
    {
        while (sr.color.a > 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
