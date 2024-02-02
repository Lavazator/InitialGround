using Godot;

public partial class CounterLabel : Label {
    private int currentValue = 0;

    public override void _Process(double delta)
    {
        // Update the text only if necessary
        string newValue = currentValue.ToString();
        if (Text != newValue) {
            Text = newValue;
        }
    }

    public void UpdateValue(int value) {
        if (value != currentValue) {
            Tween tween = CreateTween();
            tween.TweenProperty(this, "currentValue", value, 1.0d);
        }
    }

    public void UpdateValueInstant(int value) {
        Text = value.ToString();
    }
}