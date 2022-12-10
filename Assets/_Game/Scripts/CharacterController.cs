using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private string currentAnim;
    [SerializeField] public Vector3 spawn; //Vi tri spawn cua nhan vat

    // Change Animation
    protected void Start()
    {
    }

    protected void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
}
