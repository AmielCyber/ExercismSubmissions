const dnaToRnaComplement = new Map<string, string>([
  ["G", "C"],
  ["C", "G"],
  ["T", "A"],
  ["A", "U"],
]);

export function toRna(dnaSequence: string): string {
  const rnaSequence: string[] = [];

  for (const neucleotide of dnaSequence) {
    if (dnaToRnaComplement.has(neucleotide)) {
      rnaSequence.push(dnaToRnaComplement.get(neucleotide)!);
    } else {
      throw Error("Invalid input DNA.")
    }
  }
  return rnaSequence.join("");
}
