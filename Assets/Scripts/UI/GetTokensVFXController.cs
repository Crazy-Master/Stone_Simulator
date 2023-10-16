using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class GetTokensVFXController : MonoBehaviour
{
    [SerializeField] private GameObject _tokenPrefab;
    [SerializeField] private Transform _parentTarget;

    public void AddTokensVFX(int value, Vector3 fromTarget)
    {
        var quantity = Mathf.Abs(value);
        if (quantity > 5) quantity = 5;
        for (int i = 0; i < quantity; i++)
        {
            int x = Random.Range(-100, 100);
            int y = Random.Range(-100, 100);
            var position = _parentTarget.position;
            Vector3 target = new Vector3( fromTarget.x + x,fromTarget.y + y,fromTarget.z);
            ShowGetTokensVFX(target, _parentTarget.position);
        }
    }

    public void RemoveTokensVFX(int value)
    {
        var quantity = Mathf.Abs(value);
        if (quantity > 5) quantity = 5;
        for (int i = 0; i < quantity; i++)
        {
            int x = Random.Range(-200, 200);
            int y = Random.Range(100, 200);
            var position = _parentTarget.position;
            Vector3 inTarget = new Vector3( position.x + x,position.y - y,position.z);
            ShowGetTokensVFX(position, inTarget);
        }
       
    }

    private void ShowGetTokensVFX(Vector3 fromTarget, Vector3 inTarget)
    {
        GameObject token = Instantiate(_tokenPrefab, fromTarget,Quaternion.identity, _parentTarget);
        token.transform.DOMove(inTarget, 1.7f, true).OnComplete(() => Hide(token));
    }

    private void Hide(GameObject token)
    {
        token.transform.DOScale(new Vector3(0, 0, 0), 0.5f).OnComplete(() => BoundeAndDestroy(token));
    }

    private void BoundeAndDestroy(GameObject token)
    {
        //_target.transform.parent.GetComponent<ButtonTween>().PunchAnim();
        Destroy(token);
    }
}
