using System;
using Unity.VisualScripting;
using UnityEngine;

public class ParrotScirpt : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D parrotBody;
    public float previousValueOfRotation;
    void Start()
    {
        parrotBody = GetComponent<Rigidbody2D>();
        previousValueOfRotation=parrotBody.rotation;
    }
    void Update()
    {
        //At each frame, we reinitialize the animation of the parrot
        previousValueOfRotation=SetAnimator(previousValueOfRotation);
    }
    public float SetAnimator(float _previousValueOfRotation)
    {
        bool rotate =false; //booleen that returns false if the parrot should not rotate, true if he rotates
        float valueOfActualRotation = parrotBody.rotation;
        //We look if the rotation of the parrot between -50 and 50 degree or if he does not rotates too fast
        if (Math.Abs(valueOfActualRotation)%360 >= 50 || Math.Abs(valueOfActualRotation)%360 >= 310 || Math.Abs(valueOfActualRotation - previousValueOfRotation) >10)
        {
            rotate=true; //in this case, the parrot rotates
        }
        animator.SetBool("isHit", rotate); //we set the value of rotation to the animator
        return parrotBody.rotation;
    }
}
