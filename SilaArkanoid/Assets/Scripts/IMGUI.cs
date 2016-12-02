using UnityEngine;
using System.Collections;

public class IMGUI : MonoBehaviour
{
    private bool showButton = false;

    void OnGUI()
    {
        LayoutGUI();
    }

    void LayoutGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.Label("Statistics Layout", GUILayout.Width(20));
        showButton = GUILayout.Toggle(showButton, "Show Button Layout");
        if(showButton)
        {
            if(GUILayout.Button("Click ME :)"))
            {
                Debug.Log("You clicked me :)");
            }
        }
        GUILayout.EndVertical();
    }

    void RectGUI()
    {
        Rect rect = new Rect(new Vector2(0, 0), new Vector2(200, 20));
        GUI.Label(rect, "Statistics");
        Rect toogleRect = new Rect(rect.position + new Vector2(0, 20), new Vector2(200, 20));
        showButton = GUI.Toggle(toogleRect, showButton, "Show button");
        if (showButton)
        {
            Rect buttonRect = new Rect(toogleRect.position + new Vector2(0, 20), new Vector2(200, 20));
            if (GUI.Button(buttonRect, "Click me :P"))
            {
                Debug.Log("You clicked me :)");
            }
        }
    }
}
