#include <iostream>
#include <ostream>
// interest_rate returns the interest rate for the provided balance.
double interest_rate(const double balance) {
    if (balance < 0) {
        return 3.213;
    }if (balance < 1'000) {
        return 0.5;
    }if (balance < 5'000) {
        return 1.621;
    }
    return 2.475;
}

// yearly_interest calculates the yearly interest for the provided balance.
double yearly_interest(const double balance) {
    return balance * (interest_rate(balance)/100.0);
}

// annual_balance_update calculates the annual balance update, taking into
// account the interest rate.
double annual_balance_update(const double balance) {
    return balance + yearly_interest(balance);
}

// years_until_desired_balance calculates the minimum number of years required
// to reach the desired balance.
int years_until_desired_balance(const double balance, const double target_balance) {
    if (std::signbit(balance) != std::signbit(target_balance)) {
        throw std::invalid_argument("Balance will never reach target balance");
    }
    double accumulated_balance = balance;
    int years = 0;
    while (accumulated_balance < target_balance) {
        accumulated_balance = annual_balance_update(accumulated_balance);
        ++years;
    }
    return years;
}