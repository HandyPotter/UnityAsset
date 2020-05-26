using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    int RP = 0;
    float[] RPX = new float[15] { 0.0f, 0.0f, 0.0f,-0.3f, 0.1f,-0.3f, 0.1f, 0.2f,-0.4f,-0.7f,-0.6f, -0.2f, 0.0f, 0.0f, 0.6f};
    float[] RPY = new float[15] { 0.9f, 1.0f, 0.8f, 1.0f, 0.8f, 1.0f, 0.7f, 0.4f, 0.3f,-0.6f, 1.0f, 0.0f, 0.2f, -0.4f, -1.1f };
    float RD = 0;
    float RH = 0;
    float RM = 0;


    int LP = 0;
    float[] LPX = new float[15] { 0.0f, 0.0f, 0.0f,-0.3f,-0.3f, 0.3f,-0.3f,-0.4f, 0.1f, 0.2f, 0.2f, 0.3f, 0.0f, 0.0f,-1.0f };
    float[] LPY = new float[15] { 0.9f, 1.0f, 0.8f, 1.0f, 0.9f, 0.8f, 0.8f, 0.5f, 0.2f,-0.1f, 0.6f, 0.0f, 0.0f,-0.4f,-1.0f };
    float LD = 0;
    float LH = 0;
    float LM = 0;
    int condition = 0;
    int idle = 1;

    string rQuery;
    string lQuery;
    char sp = '+';
    float exitTime = 0.9f;
    int checkedPoint = 0;


    Queue<string> rQueue = new Queue<string>();
    Queue<string> lQueue = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {   
        //controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        // insert data in queue;
        
    } 

    // Update is called once per frame
    void Update()
    {
        if (rQueue.Count > 0) {
            if(checkedPoint == 0)
            {
                rQuery = rQueue.Dequeue();
                lQuery = lQueue.Dequeue();
                checkedPoint = 1;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > exitTime)
            {
                rQuery = rQueue.Dequeue();
                lQuery = lQueue.Dequeue();
                anim.Play("Main",-1,0.2f);
            }
            anim.SetInteger("condition", 1);
        
            rightAnimation(rQuery);
            lelfAnimation(lQuery);
        }
        else{
            anim.SetInteger("condition",0);
            checkedPoint = 0;
        }
    }
    void rightAnimation(string query)
    {
        string[] spRQuary = query.Split(sp);
        for (int i = 0; i < spRQuary.Length; i++)
        {
            if (spRQuary[i][0] == 'H')
            {
                string tmp = spRQuary[i];
                RH = float.Parse(tmp.Substring(1));
                anim.SetFloat("RH", RH);
            }
            if (spRQuary[i][0] == 'P')
            {
                string tmp = spRQuary[i];
                RP = int.Parse(tmp.Substring(1));
                anim.SetFloat("RPX", RPX[RP - 1]);
                anim.SetFloat("RPY", RPY[RP - 1]);
            }
            if (spRQuary[i][0] == 'D')
            {
                string tmp = spRQuary[i];
                RD = float.Parse(tmp.Substring(1));
                anim.SetFloat("RD", RD);
            }
            if (spRQuary[i][0] == 'M')
            {
                string tmp = spRQuary[i];
                RM = float.Parse(tmp.Substring(1));
                anim.SetFloat("RM", RM);
            }
        }
    }
    void lelfAnimation(string query)
    {
        string[] spRQuary = query.Split(sp);
        for (int i = 0; i < spRQuary.Length; i++)
        {
            if (spRQuary[i][0] == 'H')
            {
                string tmp = spRQuary[i];
                LH = float.Parse(tmp.Substring(1));
                anim.SetFloat("LH", LH);
            }
            if (spRQuary[i][0] == 'P')
            {
                string tmp = spRQuary[i];
                LP = int.Parse(tmp.Substring(1));
                if(LP == 0)
                {
                    anim.SetFloat("LPX",  0.0f);
                    anim.SetFloat("LPY", -1.5f);

                }
                else
                {
                    anim.SetFloat("LPX", LPX[LP - 1]);
                    anim.SetFloat("LPY", LPY[LP - 1]);
                }
            }
            if (spRQuary[i][0] == 'D')
            {
                string tmp = spRQuary[i];
                LD = float.Parse(tmp.Substring(1));
                anim.SetFloat("LD", LD);
            }
            if (spRQuary[i][0] == 'M')
            {
                string tmp = spRQuary[i];
                LM = float.Parse(tmp.Substring(1));
                anim.SetFloat("LM", LM);
            }
        }
    }
    void inputQuery(string Querys)
    {
        string[] tmp = Querys.Split('@');
        rQueue.Enqueue(tmp[0]);
        lQueue.Enqueue(tmp[1]);
    }
}
