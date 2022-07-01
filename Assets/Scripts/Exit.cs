using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}