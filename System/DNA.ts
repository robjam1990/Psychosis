// File = robjam1990/Psychosis/Gameplay/System/DNA.ts
import * as fs from 'fs';

/**
 * Translates a DNA sequence into its complementary strand.
 * @param dna The DNA strand to be translated
 * @returns The complementary DNA strand
 * @throws {Error} If the input contains invalid characters
 */
function dna(dna: string): string {
    // Validate input DNA sequence
    validateDNASequence(dna);

    // Replace each nucleotide with its complement
    return dna.replace(/[ATCG]/gi, function (match) {
        return {
            A: 'T',
            T: 'A',
            C: 'G',
            G: 'C'
        }[match.toUpperCase()];
    });
}

/**
 * Validates a DNA sequence to ensure it contains only valid characters (A, T, C, G).
 * @param dna The DNA sequence to validate
 * @throws {Error} If the input sequence contains invalid characters
 */
function validateDNASequence(dna: string): void {
    if (!/^[ATCG]+$/i.test(dna)) {
        throw new Error("Invalid DNA sequence. DNA sequence must contain only characters A, T, C, or G.");
    }
}

// Define the DNA program
const DNA = () => {
    // Define the source code
    const Source = `
<({["'DNA'"]})>
`;

    // Define the additional layers
    const Layers = `<({["',R:N.A;'"]})>`;

    // Concatenate the source code with the additional layers
    const Code = Source + Layers;

    // Execute the code
    eval(Code);
};

// Define the C program
const C_program = `
#include <stdio.h>

int main()
{
    FILE *fp;
    char c;
    fp = fopen(__FILE__, "r");
    do
    {
        c = getc(fp);
        putchar(c);
    } while (c != EOF);
    fclose(fp);
    return 0;
}
`;

// Execute both DNA and C programs
DNA(); // Execute DNA program
console.log(dna(C_program)); // Execute C program
