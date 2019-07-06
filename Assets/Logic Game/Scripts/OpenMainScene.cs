using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainScene : MonoBehaviour
{
    public Texture2D cursor;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, hotSpot, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    public void LoadNewScene()
    {

        SceneManager.LoadSceneAsync("SampleScene");
    }
    
}
