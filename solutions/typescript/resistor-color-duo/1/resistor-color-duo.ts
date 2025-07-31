const colorSet = new Map<string, number>([
  ["black", 0],
  ["brown", 1],
  ["red", 2],
  ["orange", 3],
  ["yellow", 4],
  ["green", 5],
  ["blue", 6],
  ["violet", 7],
  ["grey", 8],
  ["white", 9],
]);
export function decodedValue(colors: string[]): number {
  let value: number = 0;
  if (colors.length < 1)
    throw new Error("Array must not be empty");

  for (let i = 0; i < colors.length && i < 2; i++) {
    let val = 0;
    if (colorSet.has(colors[i])) {
      val += colorSet.get(colors[i])!;
      if (i == 1)
        value *= 10;
      value += val;
    }
  }

  return value;
}
