using System.Text;
using Terminal.Gui;

namespace Codesanook.LinqToEF101.Components
{
    public class Panel : FrameView
    {
        private readonly TextView textView;
        private readonly StringBuilder stringBuilder = new StringBuilder();

        public Panel(string title) : base(title)
        {
            textView = new TextView
            {
                X = Pos.At(0),
                Y = Pos.At(0),
                Width = Dim.Fill(),
                Height = Dim.Fill(), 
                ReadOnly = true
            };
            this.Add(textView);
        }

        public void AppendText(string value)
        {
            stringBuilder.AppendLine(value);
            this.textView.Text = stringBuilder.ToString();
        }
    }
}
