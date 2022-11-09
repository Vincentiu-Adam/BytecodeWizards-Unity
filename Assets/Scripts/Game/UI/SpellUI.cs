using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SpellUI : MonoBehaviour
{
    [SerializeField]
    private SpellType spellType;

    private void Awake()
    {
        Button spellButton = GetComponent<Button>();
        spellButton.onClick.AddListener(OnLaunch);
    }

    private void OnLaunch()
    {
        //cast spell
        SpellRepository spellRepository = ServiceLocator.GetSpellRepository();
        byte[] spellData = spellRepository.GetSpellData(spellType);

        VM spellVM = ServiceLocator.GetVM();
        spellVM.Interpret(spellData);

        //update ui
        Utility.UpdateUIData();
    }
}
