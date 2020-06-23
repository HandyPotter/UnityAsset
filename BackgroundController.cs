using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    public Color happy = new Color(0.92F, 0.89F, 0.13F,1.0F );
    public Color fear = new Color(0.61F, 0.79F, 0.23F, 1.0F);
    public Color suprised = new Color(0.36F, 0.73F, 0.51F, 1.0F);
    public Color angry = new Color(0.84F, 0.0473F, 0.49F, 1.0F);
    public Color sad = new Color(0.24F, 0.717F, 0.906F, 1.0F);
    public Color nomal = new Color(0.9098F, 0.9098F, 0.9098F, 1F);
    public Color boredom = new Color(.63F, 0.38F, 0.64F, 1F);
    public Color hurt = new Color(0.83F, 0.047F, 0.5F, 1F);
    public Color disgust =new Color(0.57F, 0.24F, 0.57F, 1F);
    public Color interested = new Color(1.0F, 0.6F, 0.0F, 1F);
    public Color remainder = new Color(1.0F, 1.0F, 1.0F, 1F);
    public Color color1 = new Color(0.9098F, 0.9098F, 0.9098F, 1F);
    public Color color2 = new Color(0.9098F, 0.9098F, 0.9098F, 1F);
    public float duration = 100.0F;
    private float t = 0f; // lerp control variable


    public GameObject obj1;
    public TextMeshPro text;

    public Animator anim;

    public GameObject emotions;
    private int count = 0;
    private int ts = 1;

    // Start is called before the first frame update
    Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;

        anim = emotions.GetComponent<Animator>();
        setEmotionToBackground("9");


    }

    // Update is called once per frame
    void Update()
    {

        camera.backgroundColor = Color.Lerp(color1, color2, t);
        if (t < 1)
        {
            t += Time.deltaTime / duration;
        }
    }

    void setEmotionToBackground(string emotion)
    {
        int emotionNum = int.Parse(emotion) -1;
        obj1.SetActive(false);
        obj1 = emotions.transform.GetChild(emotionNum).gameObject;
        obj1.SetActive(true);
        anim.Play("move", -1, 0.0f);
        if (emotion.Equals("1"))
        {
            color1 = color2;
            color2 = happy;
            text.SetText("기쁨");
        }
        else if (emotion.Equals("2"))
        {
            color1 = color2;
            color2 = fear;
            text.SetText("무서움");
        }
        else if (emotion.Equals("3"))
        {
            color1 = color2;
            color2 = suprised;
            text.SetText("놀람");
        }
        else if (emotion.Equals("4"))
        {
            color1 = color2;
            color2 = angry;
            text.SetText("화남");
        }
        else if (emotion.Equals("5"))
        {
            color1 = color2;
            color2 = sad;
            text.SetText("슬픔");
        }
        else if (emotion.Equals("6"))
        {
            color1 = color2;
            color2 = nomal;
            text.SetText("보통");
        }
        else if (emotion.Equals("7"))
        {
            color1 = color2;
            color2 = boredom;
            text.SetText("지루함");
        }
        else if (emotion.Equals("8"))
        {
            color1 = color2;
            color2 = hurt;
            text.SetText("아픔");
        }
        else if (emotion.Equals("9"))
        {
            color1 = color2;
            color2 = disgust;
            text.SetText("역겨움");
        }
        else if (emotion.Equals("10"))
        {
            color1 = color2;
            color2 = interested;
            text.SetText("흥미");
        }
        else if (emotion.Equals("11"))
        {
            color1 = color2;
            color2 = remainder;
            text.SetText("기타");
        }
        t = 0;
    }
}

