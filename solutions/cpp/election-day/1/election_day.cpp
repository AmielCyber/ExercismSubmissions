#include <string>
#include <vector>

namespace election {

struct ElectionResult {
  std::string name{};
  int votes{};
};

int vote_count(ElectionResult &election) { return election.votes; }

void increment_vote_count(ElectionResult &election, int number_of_votes) {
  election.votes += number_of_votes;
}

ElectionResult &determine_result(std::vector<ElectionResult> &final_count) {
  int president_index = 0;
  for (int i = 1; i < final_count.size(); i++) {
    if (final_count[i].votes > final_count[president_index].votes) {
      president_index = i;
    }
  }
  final_count[president_index].name =
      "President " + final_count[president_index].name;
  return final_count[president_index];
}

} // namespace election
