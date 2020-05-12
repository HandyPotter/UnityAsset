using System.Collections;
using System.Collections.Generic;
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


    Queue<string> rQueue = new Queue<string>();
    Queue<string> lQueue = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {   
        //controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        // insert data in queue;

        //사랑합니다.
        rQuery = "H11+P13+D4+M14";
        lQuery = "H1+P13+D5+M0";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);

        //안녕하세요
        rQuery = "H11+D4+P14+M1";
        lQuery = "H11+D2+P14+M0";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);
        rQuery = "H1+D10+P13+M16";
        lQuery = "H1+D10+P13+M16";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);

        //만나다
        rQuery = "H3+D1+P13+M6";
        lQuery = "H3+D1+P13+M6";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);

        //반갑습니다.
        rQuery = "H12+D5+P12+M7";
        lQuery = "H12+D5+P12+M7";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);

        //오늘
        rQuery = "H11+D10+P13+M16";
        lQuery = "H11+D10+P13+M16";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);

        //날씨
        rQuery = "H4+D1+P13+M0";
        lQuery = "H4+D1+P13+M0";  
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);

        //어떄요.
        rQuery = "H3+D1+P13+M7";
        lQuery = "H0+D0+P0+M0";


        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);
        //다음주
        rQuery = "H9+P7+D5+M0";
        lQuery = "H0+D0+P0+M0";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);
        rQuery = "H9+P7+D1+M0";
        lQuery = "H0+D0+P0+M0";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);

        //등교    
        rQuery = "H11+P13+D11+M0";
        lQuery = "H11+P13+D11+M0";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);
        rQuery = "H11+P13+D5+M1";
        lQuery = "H0+P0+D0+M0";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);
        //수업
        rQuery = "H11+P13+D11+M0";
        lQuery = "H11+P13+D11+M0";
        rQueue.Enqueue(rQuery);
        lQueue.Enqueue(lQuery);



        rQuery = rQueue.Dequeue();
         lQuery = lQueue.Dequeue();

    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space")) {
            if(rQueue.Count > 0){
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
            else
            {
                anim.SetInteger("condition", 0);
            }
        }
        if(Input.GetKeyUp("space")){
            anim.SetInteger("condition",0); 
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
/*                if (RP == 0)
                {
                    anim.SetFloat("RPX", 0.0f);
                    anim.SetFloat("RPY", -1.5f);

                }
                else
                {
                    anim.SetFloat("RPX", RPX[RP - 1]);
                    anim.SetFloat("RPY", RPY[RP - 1]);
                }*/
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
   


}
