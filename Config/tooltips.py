import tkinter as tk

def show_tooltip(widget, message):
    def on_hover(event):
        # Create and position tooltip element
        tooltip = tk.Toplevel(widget)
        tooltip.geometry(f"+{widget.winfo_rootx() + widget.winfo_width()}+{widget.winfo_rooty()}")
        tooltip.overrideredirect(True)  # Remove window borders
        tooltip_label = tk.Label(tooltip, text=message, bg='lightyellow', relief='solid', borderwidth=1)
        tooltip_label.pack()

        # Remove tooltip when mouse leaves element
        def on_leave(event):
            tooltip.destroy()

        widget.bind('<Leave>', on_leave)

    widget.bind('<Enter>', on_hover)

# Example usage:
root = tk.Tk()
button = tk.Button(root, text="Hover Over Me")
button.pack()
show_tooltip(button, "This is a tooltip message.")
root.mainloop()
