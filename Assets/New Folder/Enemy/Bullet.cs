using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;


    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        { 
        
            //플레이어에게 데미지 주기
        
        }

    }




}
