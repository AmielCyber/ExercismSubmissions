export class Rational {
  numerator: number;
  denominator: number;

  constructor(numerator: number, denominator: number) {
    this.numerator = numerator;
    this.denominator = denominator;
  }

  add(rational: Rational): Rational {
    const numerator = this.numerator * rational.denominator + rational.numerator * this.denominator;
    const denominator = this.denominator * rational.denominator;
    return (new Rational(numerator, denominator)).reduce();
  }

  sub(rational: Rational): Rational {
    const numerator = this.numerator * rational.denominator - rational.numerator * this.denominator;
    const denominator = this.denominator * rational.denominator;
    return (new Rational(numerator, denominator)).reduce();
  }

  mul(rational: Rational): Rational {
    return (new Rational(this.numerator * rational.numerator, this.denominator * rational.denominator)).reduce();
  }

  div(rational: Rational): Rational {
    return (new Rational(this.numerator * rational.denominator, this.denominator * rational.numerator)).reduce();
  }

  abs(): Rational {
    return (new Rational(Math.abs(this.numerator), Math.abs(this.denominator))).reduce();
  }

  exprational(exponent: number): Rational {
    const absExponent = Math.abs(exponent);
    if(exponent < 0){
      return (new Rational(Math.pow(this.denominator, absExponent), Math.pow(this.numerator, absExponent))).reduce();
    }
    return (new Rational(Math.pow(this.numerator, absExponent), Math.pow(this.denominator, absExponent))).reduce();
  }

  expreal(exponent: number): number {
    return Math.pow(exponent, this.numerator/this.denominator);
  }

  reduce(): Rational {
    if(this.numerator === 0)
      return new Rational(0, 1);

    let numerator = this.numerator;
    let denominator = this.denominator;
    const gcd = Math.abs(this.getGCD(numerator, denominator));
    if (gcd > 1) {
      numerator = numerator / gcd;
      denominator = denominator / gcd;
    }
    if ((denominator < 0)) {
      numerator *= -1;
      denominator *= -1;
    }
    return new Rational(numerator, denominator);
  }

  private getGCD(numerator: number, denominator: number): number {
    let max = Math.max(numerator, denominator);
    let min = Math.min(numerator, denominator);

    let gcd = max % min;
    while (gcd !== 0) {
      max = min;
      min = gcd;
      gcd = max % min;
    }
    return min;
  }
}
