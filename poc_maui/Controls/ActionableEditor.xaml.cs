namespace poc_maui.Controls;

public partial class ActionableEditor : ContentView
{
    private string _fullText;
    private int _maxCharactersForTruncatedText;

    public ActionableEditor()
    {
        InitializeComponent();

        if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
        {
            _maxCharactersForTruncatedText = 250;
        }
        else
        {
            _maxCharactersForTruncatedText = 100;
        }
    }

    public string EditorText
    {
        get => (string)GetValue(EditorTextProperty);
        set => SetValue(EditorTextProperty, value);
    }
    public static readonly BindableProperty EditorTextProperty =
           BindableProperty.Create(nameof(EditorText), typeof(string), typeof(string), default(string),
               BindingMode.TwoWay);

    public string EditorPlceholderText
    {
        get => (string)GetValue(EditorPlceholderTextProperty);
        set => SetValue(EditorPlceholderTextProperty, value);
    }
    public static readonly BindableProperty EditorPlceholderTextProperty =
           BindableProperty.Create(nameof(EditorPlceholderText), typeof(string), typeof(string), default(string),
               BindingMode.TwoWay);

    public bool IsButtonVisible
    {
        get => (bool)GetValue(IsButtonVisibleProperty);
        set => SetValue(IsButtonVisibleProperty, value);
    }
    public static readonly BindableProperty IsButtonVisibleProperty =
        BindableProperty.Create(nameof(IsButtonVisible), typeof(bool), typeof(ActionableEditor), false, BindingMode.TwoWay);

    public Command ButtonCommand
    {
        get => (Command)GetValue(ButtonCommandProperty);
        set => SetValue(ButtonCommandProperty, value);
    }
    public static readonly BindableProperty ButtonCommandProperty =
        BindableProperty.Create(nameof(ButtonCommand), typeof(Command), typeof(ActionableEditor));

    public object ButtonCommandParameter
    {
        get => GetValue(ButtonCommandParameterProperty);
        set => SetValue(ButtonCommandParameterProperty, value);
    }
    public static readonly BindableProperty ButtonCommandParameterProperty =
            BindableProperty.Create(nameof(ButtonCommandParameter), typeof(object), typeof(ActionableEditor));

    private void OnEditorFocused(object sender, FocusEventArgs e)
    {
        // Restore full text when editing
        editorControl.Text = !string.IsNullOrEmpty(_fullText) ? _fullText : EditorText + _fullText;

        // Set the cursor to the end of the text
        if (!string.IsNullOrEmpty(editorControl.Text))
        {
            editorControl.CursorPosition = editorControl.Text.Length;
            editorControl.SelectionLength = 0;
        }

        InvalidateMeasure();
    }

    private void OnEditorUnfocused(object sender, FocusEventArgs e)
    {
        // Store the full text
        _fullText = editorControl.Text;

        // Truncate text with ellipsis
        if (_fullText != null && _fullText.Length > _maxCharactersForTruncatedText)
        {
            editorControl.Text = _fullText.Substring(0, _maxCharactersForTruncatedText - 3) + "...";
        }

        InvalidateMeasure();
    }

}
