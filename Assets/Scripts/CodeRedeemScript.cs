using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class CodeRedeemScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inputFieldText;

    [SerializeField] GameObject gameManager;

    MainScript mainScript;

    // Start is called before the first frame update
    void Start()
    {
        mainScript = gameManager.GetComponent<MainScript>();
    }

    public void RedeemCode()
    {
        StartCoroutine(AttemptRedeemCode());
    }

    IEnumerator AttemptRedeemCode()
    {
        string code = inputFieldText.text.ToUpper();

        if (code.Length != 8)
        {
            Debug.Log("Enter a valid code!");
            Debug.Log(code.Length);

            StopCoroutine(AttemptRedeemCode());
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("action", "redeemcode");
            form.AddField("code", code);
            string url = "http://againsttheauthority.com/transfusion/coderedeem-proto2.php";
            UnityWebRequest w = UnityWebRequest.Post(url, form);
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                Debug.Log(w.error);
            }
            else
            {
                // Show results as text
                if (w.downloadHandler.text == "Success")
                {
                    Debug.Log("Code Redeemed!");

                    mainScript.BloodAmount += 200;
                }
                else if (w.downloadHandler.text == "Error:01")
                {
                    Debug.Log("Code does not exist!");
                }
                else if (w.downloadHandler.text == "Error:02")
                {
                    Debug.Log("Code has already been redeemed!");
                }
                //Debug.Log(w.downloadHandler.text);
                Debug.Log("Finished.");
            }
        }
    }
}
