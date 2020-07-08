using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField]
    TMP_InputField id, password;
    [SerializeField]
    string nextScean;
    DataParser parser;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        parser = new DataParser();
        button = GetComponent<Button>();
    }

   public void Enter()
    {
        Debug.Log(id.text + password.text);
        button.interactable = false;

        if (parser.IDcheck(id.text, password.text))
        {
            Debug.Log("로그인 성공");
            parser.DeckParser(id.text);
            LoadingManager.LoadScene(nextScean, "게임으로 들어가는 중");


        }
        button.interactable = true;
     
    }
}
