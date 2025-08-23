enum AccountType{
    Guest,
    User,
    Moderator
}
[Flags]
enum Permission:byte
{
    Read = 0b00000001,
    Write = 0b00000010,
    Delete = 0b00000100,
    All = 0b00000111,
    None = 0b00000000
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
       if(accountType == AccountType.Guest){
           return Permission.Read;
       }
        else if(accountType == AccountType.User){
            return Permission.Read|Permission.Write;
        }
        else if(accountType == AccountType.Moderator){
            return Permission.Read|Permission.Write|Permission.Delete;
        }
        return Permission.None;
    }

    public static Permission Grant(Permission current, Permission grant) => current|grant;

    public static Permission Revoke(Permission current, Permission revoke) => current & ~revoke;

    public static bool Check(Permission current, Permission check) => (current & check) == check;
}
