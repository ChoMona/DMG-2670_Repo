

using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  public IntData scoreValue;
  private Text _text;

  private void Start()
  {
    _text = GetComponent<Text>();
  }

  private void Update()
  {
    _text.text = scoreValue.value.ToString();
  }
}
