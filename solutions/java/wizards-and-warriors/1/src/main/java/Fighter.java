class Fighter {
    boolean isVulnerable() {
        return true;
    }

    int getDamagePoints(Fighter fighter) {
        return 1;
    }

}

class Warrior extends Fighter {
    private static final int defaultDamage = 6;
    private static final int criticalDamage = 10;

    @Override
    boolean isVulnerable() {
        return false;
    }

    @Override
    int getDamagePoints(Fighter fighter) {
        return fighter.isVulnerable() ? criticalDamage : defaultDamage;
    }

    @Override
    public String toString() {
        return "Fighter is a Warrior";
    }
}

class Wizard extends Fighter {
    private static final int defaultDamage = 3;
    private static final int criticalDamage = 12;
    private boolean hasSpell = false;

    void prepareSpell() {
        hasSpell = true;
    }

    @Override
    boolean isVulnerable() {
        return !hasSpell;
    }

    @Override
    int getDamagePoints(Fighter fighter) {
        return hasSpell ? criticalDamage : defaultDamage;
    }

    @Override
    public String toString() {
        return "Fighter is a Wizard";
    }

}
