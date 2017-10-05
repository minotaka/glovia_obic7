using System;

namespace glovia_obic7.Resources
{
    [Flags]
    public enum ConvertMode
    {
        NONE = 0,
        ZAIMU = 1,
        SAIMU = 2,
        TEGATA = 4,
        TORIHIKI = 8
    }

    public enum InputSystem
    {
        CMS,
        USE,
        KEI,
        NYUU,
        SIIRE,
        TOKUI,
        ZAI,
        URI
    }

    public enum RecordMode
    {
        NEW,
        APPEND
    }
}
