# File = robjam1990/Psychosis/Models/Password.py
from math.matrix.Matrix import generate as generate_matrix, dot

# Password

MIN_PASSWORD_LENGTH = 8
MAX_PASSWORD_LENGTH = 16

def accept_password_input():
    password = []
    i = 0

    print(f'Enter your password (min {MIN_PASSWORD_LENGTH} characters): ')

    while True:
        ch = ord(getch())
        if ch == 13 or i >= MAX_PASSWORD_LENGTH - 1:
            break
        elif ch != 8:  # Check for backspace
            print('*', end='', flush=True)  # Print asterisks instead of actual characters
            password.append(chr(ch))
            i += 1
        elif i > 0:  # Handle backspace
            print('\b \b', end='', flush=True)  # Move cursor back, overwrite with space, move cursor back again
            i -= 1

    password.append('\0')  # Null terminate the password string

    if i < MIN_PASSWORD_LENGTH:
        print(f'\nPassword is too short. Please use at least {MIN_PASSWORD_LENGTH} characters.\n')
    else:
        print("\nPassword accepted. You can now proceed with the game.\n")

    return password

def encrypt(password):
    # Implementation to encrypt the password
    return password

alphabet_code_shift = ord('A')
english_alphabet_size = 26

def square_matrix_rotation(original_matrix):
    matrix = original_matrix[:]
    size = len(matrix)

    for i in range(size // 2):
        for j in range(i, size - i - 1):
            temp = matrix[i][j]
            matrix[i][j] = matrix[size - 1 - j][i]
            matrix[size - 1 - j][i] = matrix[size - 1 - i][size - 1 - j]
            matrix[size - 1 - i][size - 1 - j] = matrix[j][size - 1 - i]
            matrix[j][size - 1 - i] = temp

    return matrix

ZERO_OR_MORE_CHARS = '*'
ANY_CHAR = '.'

def regular_expression_matching(string, pattern):
    match_matrix = [[False] * (len(pattern) + 1) for _ in range(len(string) + 1)]
    match_matrix[0][0] = True

    for column_index in range(1, len(pattern) + 1):
        if pattern[column_index - 1] == '*':
            match_matrix[0][column_index] = match_matrix[0][column_index - 2]

    for row_index in range(1, len(string) + 1):
        for column_index in range(1, len(pattern) + 1):
            string_index = row_index - 1
            pattern_index = column_index - 1

            if pattern[pattern_index] == '.' or pattern[pattern_index] == string[string_index]:
                match_matrix[row_index][column_index] = match_matrix[row_index - 1][column_index - 1]
            elif pattern[pattern_index] == '*':
                match_matrix[row_index][column_index] = match_matrix[row_index][column_index - 2]
                if pattern[pattern_index - 1] == '.' or pattern[pattern_index - 1] == string[string_index]:
                    match_matrix[row_index][column_index] |= match_matrix[row_index - 1][column_index]
            else:
                match_matrix[row_index][column_index] = False

    return match_matrix[len(string)][len(pattern)]

def generate_key_matrix(key_string):
    matrix_size = int(len(key_string) ** 0.5)
    if matrix_size * matrix_size != len(key_string):
        raise ValueError('Invalid key string length. The square root of the key string must be an integer')

    key_string_index = 0
    return generate_matrix([matrix_size, matrix_size], lambda: (ord(key_string[key_string_index]) % alphabet_code_shift, key_string_index := key_string_index + 1)[0])

def generate_message_vector(message):
    return generate_matrix([len(message), 1], lambda cell_indices: ord(message[cell_indices[0]]) % alphabet_code_shift)

def hill_cipher_encrypt(message, key_string):
    only_letters_regexp = /^[a-zA-Z]+$/
    if not only_letters_regexp.match(message) or not only_letters_regexp.match(key_string):
        raise ValueError('The message and key string can only contain letters')

    key_matrix = generate_key_matrix(key_string)
    message_vector = generate_message_vector(message)

    if len(key_matrix) != len(message):
        raise ValueError('Invalid key string length. The key length must be a square of message length')

    cipher_vector = dot(key_matrix, message_vector)
    cipher_string = ''
    for item in cipher_vector:
        cipher_string += chr((item % english_alphabet_size) + alphabet_code_shift)

    return cipher_string

def hill_cipher_decrypt():
    raise NotImplementedError('This method is not implemented yet')

english_alphabet = list('abcdefghijklmnopqrstuvwxyz')

def get_cipher_map(alphabet, shift):
    return {current_char: alphabet[(char_index + shift) % len(alphabet)] for char_index, current_char in enumerate(alphabet)}
