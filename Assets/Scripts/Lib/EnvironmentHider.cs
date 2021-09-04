using UnityEngine;

public class EnvironmentHider : MonoBehaviour
{
    private Obstructing lastObstructing; 

    private void Update()
    {
        Ray cameraRay = Camera.main.ViewportPointToRay(Camera.main.WorldToViewportPoint(transform.position));
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        RaycastHit hit = new RaycastHit();

        Physics.Raycast(cameraRay, out hit);

        Obstructing obstructing = hit.transform.GetComponent<Obstructing>();

        if (obstructing != null)
        {
            obstructing.MakeTransperent();

            if (obstructing != lastObstructing)
            {
                if (lastObstructing != null)
                {
                    lastObstructing.MakeVisible();
                }
                lastObstructing = obstructing;
            }
        }
        else
        {
            if (lastObstructing != null)
            {
                lastObstructing.MakeVisible();
                lastObstructing = null;
            }
        }
    }
}