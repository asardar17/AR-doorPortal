using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Transform doorL;
    public Transform doorR;

    public float delayBeforeOpening = 5f;
    public float openingDuration = 5f;
    public float openAngle = 60f;

    private Quaternion leftClosedRotation;
    private Quaternion rightClosedRotation;
    private Quaternion leftOpenRotation;
    private Quaternion rightOpenRotation;

    void Start()
    {
        leftClosedRotation = doorL.localRotation;
        rightClosedRotation = doorR.localRotation;

        leftOpenRotation = leftClosedRotation * Quaternion.Euler(0, -openAngle, 0);
        rightOpenRotation = rightClosedRotation * Quaternion.Euler(0, openAngle, 0);

        StartCoroutine(OpenDoorAutomatically());
    }

    IEnumerator OpenDoorAutomatically()
    {
        yield return new WaitForSeconds(delayBeforeOpening);

        float elapsedTime = 0f;

        while (elapsedTime < openingDuration)
        {
            elapsedTime += Time.deltaTime;

            float progress = elapsedTime / openingDuration;
            progress = Mathf.SmoothStep(0f, 1f, progress);

            doorL.localRotation = Quaternion.Slerp(
                leftClosedRotation,
                leftOpenRotation,
                progress
            );

            doorR.localRotation = Quaternion.Slerp(
                rightClosedRotation,
                rightOpenRotation,
                progress
            );

            yield return null;
        }

        doorL.localRotation = leftOpenRotation;
        doorR.localRotation = rightOpenRotation;
    }
}