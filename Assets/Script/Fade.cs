using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public GameManagerLogic manager;
    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    public UnityEngine.UI.Image fade;
    public float alpha = 1.0f;
    public float alpha2 = 1.0f;
    public float alpha3 = 1.0f;
    public float alpha4 = 0.0f;
    Renderer rend;
    Renderer rend2;
    Renderer rend3;

    // Start is called before the first frame update
    void Start()
    {
        rend = target.GetComponent<Renderer>();
        rend2 = target2.GetComponent<Renderer>();
        rend3 = target3.GetComponent<Renderer>();
        fade.color = new Color(1, 1, 1, 0.0f);
        StartCoroutine(FadeOut());
        StartCoroutine(FadeOut2());
        //StartCoroutine(FadeOut3());
        StartCoroutine(FadeDelete());
        StartCoroutine(EndingFade());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    IEnumerator FadeOut()
    {
        while (alpha >= 0)
        {
            if(manager.second >= 30 && manager.minute == 0 && alpha > 0)
            {
                alpha -= 0.05f;
                Color newColor = new Color(1, 1, 1, alpha);
                rend.material.color = newColor;
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeOut2()
    {
        while (alpha2 >= 0)
        {
            if (manager.minute >= 1 && manager.second >= 0 && alpha2 > 0)
            {
                alpha2 -= 0.05f;
                Color newColor2 = new Color(1, 1, 1, alpha2);
                rend2.material.color = newColor2;
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    /*IEnumerator FadeOut3()
    {
        while (alpha3 >= 0)
        {
            if (manager.minute >= 1 && manager.second >= 30 && alpha3 > 0)
            {
                alpha3 -= 0.05f;
                Color newColor3 = new Color(1, 1, 1, alpha3);
                rend3.material.color = newColor3;
            }

            yield return new WaitForSeconds(0.01f);
        }
    }*/

    IEnumerator FadeDelete()
    {
        yield return new WaitForSeconds(5.0f);

        if (alpha <= 0)
        {
            target.gameObject.SetActive(false);
        }

        if (alpha2 <= 0)
        {
            target2.gameObject.SetActive(false);
        }

        if (alpha3 <= 0)
        {
            target3.gameObject.SetActive(false);
        }
    }

    IEnumerator EndingFade()
    {
        while (alpha4 <= 1)
        {
            if (manager.minute >= 1 && manager.second >= 30 && alpha4 < 1)
            {
                alpha4 += 0.04f;
                fade.color = new Color(1, 1, 1, alpha4);
            }

            if (alpha4 >= 1 && manager.Durability >= 80)
                SceneManager.LoadScene("Ending3");

            else if (alpha4 >= 1 && manager.Durability >= 40 && manager.Durability < 80)
                SceneManager.LoadScene("Ending1");

            else if (alpha4 >= 1 && manager.Durability < 40)
                SceneManager.LoadScene("Ending2");

            yield return new WaitForSeconds(0.01f);
        }

    }
}
