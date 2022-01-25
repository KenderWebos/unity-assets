using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //public string name = "generic";

    public void setName(string name)
    {
        if (name != null)
        {
            this.name = name;
        }
    }
}
