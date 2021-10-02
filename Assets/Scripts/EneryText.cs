using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; //��Ʈ������ �ʿ��ؿ�
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

        float targetPositionY = rectTransform.anchoredPosition.y + 50f; //������

        energyText.DOFade(0f, 0.5f).OnComplete(()=> Despawn()); //���� ,�ɸ��½ð� ������ ����
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f); // ��Ŀ�����ǰ��� Ÿ�������ǰ� ���̷� �ٲ۴� 0.5�ʵ���
    }
    public void Despawn()
    {
        energyText.DOFade(1f, 0f);
        transform.SetParent(pool);
        gameObject.SetActive(false);
    }

}
