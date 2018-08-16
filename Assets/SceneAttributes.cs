using Attributes;

public class SceneAttributes
{
    private Attribute gravity;
    private Attribute massMult;
    private Attribute dragMult;
    private Attribute angularDragMult;
    private Attribute height;

    public Attribute Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }

    public Attribute MassMult
    {
        get { return massMult; }
        set { massMult = value; }
    }

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
}