#!/bin/bash
# File: robjam1990/Psychosis/Scripts/PythonInterpreter.sh

# Set Python interpreter
PYTHON="python3"

# Resolve the path to the game directory
SCRIPT="$0"
while [ -L "$SCRIPT" ]; do
    LINK=$(readlink "$SCRIPT")
    case "$LINK" in
        /*)
            SCRIPT="$LINK" ;;
        *)
            SCRIPT="$(dirname "$SCRIPT")/$LINK" ;;
    esac
done

# Determine the root directory of the game
ROOT=$(dirname "$(dirname "$(realpath "$SCRIPT")")")

# Set default platform if not provided
if [ -z "$GAME_PLATFORM" ]; then
    # Detect current platform
    GAME_PLATFORM="$(uname -s)-$(uname -m)"
    case "$GAME_PLATFORM" in
        Darwin-*|mac-*)
            GAME_PLATFORM="mac-universal" ;;
        *-x86_64|amd64)
            GAME_PLATFORM="linux-x86_64" ;;
        *-i*86)
            GAME_PLATFORM="linux-i686" ;;
        Linux-*)
            GAME_PLATFORM="linux-$(uname -m)" ;;
        *)
            ;;
    esac
fi

# Set path to game library
LIB="$ROOT/lib/$PYTHON-$GAME_PLATFORM"

# Check if platform files exist
if [ ! -d "$LIB" ]; then
    echo "Error: Platform files not found at $LIB. Please compile them or point to an existing installation."
    echo "Refer to README.md for instructions or set GAME_PLATFORM to a different platform."
    exit 1
fi

# Log script execution
LOG_DIR="$ROOT/logs"
mkdir -p "$LOG_DIR"
LOG_FILE="$LOG_DIR/$(date +'%Y-%m-%d').log"
echo "$(date +'%Y-%m-%d %H:%M:%S') - Script executed successfully" >> "$LOG_FILE"

# Execute game binary
if [ -e "$LIB/game_binary" ]; then
    exec "$LIB/game_binary" "$@"
else
    echo "Error: Game binary not found at $LIB. This game may not support the $GAME_PLATFORM platform."
    echo "$(date +'%Y-%m-%d %H:%M:%S') - Error: Game binary not found" >> "$LOG_FILE"
    exit 1
fi
