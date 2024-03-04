#!/usr/bin/env engine
# Save Name = APUS.edit, Save Type = .py, Current File Location = robjam1990/Psychosis/Character/

import sys
import os
import subprocess
import platform
import shutil
import utils


class Editor(utils.editor.Editor):

    has_projects = True

    def get_editor_executable(self):
        """
        Returns the executable for the psychosis editor.
        Handles setup of necessary directories if not available.
        """

        editor_executable = os.environ.get("EDITOR", None)

        if editor_executable is not None:
            return editor_executable

        DIR = os.path.abspath(os.path.dirname(os.path.dirname(__file__)))
        DIR = os.path.join(utils.fs.decode(DIR), "editor")

        if utils.windows:
            editor_executable = os.path.join(DIR, "editor-windows", "editor.exe")
        elif utils.macintosh:
            editor_executable = os.path.join(DIR, "Editor.app", "Contents", "MacOS", "editor")
        else:
            editor_executable = os.path.join(DIR, "editor-linux-" + platform.machine(), "editor")

        default_dot_editor = os.path.join(DIR, "default-dot-editor")
        dot_editor = os.path.join(DIR, ".editor")

        if not os.path.exists(dot_editor) and os.path.exists(default_dot_editor):
            shutil.copytree(default_dot_editor, dot_editor)

        return editor_executable

    def begin(self, new_window=False, **kwargs):
        self.args = []

    def open_file(self, filename, line=None, **kwargs):

        if line:
            filename = "{}:{}".format(filename, line)

        self.args.append(filename)

    def open_project(self, project):
        self.args.append(project)

    def end(self, **kwargs):

        editor_executable = self.get_editor_executable()

        self.args.reverse()

        args = [editor_executable] + self.args
        args = [utils.fs.encode(i) for i in args]

        subprocess.Popen(args)


def main():
    editor_instance = Editor()
    editor_instance.begin()

    for i in sys.argv[1:]:
        editor_instance.open_file(i)

    editor_instance.end()


if __name__ == "__main__":
    main()
