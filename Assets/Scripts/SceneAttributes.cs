using Attributes;

public class SceneAttributes
{
    private Attribute gravity;
    private Attribute dragMult;
    private Attribute angularDragMult;
    private Attribute height;
    private Attribute velocity;
    private Attribute massMult;

    public Attribute Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }

    public Attribute MassMult { get; set; }

    public Attribute DragMult
    {
        get { return dragMult; }
        set { dragMult = value; }
    }

    public Attribute AngularDragMult
    {
        get { return angularDragMult; }
        set { angularDragMult = value; }
    }

    public Attribute Height
    {
        get { return height; }
        set { height = value; }
    }

    public Attribute Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }
}