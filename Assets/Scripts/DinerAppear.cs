using UnityEngine;
using System.Collections;

public class DinerAppear : MonoBehaviour
{
    public GameObject dinerBuilding;
    public float appearDelay = 5f;

    void Start()
    {
        StartCoroutine(ShowDinerAfterDelay());
    }

    IEnumerator ShowDinerAfterDelay()
    {
        // Make sure diner starts hidden
        if (dinerBuilding != null)
            dinerBuilding.SetActive(false);

        // Wait 5 seconds
        yield return new WaitForSeconds(appearDelay);

        // Show diner
        if (dinerBuilding != null)
            dinerBuilding.SetActive(true);
    }
}