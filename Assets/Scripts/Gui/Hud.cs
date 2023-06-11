using TMPro;
using UnityEngine;
using Zenject;

public class Hud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scores;
    
    [Inject]
    void Construct(DataModel dataModel)
    {
        _scores.text = "0";
        
        dataModel.Score.OnChanged += (s) =>
        {
            _scores.text = s.ToString();
        };
    }
}
