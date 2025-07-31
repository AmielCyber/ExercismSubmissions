export function find(haystack: number[], needle: number): number {
  let low = 0;
  let high = haystack.length - 1;
  while (low <= high) {
    const mid = low + Math.floor((high - low) / 2);
    if (needle === haystack[mid])
      return mid;
    else if (needle < haystack[mid])
      high = mid - 1;
    else
      low = mid + 1;
  }
  throw new Error('Value not in array');
}
