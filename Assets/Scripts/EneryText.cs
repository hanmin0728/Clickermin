using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; //다트윈쓸때 필요해요
public class EneryText : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Transform pool;

    private Text energyText = null;
    public void Show(Vector2 mousePosition)
    {
        energyText = GetComponent<Text>();
        energyText.text = string.Format("{0}", GameManager.Instance.CurrentUser.ePc);

        transform.SetParent(canvas.transform);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        gameObject.SetActive(true);


        RectTransform rectTransform = GetComponent<RectTransform>();

        float targetPositionY = rectTransform.anchoredPosition.y + 50f; //기준점

        energyText.DOFade(0f, 0.5f).OnComplete(()=> Despawn()); //투명도 ,걸리는시간 끝나면 실행
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f); // 앵커포지션값을 타겟포지션값 와이로 바꾼다 0.5초동안
    }
    public void Despawn()
    {
        energyText.DOFade(1f, 0f);
        transform.SetParent(pool);
        gameObject.SetActive(false);
    }

}
