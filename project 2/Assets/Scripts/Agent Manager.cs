using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AgentManager : MonoBehaviour
{

    public List<agent> agents;

    // Start is called before the first frame update

    public float CountTime = 5;

    public agent ItPlayer;
    public float spawnNum = 10f;
    public GameObject ag;
    public AgentManager agentManager;
    public GameObject one;
    public GameObject two;


    public List<obstacles> obstacles;
    void Start()
    {
        SpawnAgent();
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



