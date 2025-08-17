#include <string>
using std::string;

namespace log_line {
string message(std::string line) {
  int msg_start = line.find(':') + 2;
  return line.substr(msg_start);
}

string log_level(std::string line) {
  int log_level_start = line.find('[') + 1;
  int log_level_end = line.find(']');
  return line.substr(log_level_start, log_level_end - log_level_start);
}

string reformat(std::string line) {
  return message(line) + " (" + log_level(line) + ")";
}
} // namespace log_line
