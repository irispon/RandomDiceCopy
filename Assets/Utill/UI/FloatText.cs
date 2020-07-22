using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FloatText : MonoBehaviour
{
    private float moveSpeed;
    private float alphaSpeed;
    private float destroyTime;
    TextMeshPro text;
    Color alpha;
    PoolChild child;
 

    void Awake()
    {
        child = GetComponent<PoolChild>();
        text = GetComponent<TextMeshPro>();
        text.text = "";
      
        alpha = text.color;
    }

    IEnumerator FloatDamage(int damage,Color color)
    {
        moveSpeed = 2.0f;
        alphaSpeed = 2.0f;
        destroyTime = 2.0f;
        text.text = damage.ToString();
        text.color = color;
        alpha = text.color;
        while (alpha.a > 0.2)
        {
            transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0)); // 텍스트 위치

            alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
            text.color = alpha;
            //Debug.Log(alpha.a);
            yield return new WaitForFixedUpdate();
        }
        child.Turn();

    }
    // Update is called once per frame
    public void GetDamage(int damage)
    {
        GetDamage(damage, Color.black);
    }
    public void GetDamage(int damage,Color color)
    {
        StartCoroutine(FloatDamage(damage,color));
    }

    private void OnDisable()
    {
          text.text = "";
     //   text.color=Color.black;
     //   alpha = text.color;
    }


}



