using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class off_UI : MonoBehaviour
{
    public TMP_InputField discard_value; // ���� ���� �Է� �޾ƿ���
    public void Off_UI()
    {
        discard_value.text = "";
        transform.parent.gameObject.SetActive(false);
        
    }
}
