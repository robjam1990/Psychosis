// File = robjam1990/Psychosis/Models/Password.js
import *as mtrx from '../../math/matrix/Matrix';

// Password

/**
 * Function to accept password input from the user.
 */
function acceptPasswordInput() {
    const password = [];
    let ch;
    let i = 0;

    console.log(`Enter your password(min ${MIN_PASSWORD_LENGTH} characters) : `);

    // Loop to read characters until Enter (ASCII 13) is pressed or maximum password length is reached
    while ((ch = getch()) != = 13 && i < MAX_PASSWORD_LENGTH - 1)
    {
        if (ch != = '\b')
        {                 // Check for backspace
            putchar('*'); // Print asterisks instead of actual characters
            password[i++] = ch;
        }
        else if (i > 0) {                    // Handle backspace
            printf("\b \b"); // Move cursor back, overwrite with space, move cursor back again
            i--;
        }
    }

    password[i] = '\0'; // Null terminate the password string

    // Check password length
    if (i < MIN_PASSWORD_LENGTH)
        console.log(`\nPassword is too short.Please use at least ${MIN_PASSWORD_LENGTH} characters.\n`);
    else
        console.log("\nPassword accepted. You can now proceed with the game.\n");

    return password;
}

/**
 * Function to encrypt the password.
 * @param {string} password - The password to encrypt.
 * @returns {string} - The encrypted password.
 */
function Encrypt(password) {
    // Implementation to encrypt the password
    return password;
}

export { acceptPasswordInput, Encrypt };

const alphabetCodeShift = 'A'.codePointAt(0);
const englishAlphabetSize = 26;

/**
 * Rotate a square matrix by 90 degrees clockwise.
 * @param {*[][]} originalMatrix - The original square matrix to rotate.
 * @return {*[][]} - The rotated square matrix.
 */
export default function squareMatrixRotation(originalMatrix) {
    const matrix = originalMatrix.slice();
    const size = matrix.length;

    for (let i = 0; i < Math.floor(size / 2); i++) {
        for (let j = i; j < size - i - 1; j++) {
            let temp = matrix[i][j];
            matrix[i][j] = matrix[size - 1 - j][i];
            matrix[size - 1 - j][i] = matrix[size - 1 - i][size - 1 - j];
            matrix[size - 1 - i][size - 1 - j] = matrix[j][size - 1 - i];
            matrix[j][size - 1 - i] = temp;
        }
    }

    return matrix;
}

const ZERO_OR_MORE_CHARS = '*';
const ANY_CHAR = '.';

/**
 * Determine if a string matches a pattern containing '*' and '.' wildcards.
 * @param {string} string - The input string.
 * @param {string} pattern - The pattern to match against.
 * @return {boolean} - Whether the string matches the pattern.
 */
/**
 * Determine if a string matches a pattern containing '*' and '.' wildcards.
 * @param {string} string - The input string.
 * @param {string} pattern - The pattern to match against.
 * @return {boolean} - Whether the string matches the pattern.
 */
export default function regularExpressionMatching(string, pattern) {
    const matchMatrix = Array(string.length + 1).fill(null).map(() = > {
        return Array(pattern.length + 1).fill(false);
    });

    matchMatrix[0][0] = true;

    for (let columnIndex = 1; columnIndex <= pattern.length; columnIndex++) {
        if (pattern[columnIndex - 1] == = '*')
        {
            matchMatrix[0][columnIndex] = matchMatrix[0][columnIndex - 2];
        }
    }

    for (let rowIndex = 1; rowIndex <= string.length; rowIndex++) {
        for (let columnIndex = 1; columnIndex <= pattern.length; columnIndex++) {
            const stringIndex = rowIndex - 1;
            const patternIndex = columnIndex - 1;

            if (pattern[patternIndex] == = '.' || pattern[patternIndex] == = string[stringIndex])
            {
                matchMatrix[rowIndex][columnIndex] = matchMatrix[rowIndex - 1][columnIndex - 1];
            }
            else if (pattern[patternIndex] == = '*')
            {
                matchMatrix[rowIndex][columnIndex] = matchMatrix[rowIndex][columnIndex - 2];
                if (pattern[patternIndex - 1] == = '.' || pattern[patternIndex - 1] == = string[stringIndex])
                {
                    matchMatrix[rowIndex][columnIndex] = matchMatrix[rowIndex][columnIndex] || matchMatrix[rowIndex - 1][columnIndex];
                }
            }
            else
            {
                matchMatrix[rowIndex][columnIndex] = false;
            }
        }
    }

    return matchMatrix[string.length][pattern.length];
}

/**
 * Generates key matrix from given keyString.
 * @param {string} keyString - a string to build a key matrix (must be of matrixSize^2 length).
 * @return {number[][]} keyMatrix
 */
const generateKeyMatrix = (keyString) = >
{
    const matrixSize = Math.sqrt(keyString.length);
    if(!Number.isInteger(matrixSize))
    {
    throw new Error('Invalid key string length. The square root of the key string must be an integer');
}
let keyStringIndex = 0;
return mtrx.generate(
    [matrixSize, matrixSize],
    () = > {
        const charCodeShifted = (keyString.codePointAt(keyStringIndex)) % alphabetCodeShift;
        keyStringIndex += 1;
        return charCodeShifted;
    },);
};

/**
 * Generates a message vector from a given message.
 * @param {string} message - the message to encrypt.
 * @return {number[][]} messageVector
 */
const generateMessageVector = (message) = >
{
    return mtrx.generate(
        [message.length, 1],
        (cellIndices) = > {
            const rowIndex = cellIndices[0];
            return message.codePointAt(rowIndex) % alphabetCodeShift;
        },);
};

/**
 * Encrypts the given message using Hill Cipher.
 * @param {string} message - The plaintext message to encrypt.
 * @param {string} keyString - The key to use for encryption.
 * @return {string} - The encrypted cipher string.
 */
export function hillCipherEncrypt(message, keyString) {
    const onlyLettersRegExp = / ^[a - zA - Z] + $ /;
    if (!onlyLettersRegExp.test(message) || !onlyLettersRegExp.test(keyString)) {
        throw new Error('The message and key string can only contain letters');
    }

    const keyMatrix = generateKeyMatrix(keyString);
    const messageVector = generateMessageVector(message);

    if (keyMatrix.length != = message.length)
    {
        throw new Error('Invalid key string length. The key length must be a square of message length');
    }

    const cipherVector = mtrx.dot(keyMatrix, messageVector);
    let cipherString = '';
    for (let row = 0; row < cipherVector.length; row += 1) {
        const item = cipherVector[row];
        cipherString += String.fromCharCode((item % englishAlphabetSize) + alphabetCodeShift);
    }

    return cipherString;
}

/**
 * Decrypts the given message using Hill Cipher.
 * @return {string} - The decrypted plaintext message.
 */
export const hillCipherDecrypt = () = >
{
    throw new Error('This method is not implemented yet');
};

const englishAlphabet = 'abcdefghijklmnopqrstuvwxyz'.split('');

/**
 * Generate a cipher map based on the alphabet and a given shift.
 * @param {string[]} alphabet - The array representing the alphabet.
 * @param {number} shift - The shift for encryption or decryption.
 * @return {Object} - The cipher map.
 */
const getCipherMap = (alphabet, shift) = >
{
    return alphabet.reduce((charsMap, currentChar, charIndex) = > {
        let encryptedCharIndex = (charIndex + shift) % alphabet.length;
        if(encryptedCharIndex < 0) {
            encryptedCharIndex += alphabet.length;
        }
        charsMap[currentChar] = alphabet[encryptedCharIndex];
        return charsMap;
    },
        {});
};
