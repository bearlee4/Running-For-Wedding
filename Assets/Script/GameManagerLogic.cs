using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerLogic : MonoBehaviour
{
    public GameObject ResumeButton;
    public GameObject RestartButton;
    public GameObject PausePannel;
    public GameObject BackButton;
    public GameObject MuteButton;
    public Text PauseText;
    public int playerlife;
    public float Durability;
    public float ExtraDurability;
    public Text lifeCountText;
    public Text ProtectText;
    public Text DurabilityText;
    public Text PlayTimeText;
    float time;
    public int minute;
    public int second;
    public bool GetPuase;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        minute = 0;
        Durability = 100f;
        ExtraDurability = 50f;
        lifeCountText.text = "목숨 :" + playerlife;
        ProtectText.gameObject.SetActive(false);
        DurabilityText.text = "내구도 : " + Mathf.Round(Durability) + "%";
        PlayTimeText.text = "플레이타임 : " + minute + " : " + time;
        ProtectText.text = "겉옷 착용 추가 내구도 : " + Mathf.Round(ExtraDurability) + "%";
        ResumeButton.SetActive(false);
        RestartButton.SetActive(false);
        PausePannel.SetActive(false);
        PauseText.gameObject.SetActive(false);
        BackButton.SetActive(false);
        MuteButton.SetActive(false);
        GetPuase = false;
    }

    public void LifeUpdate(int life)
    {
        lifeCountText.text = "목숨 :" + life.ToString();
    }

    public void DurabilityUpdate(float durability)
    {
        DurabilityText.text = "내구도 : " + Mathf.Round(durability) + "%";
    }

    public void ExtraDurabilityUpdate(float extradurability)
    {
        ProtectText.text = "겉옷 착용 추가 내구도 : " + Mathf.Round(ExtraDurability) + "%";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        minute = (int)(time / 60);
        second = (int)(time % 60);
        PlayTimeText.text = "플레이타임 : " + minute + " : " + second;

        if (playerlife <= 0)
        {
            SceneManager.LoadScene("Ending4");
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (GetPuase == false)
            {
                GetPuase = true;
                Time.timeScale = 0.0f;
                PauseText.gameObject.SetActive(true);
                ResumeButton.SetActive(true);
                RestartButton.SetActive(true);
                PausePannel.SetActive(true);
                BackButton.SetActive(true);
                MuteButton.SetActive(true);
            }
            else
            {
                GetPuase = false;
                Time.timeScale = 1.0f;
                PauseText.gameObject.SetActive(false);
                ResumeButton.SetActive(false);
                RestartButton.SetActive(false);
                PausePannel.SetActive(false);
                BackButton.SetActive(false);
                MuteButton.SetActive(false);
            }
            
        }


    }
}
