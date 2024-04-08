using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class TargetPlayerController : MonoBehaviour
{
    [SerializeField]
    public GameObject Target;
    public int xPos;
    public int zPos;

    IEnumerator CivDrop()
    {
            xPos = Random.Range(-13, 13);
            zPos = Random.Range(-5, 13);
            Instantiate(Target, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            StartCoroutine(CivDrop());
        }
    }
}
