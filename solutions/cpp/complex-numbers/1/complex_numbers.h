#pragma once

namespace complex_numbers {
class Complex {
public:
  Complex(double real_num, double imag_num);
  double real() const;
  double imag() const;
  Complex operator*(const Complex &rhs) const;
  Complex operator+(const Complex &rhs) const;
  Complex operator-(const Complex &rhs) const;
  Complex operator/(const Complex &rhs) const;
  double abs() const;
  Complex conj() const;
  Complex exp() const;
  Complex operator+(const double rhs) const;
  friend Complex operator+(double lhs, const Complex &rhs);
  Complex operator-(const double rhs) const;
  friend Complex operator-(double lhs, const Complex &rhs);
  Complex operator*(const double rhs) const;
  friend Complex operator*(double lhs, const Complex &rhs);
  Complex operator/(const double rhs) const;
  friend Complex operator/(double lhs, const Complex &rhs);

private:
  double _real{};
  double _imaginary{};
};
} // namespace complex_numbers
