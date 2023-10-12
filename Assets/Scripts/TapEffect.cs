using TMPro;
using UnityEngine;

public class TapEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public void Init(float value)
    {
        float time = Mathf.Round(value * 10) / 10;
        if (time > 0)
        {
            _text.text = "-" + value;
        }else _text.text = "+" + -value;
    }
    public void DestroyGameObj()
    {        
        Destroy(gameObject);
    }

}
