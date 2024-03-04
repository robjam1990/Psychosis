# Colour Palette
colours = {
    "background": {
        "window": "#F0F0F0",  # Light Gray
        "control": "#FFFFFF",  # White
        "progress": "#00CED1"  # Dark Turquoise
    },
    "text": {
        "window": "#000000",  # Black
        "control": "#000000",  # Black
        "progress": "#000000"  # Black
    },
    "highlight": {
        "control": "#00CED1"  # Dark Turquoise
    },
    "selected": {
        "control": "#A9A9A9"  # Dark Gray
    }
}

# Interface Description
interface_description = f"""
Welcome to the world of Psychosis, set in the vibrant realm of Thear. As you explore this vast and immersive universe, you'll encounter a variety of environments and challenges. To enhance your experience, we've designed a visually stunning interface with carefully chosen colours.

Colour Palette:
- Background:
  - Window: {colours['background']['window']} (Light Gray)
  - Control: {colours['background']['control']} (White)
  - Progress: {colours['background']['progress']} (Dark Turquoise)
- Text:
  - Window: {colours['text']['window']} (Black)
  - Control: {colours['text']['control']} (Black)
  - Progress: {colours['text']['progress']} (Black)
- Highlight:
  - Control: {colours['highlight']['control']} (Dark Turquoise)
- Selected:
  - Control: {colours['selected']['control']} (Dark Gray)

These colours have been selected to provide a clear and immersive experience as you navigate the world of Psychosis. Whether you're engaging in tactical combat, managing your nation, or exploring the ecosystem, these colours will help you stay focused and engaged.

We hope you enjoy your adventure in Psychosis, where every choice you make shapes the world around you. Dive in and explore the possibilities that await!
"""

print(interface_description)
