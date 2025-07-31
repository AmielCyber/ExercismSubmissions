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

export function decodedResistorValue(colors: string[]): string {
  const colorDuo = decodedValue(colors);
  return getMetricPrefix(colorDuo, colors);
}

function decodedValue(colors: string[]): number {
  let val = 0;
  if (colors.length < 1)
    throw new Error("Array must not be empty");

  if (colorSet.has(colors[0]))
    val += colorSet.get(colors[0])!;

  if (colors.length > 1 && colorSet.has(colors[1])) {
    val *= 10;
    val += colorSet.get(colors[1])!;
  }
  return val;
}

function getMetricPrefix(num: number, colors: string[]): string {
  const giga = 1_000_000_000;
  const mega = 1_000_000;
  const kilo = 1_000;
  const exponent = colorSet.get(colors[2]) ?? 0;
  for (let i = exponent; i > 0; i--)
    num *= 10;

  if(num >= giga)
    return `${getBaseNumber(num, giga)} gigaohms`;
  if (num >= mega)
    return `${getBaseNumber(num, mega)} megaohms`;
  if(num >= kilo){
    return `${getBaseNumber(num, kilo)} kiloohms`;
  }
  return `${num} ohms`;
}

function getBaseNumber(num: number, baseNum: number): number {
  while(num % baseNum === 0)
    num /= baseNum;
  return num;
}

