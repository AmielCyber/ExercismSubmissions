#include "vehicle_purchase.h"

namespace vehicle_purchase {

// needs_license determines whether a license is needed to drive a type of
// vehicle. Only "car" and "truck" require a license.
bool needs_license(std::string kind) {
  return kind == "car" || kind == "truck";
}

// choose_vehicle recommends a vehicle for selection. It always recommends the
// vehicle that comes first in lexicographical order.
std::string choose_vehicle(std::string option1, std::string option2) {
  std::string msg{" is clearly the better choice."};
  if (option1 < option2) {
    msg = option1 + msg;
  } else {
    msg = option2 + msg;
  }
  return msg;
}

// calculate_resell_price calculates how much a vehicle can resell for at a
// certain age.
double calculate_resell_price(double original_price, double age) {
  double resell_price = original_price;
  if (age < 3) {
    resell_price *= 0.80;
  } else if (age < 10) {
    resell_price *= 0.70;
  } else {
    resell_price *= 0.50;
  }
  return resell_price;
}

} // namespace vehicle_purchase
