using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampScriptV2 : MonoBehaviour
{
//     public Sprite lampOn;
//     public Sprite lampOff;
//     private Sprite current;
//     public bool on;
//     private SpriteRenderer sr;
//     public GameObject gameLight;
//     [SerializeField] public float lowerIntensity;
//     public transform player;
//     public float radius;

//     private Rigidbody rb;
//     private bool updateflag;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         current = lampOn;
//         on = true;
//         sr = GetComponent<SpriteRenderer>();
//         gameLight = GameObject.Find("Global Light 2D");
//         lowerIntensity = 0.20f;

//         rb = GetComponent<Rigidbody>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         sr.sprite = current;
//         Vector3 disp = transform.position - player.position;
//         if(updateflag && disp.x > -0.25f && disp.x <0.25 && disp.y > 0f && disp.y < 0.8f)
//         {
//             updateflag = false;
//             SwitchSpriteV2;
//         }
//     }

//     public void SwitchSpriteV2()
//     {
//         if (current == lampOn)
//         {
//             current = lampOff;
//             on = false;
//             gameLight.GetComponent<Light2D>().intensity = lowerIntensity;
//         } 
//         else
//         {
//             current = lampOn;
//             on = true;
//             gameLight.GetComponent<Light2D>().intensity = 1;
//         }
//     }
}
