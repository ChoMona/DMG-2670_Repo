using System;
using System.Collections;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
   public IntData playerJumpCount, normalJumpCount, powerUpCount;
   public float waitTime = 2f;

   private void Start()
   {
      playerJumpCount.value = normalJumpCount.value;
   }

   //Power up lasts 2 seconds, disappears as it's collected, and goes away
   private IEnumerator OnTriggerEnter(Collider other)
   {
      playerJumpCount.value = powerUpCount.value;
      GetComponent<MeshRenderer>().enabled = false;
      GetComponent<Collider>().enabled = false;
      yield return new WaitForSeconds(waitTime);
      playerJumpCount.value = normalJumpCount.value;
      gameObject.SetActive(false);
   }
   
   
   //Use this for a permanent power up!!
  // private void OnTriggerExit(Collider other)
   //{
     // playerJumpCount.value = powerUpCount.value;
      //gameObject.SetActive(false);
   //}
}
