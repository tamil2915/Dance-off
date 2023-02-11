using UnityEngine;
using UnityEngine.UI;

public class UITester : MonoBehaviour
{
    public Image aImage;
    public Image dImage;
    public Image leftImage;
    public Image rightImage;

    public float defaultOpacity = 150f;

    public InputManager inputManager;

    private void Update()
    {
        if (inputManager.CurrentKey == InputKeyStates.A)
        {
            aImage.color = new Color(255, 255, 255, 255);
        }
        else {
            aImage.color = new Color(255, 255, 255, defaultOpacity);
        }

        if (inputManager.CurrentKey == InputKeyStates.D)
        {
            dImage.color = new Color(255, 255, 255, 255);
        }
        else
        {
            dImage.color = new Color(255, 255, 255, defaultOpacity);
        }

        if (inputManager.CurrentKey == InputKeyStates.LEFT_ARROW)
        {
            leftImage.color = new Color(255, 255, 255, 255);
        }
        else {
            leftImage.color = new Color(255, 255, 255, defaultOpacity);
        }

        if (inputManager.CurrentKey == InputKeyStates.RIGHT_ARROW)
        {
            rightImage.color = new Color(255, 255, 255, 255);
        }
        else
        {
            rightImage.color = new Color(255, 255, 255, defaultOpacity);
        }
    }
}
