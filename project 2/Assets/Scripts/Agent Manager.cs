using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class AgentManager : MonoBehaviour
{

    public List<agent> agents;
     public List<agent> humans;
    

    // Start is called before the first frame update

    public float CountTime = 5;
    public int test;
    public float seekRadius = .000000001f;
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
    public float distance;


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
        SwitchState();

    }

    public void SpawnAgent()
    {
        //spawns new agent at center 
        for (int i = 0; i < spawnNum; i++)
        {
            GameObject NewAgent;
            Vector3 SpawnNew = new Vector3();
            SpawnNew.x = 0;
            SpawnNew.y = 0;
            SpawnNew.z = 0;
            //creates 
            NewAgent = Instantiate(ag, SpawnNew, Quaternion.identity);
            //assins manger and adds to list
            NewAgent.GetComponent<agent>().manager = this;
            agents.Add(NewAgent.GetComponent<agent>());






        }

    }

    /// <summary>
    /// spawns each human 
    /// </summary>
    public void SpawnHuman()
    {
        
      
        Vector3 spawnOne = new Vector3();
        //spawn location
        spawnOne.x = 1.25f;
        spawnOne.y = -1.83f;
        //make
        GameObject one = Instantiate(humanOne, spawnOne, Quaternion.identity);   
        //assign needed things
        humanOne.GetComponent<agent>().manager = this;
        humanOne.GetComponent<fleer>().target = targetOne;
        humanOne.GetComponent<fleer>().fleeState = fleer.fleerState.defaultFlee;
        //add to list
        humans.Add(one.GetComponent<agent>());
        //this is the same for the rest

        Vector3 spawnTwo = new Vector3();
        spawnTwo.x = -8f;
        spawnTwo.y = -2.9f;
       GameObject two= Instantiate(humanTwo, spawnTwo, Quaternion.identity);
        humanTwo.GetComponent<agent>().manager = this;
        humanTwo.GetComponent<fleer>().target = targetOne;
        humanTwo.GetComponent<fleer>().fleeState = fleer.fleerState.defaultFlee;
        humans.Add(two.GetComponent<agent>());

        //taregt 2

        Vector3 spawnThree = new Vector3();
        spawnThree.x = -8f;
        spawnThree.y = -2.9f;
       GameObject three = Instantiate(humanThree, spawnThree, Quaternion.identity);
        humanThree.GetComponent<agent>().manager = this;
        humanThree.GetComponent<fleer>().target = targetTwo;
        humanThree.GetComponent<fleer>().fleeState = fleer.fleerState.defaultFlee;
        humans.Add(three.GetComponent<agent>());

        Vector3 spawnFour = new Vector3();
        spawnFour.x = 9.09f;
        spawnFour.y = 2.46f;
        GameObject four =Instantiate(humanFour, spawnFour, Quaternion.identity);
        humanFour.GetComponent<agent>().manager = this;
        humanFour.GetComponent<fleer>().target = targetTwo;
        humanFour.GetComponent<fleer>().fleeState = fleer.fleerState.defaultFlee;
        humans.Add(four.GetComponent<agent>());

        //target 3

        Vector3 spawnFive = new Vector3();
        spawnFive.x = 5.11f;
        spawnFive.y = -1.92f;
        GameObject five =Instantiate(humanFive, spawnFive, Quaternion.identity);
        humanFive.GetComponent<agent>().manager = this;
        humanFive.GetComponent<fleer>().target = targetThree;
        humanFive.GetComponent<fleer>().fleeState = fleer.fleerState.defaultFlee;
        humans.Add(five.GetComponent<agent>());

        Vector3 spawnSix = new Vector3();
        spawnSix.x = -7.22f;
        spawnSix.y = 3.82f;
        GameObject six = Instantiate(humanSix, spawnSix, Quaternion.identity);
        humanSix.GetComponent<agent>().manager = this;
        humanSix.GetComponent<fleer>().target = targetThree;
        humanSix.GetComponent<fleer>().fleeState = fleer.fleerState.defaultFlee;
        humans.Add(six.GetComponent<agent>());

        //target 4

        Vector3 spawnSeven = new Vector3();
        spawnSeven.x = -6.02f;
        spawnSeven.y = -0.94f;
        GameObject seven = Instantiate(humanSeven, spawnSeven, Quaternion.identity);
        humanSeven.GetComponent<agent>().manager = this;
        humanSeven.GetComponent<fleer>().target = targetFour;
        humanSeven.GetComponent<fleer>().fleeState = fleer.fleerState.defaultFlee;
        humans.Add(seven.GetComponent<agent>());

        Vector3 spawnEight = new Vector3();
        spawnEight.x = -8.04f;
        spawnEight.y = 1.72f;
       GameObject eight= Instantiate(humanEight, spawnEight, Quaternion.identity);
        humanEight.GetComponent<agent>().manager = this;
        humanEight.GetComponent<fleer>().target = targetFour;
        humanEight.GetComponent<fleer>().fleeState = fleer.fleerState.defaultFlee;
        humans.Add(eight.GetComponent<agent>());





    }
    /// <summary>
    /// spawns seeker
    /// </summary>
    public void SpawnSeeker()
    {
        Vector3 spawnhunter = new Vector3();
        //spawn location
        spawnhunter.x = 4.5f;
        spawnhunter.y = 3.97f;
        //make
        Instantiate(hunter, spawnhunter, Quaternion.identity);
        //assigns
        hunter.GetComponent<agent>().manager = this;
        hunter.GetComponent<seeker>().target = targetOne;
        //chnage speed
        hunter.GetComponent<PhysicsObject>().mass = 2.0f;


        //again
        Vector3 spawnhunterTwo = new Vector3();
        spawnhunterTwo.x = -4.5f;
        spawnhunterTwo.y = 3.97f;
        GameObject next = Instantiate(hunter, spawnhunterTwo, Quaternion.identity);
        next.GetComponent<agent>().manager = this;
        next.GetComponent<seeker>().target = targetOne;
        next.GetComponent<PhysicsObject>().mass = 2.0f;



    }


    /// <summary>
    /// switches state if vampire is close
    /// </summary>
    private void SwitchState()
    {
        //radius for each
        float hunt = 1f;
        float wander = 0.1f;
        foreach (agent now in agents)
        {
            //start with not found
            bool found = false;
            foreach (agent human in humans)
            {
                //check distance between each human and vamp
                distance = Vector3.Distance(now.transform.position, human.transform.position);

                //if in the radius
                if (distance < hunt)
                {
                    //switch states 
                    Debug.Log("Found human, move hunt state.");
                    now.GetComponent<wanderer>().SwitchState(wanderer.State.hunt);
                    found = true;
                    break; 
                }
            }
            //otherwise
            if (!found && distance > wander)
            {
                //switch to wander 
                Debug.Log("No human found , move wander state.");
                now.GetComponent<wanderer>().SwitchState(wanderer.State.wander);
            }
        }
    }

    /// <summary>
    /// flock
    /// was not used
    /// </summary>
    /// <returns></returns>
    public agent FlockClosestPlayer()
    {

        float min = Mathf.Infinity, dis;  
        agent nearest = null;


        foreach (agent player in agents)
        {
            //if not it
            if (player != ItPlayer)
            {
                dis = Vector2.Distance(ItPlayer.transform.position, player.transform.position);
                //if distance is less then min
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






