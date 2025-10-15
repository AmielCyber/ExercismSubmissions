#include "lasagna_master.h"
#include <string>
using std::string;
#include <vector>
using std::vector;

namespace lasagna_master {

// TODO: add your solution here
int preparationTime(vector<string> &layers, int time) {
  return layers.size() * time;
}

amount quantities(const vector<string> &layers) {
  amount layers_struct{0, 0};
  for (const string &layer : layers) {
    if (layer == "noodles") {
      layers_struct.noodles += 50;
    } else if (layer == "sauce") {
      layers_struct.sauce += 0.2;
    }
  }
  return layers_struct;
}

void addSecretIngredient(vector<string> &myList,
                         const vector<string> &friendList) {
  myList[myList.size() - 1] = friendList[friendList.size() - 1];
}

void addSecretIngredient(vector<std::string> &myList, string ingredient) {
  myList[myList.size() - 1] = ingredient;
}

vector<double> scaleRecipe(const vector<double> &portions, int scale) {

  vector<double> newScaleRecipe(portions.size());
  double portionScale = static_cast<double>(scale) / 2.0;
  for (int i = 0; i < static_cast<int>(portions.size()); i++) {
    newScaleRecipe[i] = portions[i] * portionScale;
  }
  return newScaleRecipe;
}

} // namespace lasagna_master
