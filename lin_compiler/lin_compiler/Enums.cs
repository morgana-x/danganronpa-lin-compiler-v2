using LIN;
using System;

namespace dr_lin
{
    public class Enums
    {
        public enum DR1_CHAR
        {
            CHR_MAKOTO = 0,
            CHR_KIYOTAKA = 1,
            CHR_BYAKUYA = 2,
            CHR_MONDO = 3,
            CHR_LEON = 4,
            CHR_HIFUMI = 5,
            CHR_YASUHIRO = 6,
            CHR_MAIZONO = 7,
            CHR_KIRIGIRI = 8,
            CHR_ASAHINA = 9,
            CHR_TOUKO = 10,
            CHR_OGAMI = 11,
            CHR_CELES = 12,
            CHR_JUNKO_MUKURO = 13,
            CHR_CHIHIRO = 14,
            CHR_MONOKUMA = 15,
            CHR_JUNKO_ENOSHIMA = 16,
            CHR_ALTEREGO = 17,
            CHR_GENOCIDER = 18,
            CHR_HEADMASTER = 19,
            CHR_MAKOTO_MOM = 20,
            CHR_MAKOTO_DAD = 21,
            CHR_MAKOTO_SISTER = 22,
            CHR_KIYOTAKA_MONDO = 23,
            CHR_DAIYA = 24,
            CHR_NARRATOR = 26,
            CHR_USAMI = 27,
            CHR_UNKNOWN = 30,
            CHR_SYSTEM = 31,
        }

        public enum DR2_CHAR
        {
            CHR_HAJIME = 0,
            CHR_KOMAEDA = 1,
            CHR_BYAKUYA = 2,
            CHR_GUNDAM = 3,
            CHR_KAZUICHI = 4,
            CHR_TERUTERU = 5,
            CHR_NEKOMARU = 6,
            CHR_FUYUHIKU = 7,
            CHR_AKANE = 8,
            CHR_CHIAKI = 9,
            CHR_SONIA = 10,
            CHR_HIYIKO = 11,
            CHR_MAHIRU = 12,
            CHR_MIKAN = 13,
            CHR_IBUKI = 14,
            CHR_PEKO = 15,
            CHR_MONOKUMA = 16,
            CHR_MONOMI = 17,
            CHR_JUNKO = 18,
            CHR_MECHAMARU = 19,
            CHR_MAKOTO = 20,
            CHR_KYOKO = 21,
            CHR_BYAKUYA_REAL = 22,
            CHR_TERUTERU_MOM = 23,
            CHR_ALTEREGO = 24,
            CHR_MINIMARU = 25,
            CHR_MONOKUMA_AND_MONOMI = 26,

            CHR_UNKNOWN = 30,
            CHR_SYSTEM = 31,

            CHR_USAMI = 39,
            CHR_SPARKLING_JUSTICE = 40,

            CHR_JUNKO_BIG = 48,

            CHR_GIRL_A = 50,
            CHR_GIRL_B = 51,
            CHR_GIRL_C = 52,
            CHR_GIRL_D = 53,
            CHR_GIRL_E = 54,
            CHR_GUY_F = 55,
            
            CHR_UNKNOWN_2 = 56
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
            UI_NAME = 2,
            UI_HUD = 3,
            UI_MINIMAP = 5,
            UI_BG_BLACK = 6,
            UI_TEXTBOX_ONLY = 7,
            UI_CLASSTRIAL = 8,
            UI_BUSTUP = 9,
            UI_BG_MOVIE = 11,
            UI_SAVE = 12,
            UI_RUMBLE = 13,
            UI_CAM_PAN = 14,
            UI_CAM_LOOK = 15,
            UI_INVESTIGATE = 16,
            UI_CHOICE = 18,
            UI_CHOOSE_PRESENT = 19,
            UI_BLEEPTEXT = 23,
            UI_CAM_ZOOM = 25,
            UI_CAM_CHAR = 26,
            UI_CAM_SUBAREA = 27,
            UI_PANICTALKACTION = 33,
            UI_CHOOSE_EVIDENCE = 35,
            UI_CHOOSE_PERSON = 37,
            UI_MONOMONOMACHINE = 41,
            UI_VENDINGMACHINE = 44,
            UI_ISLANDMODE = 50,
            UI_MINIMAL = 51,
            UI_LOGICDIVE = 71,
            UI_SPLITSCREEN = 72,
        }

        public enum DR_FLAG
        {
            FLAG_SYSTEM = 0,
            FLAG_MAP_UNLOCK = 1,
            FLAG_CHR_SPEAK = 15,
            FLAG_CHR_DEAD = 17
        }

        public enum DR_FLAG_SYSTEM
        {
            HANDBOOK_ENABLED = 4,
            HANDBOOK_MAP_ENABLED = 5,
            HANDBOOK_TRUTHBULLET_ENABLED = 6,
            HANDBOOK_SAVE_ENABLED = 7,
            HANDBOOK_TRUTHBULLET_KNOWN = 19,
            ROOM_EXIT_ENABLED = 12
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

        public enum DR_FILTER
        {
            FILTER_NONE,
            FILTER_SEPIA
        }


        public enum DR_SPRITE_STATE
        {
            SPRITE_3D,
            SPRITE_SHOW,
            SPRITE_SHOW_DELAY,
            SPRITE_HIDE_2,
            SPRITE_HIDE
        }

        public enum DR_FADE
        {
            FADE_IN,
            FADE_OUT
        }

        public enum DR_COLOUR
        {
            COL_BLACK_SPECIAL,
            COL_BLACK,
            COL_WHITE,
            COL_RED
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
            CHAPTER_99 = 99
        }



    }
}
