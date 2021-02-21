using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMan : MonoBehaviour
{
    public Transform Followplatform;
    public Transform Player;
    void Update(){
Followplatform.position = new Vector3(Player.position.x, -2.23f, -4.857617f);
}
}
