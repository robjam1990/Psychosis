import tkinter as tk

def show_tooltip(event):
    global tooltip
    tooltip = tk.Toplevel(root)
    tooltip.geometry(f"+{event.x_root+10}+{event.y_root+10}")
    tooltip.overrideredirect(True)
    tooltip_label = tk.Label(tooltip, text=message, bg='white', relief='solid', borderwidth=1)
    tooltip_label.pack()

def hide_tooltip(event):
    if tooltip:
        tooltip.destroy()

root = tk.Tk()
root.geometry("200x200")

element = tk.Label(root, text="Hover over me!")
element.pack()

message = "This is a tooltip message"

element.bind("<Enter>", show_tooltip)
element.bind("<Leave>", hide_tooltip)

root.mainloop()
