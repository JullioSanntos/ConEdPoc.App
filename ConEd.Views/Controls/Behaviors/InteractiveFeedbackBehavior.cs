using Microsoft.Maui.Controls;

namespace ConEd.Views.Controls.Behaviors;

public partial class InteractiveFeedbackBehavior : Behavior<View> {
    private PointerGestureRecognizer? _pointerGesture;
    private TapGestureRecognizer? _tapGesture; // Added for mobile touches

    protected override void OnAttachedTo(View bindable) {
        base.OnAttachedTo(bindable);

        // 1. Desktop Hover Effects
        _pointerGesture = new PointerGestureRecognizer();
        _pointerGesture.PointerEntered += async (s, e) => await AnimateHoverIn(bindable);
        _pointerGesture.PointerExited += async (s, e) => await AnimateHoverOut(bindable);
        bindable.GestureRecognizers.Add(_pointerGesture);

        // 2. Mobile & Desktop Tap Effects (The "Squish & Pop")
        _tapGesture = new TapGestureRecognizer();
        _tapGesture.Tapped += async (s, e) => await AnimateTap(bindable);
        bindable.GestureRecognizers.Add(_tapGesture);
    }

    protected override void OnDetachingFrom(View bindable) {
        base.OnDetachingFrom(bindable);

        if (_pointerGesture != null)
            bindable.GestureRecognizers.Remove(_pointerGesture);

        if (_tapGesture != null)
            bindable.GestureRecognizers.Remove(_tapGesture);
    }

    private static async Task AnimateHoverIn(View element) {
        if (element is Border border) {
            border.Stroke = Color.FromArgb("#4DB6AC");
        }

        // Slight lift on hover for desktop
        await element.ScaleToAsync(1.02, 150, Easing.CubicOut);
    }

    private static async Task AnimateHoverOut(View element) {
        if (element is Border border) {
            border.Stroke = Colors.Transparent;
        }

        // Return to normal
        await element.ScaleToAsync(1.0, 150, Easing.CubicIn);
    }

    private static async Task AnimateTap(View element) {
        // The tactile mobile interaction: squish down, then pop back to 1.0
        await element.ScaleToAsync(0.95, 100, Easing.CubicOut);
        await element.ScaleToAsync(1.0, 100, Easing.CubicInOut);
    }
}