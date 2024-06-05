using System;
namespace poc_maui.Controls
{
	public class CustomEditor : Editor
	{
        private string _fullText;
        private const int MaxCharsForTruncatedText = 120;

        public CustomEditor()
        {
            this.Focused += TruncatedEditor_Focused;
            this.Unfocused += TruncatedEditor_Unfocused;
            this.AutoSize = EditorAutoSizeOption.TextChanges;
        }

        private void TruncatedEditor_Unfocused(object sender, FocusEventArgs e)
        {
            // Store the full text
            _fullText = Text;

            // Truncate text with ellipsis
            if (_fullText != null && _fullText.Length > MaxCharsForTruncatedText)
            {
                Text = _fullText.Substring(0, MaxCharsForTruncatedText - 3) + "...";
            }

            InvalidateMeasure();
        }

        private void TruncatedEditor_Focused(object sender, FocusEventArgs e)
        {
            Text = _fullText;

            if (!string.IsNullOrEmpty(Text))
            {
                CursorPosition = Text.Length;
                SelectionLength = 0;
            }

            InvalidateMeasure();
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            // Measure the height based on the current text and width constraint
            var size = base.OnMeasure(widthConstraint, heightConstraint);
            var textLength = Text?.Length ?? 0;

            // Estimate the number of lines needed based on character count and width
            int charsPerLine = (int)(widthConstraint / 7); // Adjust average character width as needed
            int lineCount = (int)Math.Ceiling((double)textLength / charsPerLine);

            // Adjust height based on the estimated number of lines
            double newHeight = lineCount * size.Request.Height;
            return new SizeRequest(new Size(size.Request.Width, newHeight));
        }
    }
}

