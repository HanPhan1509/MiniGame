using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class PlayerController : CharacterController
{
    private Vector3 target;
    [SerializeField] private GameObject guilder;
    private int checkList = 0;
    // Start is called before the first frame update
    private void Start()
    {
        ChangeAnim("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
    }

    private void SetTarget()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target = transform.position + Vector3.forward * 2;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 10f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            target = transform.position + Vector3.back * 2;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward * -1), 10f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            target = transform.position + Vector3.right * 2;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 10f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target = transform.position + Vector3.left * 2;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 10f);
        }
        else if (target != Vector3.zero)
        {
            this.transform.position = Move(target, 10f);
            StopMoving();
        }
    }

    private Vector3 Move(Vector3 target, float t)
    {
        ChangeAnim("Run");
        return Vector3.Lerp(transform.position, target, t);
    }

    private void StopMoving()
    {
        if (transform.position == target)
        {
            target = Vector3.zero;
            ChangeAnim("Idle");
            CheckCollideCompareWithList();
        }
    }

    public void CheckCollideCompareWithList()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.down), out hit, 10f))
        {
            Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            if (hit.collider.tag == "Step")
            {
                if (hit.collider.transform.position.x == guilder.GetComponent<BotController>().listWay[checkList].x
                    && hit.collider.transform.position.z == guilder.GetComponent<BotController>().listWay[checkList].z)
                {
                    Debug.Log("True direction");
                    checkList++;
                }
                else
                {
                    hit.collider.GetComponent<StepController>().ChangeColorFalse();
                    UIController.instance.uiPlayAgain.gameObject.SetActive(true);
                    UIController.instance.uiFrameSetting.gameObject.SetActive(false);
                }

            }
        }
    }
}
