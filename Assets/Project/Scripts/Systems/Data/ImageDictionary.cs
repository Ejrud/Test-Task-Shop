using UnityEngine;

[CreateAssetMenu(menuName = "Items/ImageDictionary")]
public class ImageDictionary : ScriptableObject
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite[] _sprites;

    public Sprite GetSpriteByName(string name)
    {
        foreach (var sprite in _sprites)
        {
            if (name == sprite.name)
                return sprite;
        }

        return _defaultSprite;
    }
}
