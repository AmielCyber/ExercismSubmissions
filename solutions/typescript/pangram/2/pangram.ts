const lowerCaseOffset: number = 'a'.codePointAt(0)!;
const upperCaseOffset: number = 'A'.codePointAt(0)!;

export function isPangram(sentence: string): boolean {
  const letterCount = new Array<boolean>(26).fill(false);
  for (let letter of sentence) {
    if (letter >= 'a' || letter <= 'z')
      letterCount[letter.codePointAt(0)! - lowerCaseOffset] = true;
    if (letter >= 'A' || letter <= 'Z')
      letterCount[letter.codePointAt(0)! - upperCaseOffset] = true;
  }
  return letterCount.every(l => l);
}

