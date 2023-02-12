using UnityEngine;
using UnityEngine.UI;


public class LetterTiles : MonoBehaviour
{
    public Color defaultColor;
    public Color rightColor;
    public Color wrongColor;

    TileStates _currentState = TileStates.DEFAULT;

    private Image _tileImage;

    public TileType tileType;

    public void SetState( TileStates state)
    {
        _currentState = state;
    }

    private void Start()
    {
        _tileImage = GetComponent<Image>();
        RefreshTile();
    }

    private void Update()
    {
        RefreshTile();
    }

    void RefreshTile()
    {
        if (_currentState == TileStates.DEFAULT)
        {
            _tileImage.color = defaultColor;
        }
        else if (_currentState == TileStates.RIGHT) {
            _tileImage.color = rightColor;
        }
        else {
            _tileImage.color = wrongColor;
        }
    }
}
