namespace HopMedvedek.Shop;

public class ShopItem
{
    protected string name;
    protected int price;
    protected bool owned;
    protected string texture;

    public ShopItem(string theName, int thePrice, bool isOwned, string theTexture)
    {
        name = theName;
        price = thePrice;
        owned = isOwned;
        texture = theTexture;
    }
    public string Name
    {
        get => name;
        set => name = value;
    }
    public int Price
    { 
        get => price;
        set => price = value;
    }
    public bool Owned
    { 
        get => (owned == true);
        set => owned = value;
    }
    public string Texture
    {
        get => texture;
        set => texture = value;
    }
}
