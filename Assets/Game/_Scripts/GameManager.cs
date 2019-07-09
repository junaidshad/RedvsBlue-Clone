using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject PanelGameWin;
    public GameObject PanelGameInfo;
    public TextMeshProUGUI tmpro_winInfo;


    public RectTransform red;
    public RectTransform blue;

    public float blue_offset;
    public float red_offset;

    private void Start()
    {
        red.gameObject.AddComponent<BoxCollider2D>();
        blue.gameObject.AddComponent<BoxCollider2D>();

        //ScreenResolution();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
    }

    public void OnClickBlue()
    {
        blue_offset += 60;
        red_offset += 60;
        //red.transform.
        //Debug.Log("Blue Max - " + blue.offsetMax);
        //Debug.Log("Blue Min - " + blue.offsetMin);

        blue.offsetMax = new Vector2(0,blue_offset);
        red.offsetMin = new Vector2(0, blue_offset);

        Debug.Log("Blue offset Max -- " + blue.offsetMax.y);
        if(blue.offsetMax.y >= (Screen.height / 2))
        {
            Debug.Log("BLUE WON THE BATTLE");
            PanelGameWin.SetActive(true);
            tmpro_winInfo.text = "BLUE WINS THE BATTLE";
        }

    }

    public void OnClickRed()
    {
        red_offset -= 60;
        blue_offset -= 60;
        //Debug.Log("Red Max - " + red.offsetMax);
        //Debug.Log("Red Min - " + red.offsetMin);

        red.offsetMin = new Vector2(0, red_offset);
        blue.offsetMax = new Vector2(0, red_offset);

        Debug.Log("Red Offset Min - " + red.offsetMin.y);
        Debug.Log("Screen height Red - " + (-Screen.height / 2));
        if(red.offsetMin.y <= (-Screen.height / 2))
        {
            Debug.Log("RED WON THE BATTLE");
            PanelGameWin.SetActive(true);
            tmpro_winInfo.text = "RED WINS THE BATTLE";
        }
    }
    public void TapToRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void TapToContinue()
    {
        PanelGameInfo.SetActive(false);
    }

    public void ScreenResolution()
    {
        Debug.Log("Screen Resolution - " + Screen.currentResolution);
        Debug.Log("Screen Height - " + Screen.height);
        Debug.Log("Screen Width - " + Screen.width);
    }

}
