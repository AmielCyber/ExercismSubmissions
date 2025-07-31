const alph = [..."abcdefghijklmnopqrstuvwxyz"];
const offset = 'a'.toLowerCase().charCodeAt(0);

export function encode(plainText: string): string {
  return [...plainText]
    .filter(char => isLetter(char) || !isNaN(parseInt(char)))
    .map((letter: string, index: number) => {
      if (index % 5 === 0 && index > 0)
        return " " + encodeCharacter(letter);
      return encodeCharacter(letter);
    })
    .join("");
}

export function decode(cipherText: string): string {
  return [...cipherText]
    .map(char => char !== " " ? encodeCharacter(char) : "")
    .join("");
}

function isLetter(letter: string): boolean {
  return (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z');
}

function encodeCharacter(char: string): string {
  if (!isNaN(parseInt(char)))
    return char;
  return encodeLetter(char);
}

function encodeLetter(letter: string): string {
  const letterIndex = letter.toLowerCase().charCodeAt(0) - offset;
  if (letterIndex < 0 || letterIndex >= alph.length)
    throw new Error(`Character '${letter}' is not a letter.`);

  return alph[alph.length - 1 - letterIndex];
}
