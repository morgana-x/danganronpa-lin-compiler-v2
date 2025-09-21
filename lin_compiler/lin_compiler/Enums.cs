using LIN;
using System;

namespace dr_lin
{
    public class Enums
    {
        public enum DR1_CHAR
        {
            CHAR_MAKOTO = 0,
            CHAR_KIYOTAKA = 1,
            CHAR_BYAKUYA = 2,
            CHAR_MONDO = 3,
            CHAR_LEON = 4,
            CHAR_HIFUMI = 5,
            CHAR_YASUHIRO = 6,
            CHAR_MAIZONO = 7,
            CHAR_KIRIGIRI = 8,
            CHAR_ASAHINA = 9,
            CHAR_TOUKO = 10,
            CHAR_OGAMI = 11,
            CHAR_CELES = 12,
            CHAR_JUNKOMUKURO = 13,
            CHAR_CHIHIRO = 14,
            CHAR_MONOKUMA = 15,
            CHAR_JUNKOENOSHIMA = 16,
            CHAR_ALTEREGO = 17,
            CHAR_GENOCIDERSHOU = 18,
            CHAR_HEADMASTER = 19,
            CHAR_MAKOTO_MOM = 20,
            CHAR_MAKOTO_DAD = 21,
            CHAR_MAKOTO_SISTER = 22,
            CHAR_KIYOTAKAMONDO = 23,
            CHAR_DAIYA = 24,
            CHAR_NARRATOR = 26,
            CHAR_USAMI = 27,
            CHAR_UNKNOWN = 30,
            CHAR_SYSTEM = 31,
        }

        public enum DR2_CHAR
        {
            CHAR_HAJIME = 0,
            CHAR_KOMAEDA = 1,
            CHAR_BYAKUYA = 2,
            CHAR_GUNDAM = 3,
            CHAR_KAZUICHI = 4,
            CHAR_TERUTERU = 5,
            CHAR_NEKOMARU = 6,
            CHAR_FUYUHIKU = 7,
            CHAR_AKANE = 8,
            CHAR_CHIAKI = 9,
            CHAR_SONIA = 10,
            CHAR_HIYIKO = 11,
            CHAR_MAHIRU = 12,
            CHAR_MIKAN = 13,
            CHAR_IBUKI = 14,
            CHAR_PEKO = 15,
            CHAR_MONOKUMA = 16,
            CHAR_MONOMI = 17,
            CHAR_JUNKO = 18,
            CHAR_MECHAMARU = 19,
            CHAR_MAKOTO = 20,
            CHAR_KYOKO = 21,
            CHAR_BYAKUYA_REAL = 22,
            CHAR_TERUTERU_MOM = 23,
            CHAR_ALTEREGO = 24,
            CHAR_MINIMARU = 25,
            CHAR_MONOKUMA_AND_MONOMI = 26,

            CHAR_UNKNOWN = 30,
            CHAR_SYSTEM = 31,

            CHAR_USAMI = 39,
            CHAR_SPARKLING_JUSTICE = 40,

            CHAR_JUNKOBIG = 48,

            CHAR_GIRL_A = 50,
            CHAR_GIRL_B = 51,
            CHAR_GIRL_C = 52,
            CHAR_GIRL_D = 53,
            CHAR_GIRL_E = 54,
            CHAR_GUY_F = 55,
            
            CHAR_UNKNOWN_2 = 56
        }

        public static Type GetCharEnum(Game game)
        {
            if (game == Game.Danganronpa2)
                return typeof(DR2_CHAR);
            
            return typeof(DR1_CHAR);
        }


        public enum DR_UI
        {
            UI_TEXTBOX = 1,
            UI_HELP = 2,
            UI_HUD = 3,
            UI_MINIMAP = 5,
            UI_BLACKBACKGROUND = 6,
            UI_TEXTBOXONLY = 7,
            UI_CLASSTRIAL = 8,
            UI_ENABLEBUSTUP = 9,
            UI_MOVIEBACKGROUND = 11,
            UI_SAVEPROMPT = 12,
            UI_RUMBLE = 13,
            UI_CAMERAPAN = 14,
            UI_CAMERALOOK = 15,
            UI_INVESTIGATEMODE = 16,
            UI_CHOICEMENU = 18,
            UI_BLEEPTEXT = 23,
            UI_CAMERAZOOM = 25,
            UI_LOOKATCHAR = 26,
            UI_LOOKATSUBAREA = 27,
            UI_PANICTALKACTION = 33,
            UI_CHOOSEPERSON = 37,
            UI_MONOMONOMACHINE = 41,
            UI_VENDINGMACHINE = 44,
            UI_ISLANDMODE = 50,
            UI_MINIMAL = 51,
            UI_LOGICDIVE = 71,
            UI_SPLITSCREEN = 72,
        }

        public enum DR_FLAG
        {
            FLAG_HANDBOOK = 0,
            FLAG_MAP_UNLOCK = 1,
            FLAG_CHAR_SPEAK = 15,
            FLAG_CHAR_DEAD = 17
        }

        public enum DR_FLAG_HANDBOOK
        {
            HANDBOOK_ENABLED = 4,
            HANDBOOK_MAP_ENABLED = 5,
            HANDBOOK_TRUTHBULLET_ENABLED = 6,
            HANDBOOK_SAVE_ENABLED = 7,
            HANDBOOK_TRUTHBULLET_KNOWN = 19

        }

        public enum DR_TIME
        {
            TIME_DAY = 0,
            TIME_NIGHT = 1,
            TIME_MORNING = 2,
            TIME_MIDNIGHT = 3,
            TIME_UNKNOWN = 4,
            TIME_UNKNOWN2 = 255
        }

        public enum DR_CAM_DIR
        {
            CAM_FARLEFT,
            CAM_LEFT,
            CAM_CENTER,
            CAM_RIGHT,
            CAM_FARRIGHT
        }

        public enum DR_SPRITE_STATE
        {
            SPRITE_INVISIBLE,
            SPRITE_SHOW,
            SPRITE_SHOW_DELAY,
            SPRITE_INVISIBLE2,
            SPRITE_HIDE
        }

        public enum DR_FADE
        {
            FADE_IN,
            FADE_OUT
        }

        public enum DR_CHAPTER
        {
            CHAPTER_PROLOGUE,
            CHAPTER_1,
            CHAPTER_2,
            CHAPTER_3,
            CHAPTER_4,
            CHAPTER_5,
            CHAPTER_6,
            CHAPTER_GENERIC
        }



    }
}
