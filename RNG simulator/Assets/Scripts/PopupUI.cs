using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupUI : MonoBehaviour
{
    public static PopupUI Instance;

    public GameObject popupPanel;

    public RawImage minionImage;

    public TextMeshProUGUI minionName;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMinion(Minion minion)
    {
        StartCoroutine(ShowPopup(minion));
    }

    IEnumerator ShowPopup(Minion minion)
    {
        popupPanel.SetActive(true);

        minionName.text = minion.minionName;

        if (minion.image != null)
        {
            minionImage.texture =
                minion.image.texture;
        }

        popupPanel.transform.localScale =
            Vector3.zero;

        float timer = 0;

        while (timer < 0.25f)
        {
            timer += Time.deltaTime;

            popupPanel.transform.localScale =
                Vector3.Lerp(
                    Vector3.zero,
                    Vector3.one,
                    timer / 0.25f);

            yield return null;
        }

        yield return new WaitForSeconds(2f);

        popupPanel.SetActive(false);

        switch (minion.rarity)
        {
            case Rarity.Common:
                popupPanel.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                break;

            case Rarity.Rare:
                popupPanel.GetComponent<UnityEngine.UI.Image>().color = Color.blue;
                break;

            case Rarity.Epic:
                popupPanel.GetComponent<UnityEngine.UI.Image>().color = new Color(0.6f, 0f, 1f);
                break;

            case Rarity.Legendary:
                popupPanel.GetComponent<UnityEngine.UI.Image>().color = Color.yellow;
                break;

            case Rarity.Mythic:
                popupPanel.GetComponent<UnityEngine.UI.Image>().color = Color.red;
                break;
        }
    }
}
