using UnityEngine;
using TMPro;


public class UIPeople : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _peopleText;

    private void OnEnable()
    {
        PeopleManager.OnPersonRescued += UpdateHealthText;
    }

    private void OnDisable()
    {
        PeopleManager.OnPersonRescued -= UpdateHealthText;
    }

    private void UpdateHealthText()
    {
        _peopleText.text = PeopleManager.Instance.PeopleRescued.ToString();
    }
}
