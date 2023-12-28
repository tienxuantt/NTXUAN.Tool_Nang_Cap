namespace QLTS.Tool_Khao_Sat.BL
{
    public class Script
    {
        public static string ScriptDeleteUser = "DELETE a\r\nFROM sc_user_role a\r\nINNER JOIN user b ON a.user_id = b.user_id\r\nWHERE b.user_name = 'misaqlts';\r\n\r\nDELETE FROM user WHERE user_name = 'misaqlts';\r\nDELETE FROM activity_diary WHERE user_name LIKE '%misaqlts%';";
        public static string ScriptDeleteUser_Authen = "DELETE FROM user WHERE user_name = 'misaqlts';";
    }
}
