using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BotController : CharacterController
{
    NavMeshAgent nav;
    [SerializeField] public List<Vector3> listWay = new List<Vector3>();
    [SerializeField] List<GameObject> steps;
    [SerializeField] GameObject play;
    //---
    [SerializeField] private Vector3 startPos;
    [SerializeField] private float zEnd = 10;
    private int index = 0;
    [SerializeField] public int stepCount = 7;
    //public Vector3 spawnGuilder;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        transform.position = spawn;
        steps = GameObject.FindGameObjectsWithTag("Step").ToList();
        FindPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == nav.destination && nav.destination.z != zEnd)
        {
            AutoMove();
        }
        if (transform.position.z == zEnd)
        {
            ChangeAnim("Dance");
            //play.gameObject.transform.position = new Vector3(spawnGuilder.x, spawnGuilder.y + 0.5f, spawnGuilder.z);
            play.gameObject.SetActive(true);

            transform.position = transform.position + new Vector3(0, 0, 2);
            this.gameObject.SetActive(false);
        }
    }

    private void FindPath()
    {
        while (listWay.Count != stepCount)
        {
            listWay.Clear();
            //listWay.Add(spawnGuilder);
            Vector3 nextPos = startPos;
            while (!listWay.Exists(pos => pos.z == zEnd))
            {
                int rd = Random.Range(0, 3);
                Vector3 newPos;
                if (rd == 0)
                {
                    newPos = nextPos + new Vector3(2, 0, 0);
                }
                else if (rd == 1)
                {
                    newPos = nextPos + new Vector3(-2, 0, 0);
                }
                else
                {
                    newPos = nextPos + new Vector3(0, 0, 2);
                }

                if (!listWay.Contains(newPos) && steps.Exists(pos => pos.transform.position.x == newPos.x && pos.transform.position.z == newPos.z))
                {
                    listWay.Add(nextPos);
                    nextPos = newPos;
                }
            }
        }
    }

    private void AutoMove()
    {
        ChangeAnim("Run");
        nav.destination = listWay[index];
        index++;
        if (index > listWay.Count - 1) index = listWay.Count - 1;
        /*     
        int i = 0;
        while(i < 100)
        {
            i++;
            eDirection = (EnumDirection)Random.Range(1, 5); //Random huong de di chuyen
            switch (eDirection)
            {
                case EnumDirection.left:
                    target.position = transform.position + Vector3.left * 2;
                    break;
                case EnumDirection.right:
                    target.position = transform.position + Vector3.right * 2;
                    break;
                case EnumDirection.forward:
                    target.position = transform.position + Vector3.forward * 2;
                    break;
                case EnumDirection.back:
                    target.position = transform.position + Vector3.back * 2;
                    break;
                default:
                    break;
            }
            
            foreach (GameObject brick in steps)
            {
                if (Vector3.Distance(brick.transform.position, target.position) < 0.1)
                {
                    if (listWay.Contains(target.position)) break;
                    listWay.Add(target.position);
                    nav.destination = target.position;
                    eDirection = EnumDirection.none;
                    return;
                }
            }
        }  */
    }
}
