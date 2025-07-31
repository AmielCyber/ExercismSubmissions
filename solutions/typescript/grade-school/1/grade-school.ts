export class GradeSchool {
  private _students = new Map<string, number>();
  private _roster: Record<number, string[]> = {};

  // O(MN), M -> properties in _roster, N -> largest array in _roster 
  roster(): Record<number, string[]> {
    const record: Record<number, string[]> = {};
    for (const key of Object.keys(this._roster)) {
      const grade = parseInt(key)
      record[grade] = this._roster[grade]?.slice(0);
    }
    return record;
  }

  // O(NLGN)
  add(name: string, grade: number): void {
    const oldGrade: number | undefined = this._students.get(name);
    if (oldGrade) {
      this._roster[oldGrade] = this._roster[oldGrade].filter(s => s !== name);
      if (this._roster[oldGrade].length === 0)
        delete this._roster[oldGrade];
    }
    this._students.set(name, grade);

    if (!(grade in this._roster)) {
      this._roster[grade] = [name];
    } else {
      this._roster[grade].push(name)
      this._roster[grade].sort();
    }
  }

  // O(N), N -> this._roster[grade].length
  grade(grade: number): string[] {
    return this._roster[grade] ? this._roster[grade].slice(0) : [];
  }
}
