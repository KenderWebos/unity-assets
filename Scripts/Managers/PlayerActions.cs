using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Animator _animator;
    public string currentAnimation;

    public void ChangeAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation)
        {

        }

        _animator.Play(newAnimation);
    }
}
