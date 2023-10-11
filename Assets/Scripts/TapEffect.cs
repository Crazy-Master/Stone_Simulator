using TMPro;
using UnityEngine;

public class TapEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public void Init(float value)
    {
        float time = Mathf.Round(value * 10) / 10;
        _text.text = value.ToString();
    }
    public void DestroyGameObj()
    {        
        Destroy(gameObject);
    }

}
