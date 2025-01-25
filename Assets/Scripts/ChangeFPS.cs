using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFPS : MonoBehaviour
{
    public TMPro.TextMeshProUGUI CurrentFPS;
    void Update()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            CurrentFPS.SetText("FPS:" + Mathf.RoundToInt(1 / Time.deltaTime));
            yield return new WaitForSeconds(1f);
        }
    }
}
