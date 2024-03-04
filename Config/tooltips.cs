using System;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        // Example usage:
        Button button = new Button();
        button.Text = "Hover Over Me";
        Form form = new Form();
        form.Controls.Add(button);
        form.Load += (sender, e) =>
        {
            ShowTooltip(button, "This is a tooltip message.");
        };
        Application.Run(form);
    }

    static void ShowTooltip(Control control, string message)
    {
        ToolTip toolTip = new ToolTip();
        toolTip.SetToolTip(control, message);
    }
}
