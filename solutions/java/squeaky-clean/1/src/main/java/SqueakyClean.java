class SqueakyClean {
    static String clean(String identifier) {
        boolean camelWord = false;
        var strBld = new StringBuilder();

        for (int i = 0; i < identifier.length(); i++) {
            char ch = identifier.charAt(i);
            if (ch == ' ') {
                strBld.append('_');
            } else if (isLeetSpeakChar(ch)) {
                strBld.append(getLeetSpeakChar(ch));
            } else if (ch == '-') {
                camelWord = true;
            } else if (Character.isAlphabetic(ch)) {
                if (camelWord) {
                    ch = Character.toUpperCase(ch);
                    camelWord = false;
                }
                strBld.append(ch);
            }
        }
        return strBld.toString();
    }

    private static boolean isLeetSpeakChar(char ch) {
        return ch == '0' || ch == '1' || ch == '3' || ch == '4' || ch == '7';
    }

    private static char getLeetSpeakChar(char ch) {
        return switch (ch) {
            case '0' -> 'o';
            case '1' -> 'l';
            case '3' -> 'e';
            case '4' -> 'a';
            case '7' -> 't';
            default -> ' ';
        };
    }
}
