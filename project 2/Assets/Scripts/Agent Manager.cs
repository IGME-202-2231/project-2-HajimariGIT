using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AgentManager : MonoBehaviour
{

    public List<agent> agents;

    // Start is called before the first frame update

    public float CountTime = 5;
    public int test;

    public agent ItPlayer;
    public float spawnNum = 10f;
    public GameObject ag;
    public AgentManager agentManager;
    public GameObject one;
    public GameObject two;
    public GameObject humanOne;
    public GameObject humanTwo;
    public GameObject humanThree;
    public GameObject humanFour;
    public GameObject humanFive;
    public GameObject humanSix;
    public GameObject humanSeven;
    public GameObject humanEight;
    public GameObject targetOne;
    public GameObject targetTwo;
    public GameObject targetThree;
    public GameObject targetFour;
    public GameObject hunter;


    public List<obstacles> obstacles;
    void Start()
    {
        SpawnAgent();
        SpawnHuman();
        SpawnSeeker();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SpawnAgent()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            GameObject NewAgent;
            Vector3 SpawnNew = new Vector3();
            SpawnNew.x = 0;
            SpawnNew.y = 0;
            SpawnNew.z = 0;
            NewAgent = Instantiate(ag, SpawnNew, Quaternion.identity);
            NewAgent.GetComponent<agent>().manager = this;
            agents.Add(NewAgent.GetComponent<agent>());






        }

    }

    public void SpawnHuman()
    {
        Vector3 spawnOne = new Vector3();
        spawnOne.x = 1.25f;
        spawnOne.y = -1.82f;
        Instantiate(humanOne, spawnOne, Quaternion.identity);   
        humanOne.GetComponent<agent>().manager = this;
        humanOne.GetComponent<fleer>().target = targetOne;

        Vector3 spawnTwo = new Vector3();
        spawnTwo.x = -8f;
        spawnTwo.y = -2.9f;
        Instantiate(humanTwo, spawnTwo, Quaternion.identity);
        humanTwo.GetComponent<agent>().manager = this;
        humanTwo.GetComponent<fleer>().target = targetOne;

        ///taregt 2

        Vector3 spawnThree = new Vector3();
        spawnThree.x = -8f;
        spawnThree.y = -2.9f;
        Instantiate(humanThree, spawnThree, Quaternion.identity);
        humanThree.GetComponent<agent>().manager = this;
        humanThree.GetComponent<fleer>().target = targetTwo;

        Vector3 spawnFour = new Vector3();
        spawnFour.x = 9.09f;
        spawnFour.y = 2.46f;
        Instantiate(humanFour, spawnFour, Quaternion.identity);
        humanFour.GetComponent<agent>().manager = this;
        humanFour.GetComponent<fleer>().target = targetTwo;

        //target 3

        Vector3 spawnFive = new Vector3();
        spawnFive.x = 5.11f;
        spawnFive.y = -1.92f;
        Instantiate(humanFive, spawnFive, Quaternion.identity);
        humanFive.GetComponent<agent>().manager = this;
        humanFive.GetComponent<fleer>().target = targetThree;

        Vector3 spawnSix = new Vector3();
        spawnSix.x = -7.22f;
        spawnSix.y = 3.82f;
        Instantiate(humanSix, spawnSix, Quaternion.identity);
        humanSix.GetComponent<agent>().manager = this;
        humanSix.GetComponent<fleer>().target = targetThree;

        //target four

        Vector3 spawnSeven = new Vector3();
        spawnSeven.x = -6.02f;
        spawnSeven.y = -0.94f;
        Instantiate(humanSeven, spawnSeven, Quaternion.identity);
        humanSeven.GetComponent<agent>().manager = this;
        humanSeven.GetComponent<fleer>().target = targetFour;

        Vector3 spawnEight = new Vector3();
        spawnEight.x = -8.04f;
        spawnEight.y = 1.72f;
        Instantiate(humanEight, spawnEight, Quaternion.identity);
        humanEight.GetComponent<agent>().manager = this;
        humanEight.GetComponent<fleer>().target = targetFour;





    }

    public void SpawnSeeker()
    {
        Vector3 spawnhunter = new Vector3();
        spawnhunter.x = 4.5f;
        spawnhunter.y = 3.97f;
        Instantiate(hunter, spawnhunter, Quaternion.identity);
        hunter.GetComponent<seeker>().target = targetOne;



    }





    public agent FlockClosestPlayer()
    {

        float min = Mathf.Infinity, dis;
        agent nearest = null;


        foreach (agent player in agents)
        {
            if (player != ItPlayer)
            {
                dis = Vector2.Distance(ItPlayer.transform.position, player.transform.position);

                if (dis < min)
                {
                    nearest = player;
                    min = dis;
                }
            }
        }
        return nearest;
    }

}



