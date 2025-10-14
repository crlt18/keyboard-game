using UnityEngine;

public class KeyPressed : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private KeyCode _keyCode; 
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (System.Enum.TryParse(tag, true, out KeyCode parsedKey))
        {
            _keyCode = parsedKey;
        }
        else
        {
            Debug.LogWarning($"Invalid tag for key: {tag}");
        }
    }

    private void Update()
    {
        OnKeyPressed();
    }
    private void OnKeyPressed()
    {
        if (Input.GetKey(_keyCode))
        {
            _spriteRenderer.color = Color.red;
        }
        else
        {
            _spriteRenderer.color = Color.green;
        }
    }
}
