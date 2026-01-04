#include "complex_numbers.h"
#include <cmath>

namespace complex_numbers {
Complex::Complex(double real_num, double imag_num)
    : _real(real_num), _imaginary(imag_num) {}

double Complex::real() const { return _real; }

double Complex::imag() const { return _imaginary; }

Complex Complex::operator*(const Complex &rhs) const {
  double real_num = real() * rhs.real() - imag() * rhs.imag();
  double imag_num = imag() * rhs.real() + real() * rhs.imag();

  return Complex{real_num, imag_num};
}

Complex Complex::operator+(const Complex &rhs) const {
  return Complex{real() + rhs.real(), imag() + rhs.imag()};
}

Complex Complex::operator-(const Complex &rhs) const {
  return Complex{real() - rhs.real(), imag() - rhs.imag()};
}

Complex Complex::operator/(const Complex &rhs) const {
  double rhs_square_add = rhs.real() * rhs.real() + rhs.imag() * rhs.imag();
  double real_num =
      (real() * rhs.real() + imag() * rhs.imag()) / (rhs_square_add);
  double imag_num =
      (imag() * rhs.real() - real() * rhs.imag()) / (rhs_square_add);

  return Complex{real_num, imag_num};
}

double Complex::abs() const {
  return std::sqrt(real() * real() + imag() * imag());
}
Complex Complex::conj() const { return Complex{real(), imag() * -1}; }

Complex Complex::exp() const {
  double e = std::exp(real());
  double real_num = e * std::cos(imag());
  double imag_num = e * std::sin(imag());

  return Complex{real_num, imag_num};
}

Complex Complex::operator+(const double rhs) const {
  return operator+(Complex(rhs, 0));
}

Complex operator+(double lhs, const Complex &rhs) { return rhs + lhs; }

Complex Complex::operator-(const double rhs) const {
  return operator-(Complex(rhs, 0));
}

Complex operator-(double lhs, const Complex &rhs) {
  return Complex{lhs, 0} - rhs;
}

Complex Complex::operator*(const double rhs) const {
  return operator*(Complex{rhs, 0});
}

Complex operator*(double lhs, const Complex &rhs) { return rhs * lhs; }

Complex Complex::operator/(const double rhs) const {
  return operator/(Complex{rhs, 0});
}

Complex operator/(double lhs, const Complex &rhs) {
  return Complex{lhs, 0} / rhs;
}

} // namespace complex_numbers
