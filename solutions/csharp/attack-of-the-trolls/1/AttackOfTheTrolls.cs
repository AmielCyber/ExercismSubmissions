using System;

enum AccountType
{
    Guest,
    User,
    Moderator,
}

[Flags]
enum Permission : byte
{
    None = 0,
    Read = 0b_001,
    Write = 0b_010,
    Delete = 0b_100,
    All = Read | Write | Delete,
}

static class Permissions
{
    public static Permission Default(AccountType accountType) =>
        accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,
            _ => Permission.None,
        };

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) =>
        current & (Permission.All ^ revoke);

    public static bool Check(Permission current, Permission check) => (current & check) == check;
}
