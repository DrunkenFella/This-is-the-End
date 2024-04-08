using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField]
    public GameObject Civ;
    public int xPos;
    public int zPos;
    public int CivCount = 0;
    void Start()
    {
        StartCoroutine(CivDrop());
    }

    IEnumerator CivDrop()
    {
        while (CivCount < Random.Range(50, 250))
        {
            xPos = Random.Range(-13, 13);
            zPos = Random.Range(-5, 13);
            Instantiate(Civ, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            CivCount++;
        }
        print($"{CivCount} Civs");
    }
}
