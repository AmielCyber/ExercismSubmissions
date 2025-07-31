export class Matrix {
  #matrix: number[][] = [];

  constructor(input: string) {
    const inputRows: string[] = input.split("\n");
    for (let i = 0; i < inputRows.length; i++) {
      const nums: string[] = inputRows[i].split(" ");
      const numbers: number[] = [];
      for (let num of nums)
        numbers.push(parseInt(num));
      this.#matrix.push(numbers);
    }
  }

  get rows(): number[][] {
    let matrixCopy: number[][] = [];
    for (let row of this.#matrix)
      matrixCopy.push([...row]);
    return matrixCopy;
  }

  get columns(): number[][] {
    let cols: number[][] = [];
    for (let i = 0; i < this.#matrix[0].length; i++)
      cols.push([]);

    for (let i = 0; i < this.#matrix.length; i++) {
      for (let j = 0; j < this.#matrix[i].length; j++) {
        cols[j].push(this.#matrix[i][j]);
      }
    }
    return cols;
  }
}
