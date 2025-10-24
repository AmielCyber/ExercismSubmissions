#include "say.h"
#include <stdexcept>
#include <string>

namespace say {
std::string in_english(long num) {
  if (num == 0) {
    return "zero";
  }
  if (num < 0) {
    throw std::domain_error("Min num is 0");
  }
  if (num < 100) {
    return tens_in_english(num);
  }
  if (num < 1'000) {
    return hundreds_in_english(num);
  }
  if (num < 1'000'000) {
    return thousands_in_english(num);
  }
  if (num < 1'000'000'000) {
    return millions_in_english(num);
  }
  if (num < 1'000'000'000'000) {
    return billions_in_english(num);
  }
  throw std::domain_error("Max num is 999,999,999,999");
}
std::string ones_in_english(long num) {
  switch (num) {
  case 1:
    return "one";
  case 2:
    return "two";
  case 3:
    return "three";
  case 4:
    return "four";
  case 5:
    return "five";
  case 6:
    return "six";
  case 7:
    return "seven";
  case 8:
    return "eight";
  case 9:
    return "nine";
  default:
    return "";
  }
}
std::string teens_in_english(long num) {
  switch (num) {
  case 10:
    return "ten";
  case 11:
    return "eleven";
  case 12:
    return "twelve";
  case 13:
    return "thirteen";
  case 14:
    return "fourteen";
  case 15:
    return "fifteen";
  case 16:
    return "sixteen";
  case 17:
    return "seventeen";
  case 18:
    return "eighteen";
  case 19:
    return "nineteen";
  default:
    return "";
  }
}
std::string tens_in_english(long num) {
  std::string num_str{""};
  if (num < 10) {
    num_str += ones_in_english(num);
    return num_str;
  } else if (num < 20) {
    num_str += teens_in_english(num);
    return num_str;
  } else {
    if (num < 30) {
      num_str += "twenty";
    } else if (num < 40) {
      num_str += "thirty";
    } else if (num < 50) {
      num_str += "forty";
    } else if (num < 60) {
      num_str += "fifty";
    } else if (num < 70) {
      num_str += "sixty";
    } else if (num < 80) {
      num_str += "seventy";
    } else if (num < 90) {
      num_str += "eighty";
    } else if (num < 100) {
      num_str += "ninety";
    }
    int ones = num % 10;
    if (ones > 0) {
      num_str += "-" + ones_in_english(ones);
    }
  }
  return num_str;
}
std::string hundreds_in_english(long num) {
  std::string num_str{""};
  long hundreds = num / 100;
  long tens = num % 100;

  if (hundreds > 0) {
    num_str += ones_in_english(hundreds) + " hundred";
    if (tens > 0) {
      num_str += " " + tens_in_english(tens);
    }
  } else {
    num_str += tens_in_english(tens);
  }
  return num_str;
}
std::string thousands_in_english(long num) {
  std::string num_str{""};
  num_str += hundreds_in_english(num / 1000) + " thousand";
  long hundreds = num % 1000;
  if (hundreds > 0) {
    num_str += " " + hundreds_in_english(num % 1000);
  }
  return num_str;
}
std::string millions_in_english(long num) {
  std::string num_str{""};
  num_str += hundreds_in_english(num / 1'000'000) + " million";
  long thousands = num % 1'000'000;
  if (thousands > 0) {
    num_str += " " + thousands_in_english(thousands);
  }
  return num_str;
}
std::string billions_in_english(long num) {
  std::string num_str{""};
  num_str += hundreds_in_english(num / 1'000'000'000) + " billion";
  long millions = num % 1'000'000'000;
  if (millions > 0) {
    num_str += " " + millions_in_english(millions);
  }
  return num_str;
}

} // namespace say
