#include "allergies.h"
#include <unordered_set>

namespace allergies {
allergy_test::allergy_test(unsigned int allergy_score) : allergies() {
  set_allergies(allergy_score);
};

bool allergy_test::is_allergic_to(std::string item) {
  return allergies.find(item) != allergies.end();
}

std::unordered_set<std::string> allergy_test::get_allergies() {
  return allergies;
}

void allergy_test::set_allergies(int allergy_score) {
  if (allergy_score & static_cast<int>(Items::Eggs)) {
    allergies.emplace("eggs");
  }
  if (allergy_score & static_cast<int>(Items::Peanuts)) {
    allergies.emplace("peanuts");
  }
  if (allergy_score & static_cast<int>(Items::Shellfish)) {
    allergies.emplace("shellfish");
  }
  if (allergy_score & static_cast<int>(Items::Shellfish)) {
    allergies.emplace("shellfish");
  }
  if (allergy_score & static_cast<int>(Items::Strawberries)) {
    allergies.emplace("strawberries");
  }
  if (allergy_score & static_cast<int>(Items::Tomatoes)) {
    allergies.emplace("tomatoes");
  }
  if (allergy_score & static_cast<int>(Items::Chocolate)) {
    allergies.emplace("chocolate");
  }
  if (allergy_score & static_cast<int>(Items::Pollen)) {
    allergies.emplace("pollen");
  }
  if (allergy_score & static_cast<int>(Items::Cats)) {
    allergies.emplace("cats");
  }
}

} // namespace allergies
