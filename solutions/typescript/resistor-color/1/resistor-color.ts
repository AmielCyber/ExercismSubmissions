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

export const COLORS: string[] = [...colorSet.keys()];

export const colorCode = (color: string) => colorSet.has(color) ? colorSet.get(color) : 0;



