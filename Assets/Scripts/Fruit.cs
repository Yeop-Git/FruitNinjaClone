using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    /*
    void Update()
    {
        // Space 키다운시 true를 반환
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSlicedFruit();
        }
    }
    */

    void CreateSlicedFruit()
    {
        Quaternion rotationOffset = Quaternion.identity; // 기본 회전값 Euler(0, 0, 0)
        if (slicedFruitPrefab.name.StartsWith("Banana"))
            rotationOffset = Quaternion.Euler(90, 90, 0); // 바나나의 경우 회전값 변경
        
        GameObject inst =Instantiate(slicedFruitPrefab, transform.position, transform.rotation * rotationOffset);
        //현재 GameObject와 동일한 transform으로 slicedFruitPrefab을 생성
        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>(); // 자식들의 rigidbody를 배열로 반환
        foreach (Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation; //랜덤 회전각 부여
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 3f); //AddExplosionForce(range, position, explosionRadius)
        }
        Destroy(inst.gameObject, 5f); //토막난 과일을 5초후에 제거(최적화)
        Destroy(gameObject); //현재 GameObject를 제거
        
        GameManager.Instance.IncreaseScore();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)
            return;
        CreateSlicedFruit();
    }
}
