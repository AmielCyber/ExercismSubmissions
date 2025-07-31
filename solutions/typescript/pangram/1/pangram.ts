const offset: string = 'a';
export function isPangram(sentence: string): boolean {
  const letterCount = new Array<number>(26).fill(0);
  sentence = sentence.toLowerCase();

  for (let i = 0; i < sentence.length; i++) {
    const letter = sentence.charAt(i);
    if (letter >= 'a' && letter <= 'z') {
      let index = letter.codePointAt(0)! - offset.codePointAt(0)!;
      letterCount[index]++;
    }
  }
  return letterCount.every(count => count > 0);
}
