using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupUI : MonoBehaviour
{
    public static PopupUI Instance;

    public GameObject popupPanel;

    public Image popupBackground;

    public RawImage minionImage;

    public TextMeshProUGUI minionName;

    public TextMeshProUGUI rarityText;

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

        rarityText.text = minion.rarity.ToString();

        // Change background color based on rarity
        switch (minion.rarity)
        {
            case Rarity.Common:
                popupBackground.color = Color.white;
                rarityText.color = Color.black;
                break;

            case Rarity.Rare:
                popupBackground.color = Color.blue;
                rarityText.color = Color.black;
                break;

            case Rarity.Epic:
                popupBackground.color = new Color(0.6f, 0f, 1f);
                rarityText.color = Color.black;
                break;

            case Rarity.Legendary:
                popupBackground.color = Color.yellow;
                rarityText.color = Color.black;
                break;

            case Rarity.Mythic:
                popupBackground.color = Color.red;
                rarityText.color = Color.black;
                break;
        }

        // Set minion image
        if (minion.image != null)
        {
            minionImage.texture = minion.image.texture;
        }

        // Reset scale
        popupPanel.transform.localScale = Vector3.zero;

        float timer = 0f;
        float animationDuration = 0.25f;

        while (timer < animationDuration)
        {
            timer += Time.deltaTime;

            popupPanel.transform.localScale =
                Vector3.Lerp(
                    Vector3.zero,
                    Vector3.one,
                    timer / animationDuration);

            yield return null;
        }

        popupPanel.transform.localScale = Vector3.one;

        yield return new WaitForSeconds(2f);

        popupPanel.SetActive(false);
    }
}
