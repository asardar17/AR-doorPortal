using System.Collections;
using UnityEngine;

public class DelayedShow : MonoBehaviour
{
    [SerializeField] private GameObject dinnerBuilding;
    [SerializeField] private float delayTime = 10f; // ১০ সেকেন্ড পর আসবে

    void OnEnable()
    {
        if (dinnerBuilding != null)
        {
            dinnerBuilding.SetActive(false); // শুরুতে বিল্ডিং লুকিয়ে রাখবে
            StartCoroutine(ShowAfterDelay());
        }
    }

    IEnumerator ShowAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        if (dinnerBuilding != null)
        {
            dinnerBuilding.SetActive(true); // ১০ সেকেন্ড পর অন করবে
        }
    }
}