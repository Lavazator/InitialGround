using Godot;

public partial class CounterLabel : Label {

    // Animated Counter
    private int currentValue;
    private int targetValue;
    private double animationDuration = 2.0d;
    private double elapsedTime = 0.0d;

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (currentValue < targetValue) {
            elapsedTime += delta;
            double progress = elapsedTime / animationDuration;
            currentValue = (int)Mathf.Lerp(currentValue, targetValue, progress);
            UpdateText();
        }
    }

    private void UpdateText() {
        Text = currentValue.ToString();
    }

    public void UpdateValue(int value) {
        targetValue = value;
        elapsedTime = 0.0d;
    }
}