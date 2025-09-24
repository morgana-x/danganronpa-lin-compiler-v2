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

        public enum DR1_BGM
        {
            BGM_OPENING = 0,
            BGM_MENU_START = 1,
            BGM_RESET = 255
        }

        public enum DR2_BGM
        {
            BGM_OPENING = 0,
            BGM_MENU_START = 1,
            BGM_BEAUTIFUL_RUIN = 2,
            BGM_BEAUTIFUL_RUIN_SUMMER_SALT = 3,
            BGM_IKOROSHIA = 4,
            BGM_EKOROSHIA = 5,
            BGM_RE_BEAUTIFUL_MORNING = 6,
            BGM_BEAUTIFUL_DAYS_PIANO = 7,
            BGM_TROPICAL_DESPAIR = 8,
            BGM_RESET = 255
        }

        public enum DR1_SKILL
        {
            SKILL_INFLUENCE_ATTENTIVE = 0,
            SKILL_INFLUENCE_ENVIOUS = 1,
            SKILL_FOCUS_EXTRAORDINARY = 2,
            SKILL_FOCUS_MENACING = 3,
            SKILL_LOST_IN_THOUGHT = 4,
            SKILL_CHARISMA = 5,
            SKILL_COOL_COMPOSED = 6,
            SKILL_TRANQUILITY = 7,
            SKILL_DOWNSHIFT = 8,
            SKILL_UPSHIFT = 9,
            SKILL_ROBOT_JOCK = 10,
            SKILL_TRIGGER_HAPPY = 11,
            SKILL_CRYSTAL_PREDICTION = 12,
            SKILL_CHEAT_CODE = 13,
            SKILL_ALGORITHM = 14,
            SKILL_KINETIC_DEPTH = 15,
            SKILL_STEEL_PATIENCE = 16,
            SKILL_NEURAL_LIBERATION = 17,
            SKILL_DELUSION = 18,
            SKILL_BREATHING = 19,
            SKILL_MELODIOUS_VOICE = 20,
            SKILL_VOCABULARY = 21,
            SKILL_AMBIDEX = 22,
            SKILL_HANDIWORK = 23,
            SKILL_TRANCE = 24,
            SKILL_OBSERVATION = 25,
            SKILL_RUN = 26,
            SKILL_RAISE = 27,
            SKILL_HOPE = 40,
            SKILL_SP_MAX_PLUS_1 = 41,
            SKILL_SP_MAX_PLUS_2 = 42,
            SKILL_SP_MAX_PLUS_3 = 43,
            SKILL_SP_MAX_99 = 44
        }

        public enum DR2_SKILL
        {
        }

        public enum DR1_ITEM
        {
            ITEM_MINERAL_WATER,
            ITEM_COLA_COLA,
            ITEM_CIVET_COFFEE,
            ITEM_ROSE_HIP_TEA,
            ITEM_SEA_SALT,
            ITEM_POTATO_CHIPS,
            ITEM_PRISMATIC_HARDTACK,
            ITEM_BLACK_CROISSANT,
            ITEM_SONIC_CUP_A_NOODLE,
            ITEM_ROYAL_CURRY,
            ITEM_RATION,
            ITEM_FLOTATION_DONUT,
            ITEM_OVERFLOWING_LUNCH_BOX,
            ITEM_SUNFLOWER_SEEDS,
            ITEM_BIRDS_WEED,
            ITEM_KITTEN_HAIR_CLIP,
            ITEM_EVERLASTING_BRACELET,
            ITEM_LOVE_STATUS_RING,
            ITEM_ZOLES_DIAMOND,
            ITEM_HOPE_PEAKS_RING,
            ITEM_BLUEBERRY_PERFUME,
            ITEM_SCARAB_BROOCHY,
            ITEM_GOD_OF_WAR_CHARM,
            ITEM_MACS_GLOVES,
            ITEM_GLASSES,
            ITEM_G_SICK,
            ITEM_ROLLER_SLIPPER,
            ITEM_RED_SCARF,
            ITEM_LEAF_COVERING,
            ITEM_TORNEKOS_PANTS,
            ITEM_BUNNY_EARMUFFS,
            ITEM_FRESH_BINDINGS,
            ITEM_JIMMY_DECAY_TSHIRT,
            ITEM_EMPERORS_THONG,
            ITEM_HAND_BRAY,
            ITEM_WATERLOVER,
            ITEM_DEMON_ANGEL_PRINESS_FIGURE,
            ITEM_ASTRAL_BOY_DOLL,
            ITEM_SHEERS,
            ITEM_LAYERING_SHEERS,
            ITEM_QUALITY_CHINCHILLA_COVER,
            ITEM_KIRLIN_CAMERA,
            ITEM_ADORABLE_REACTIONS_COLLECTION,
            ITEM_TUMBLE_WEED,
            ITEM_UNENDING_DANDELION,
            ITEM_ROSE_IN_VITROY,
            ITEM_CHERRY_BLOSSOM,
            ITEM_SCHOOL_CREST = 92,
            ITEM_DESPAIR_BAT = 93,
            ITEM_CRAZY_DIAMOND = 94,
            ITEM_SUPER_ROBO_JUSTICE = 95,
            ITEM_LUNAR_JUMP = 96,
            ITEM_DREAM_ISLAND_ROCKET = 97,
            ITEM_MONOKUMA_HAIRTIE = 98,
            ITEM_EASTER_EGG = 99


        }

        public enum DR2_ITEM
        {
        }


        public static Type GetCharEnum(Game game)
        {
            if (game == Game.Danganronpa2)
                return typeof(DR2_CHAR);
            
            return typeof(DR1_CHAR);
        }

        public static Type GetBGMEnum(Game game)
        {
            if (game == Game.Danganronpa2)
                return typeof(DR2_BGM);

            return typeof(DR1_BGM);
        }
        public static Type GetSkillEnum(Game game)
        {
            if (game == Game.Danganronpa2)
                return typeof(DR2_SKILL);

            return typeof(DR1_SKILL);
        }

        public static Type GetPresentEnum(Game game)
        {
            if (game == Game.Danganronpa2)
                return typeof(DR2_ITEM);

            return typeof(DR1_ITEM);
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
            UI_CHOOSE_OPTION = 18,
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
            FLAG_OBJ_INVESTIGATED = 13,
            FLAG_MAP_INVESTIGATED = 14,
            FLAG_CHR_INVESTIGATED = 15,
            FLAG_CHR_DEAD = 16
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

        // https://github.com/SpiralFramework/Spiral/blob/f43cfdc845deabaecfc1183a16f77370faf8ec60/osl/src/main/kotlin/info/spiralframework/osl/EnumLinFlagCheck.kt#L3
        public enum DR_FLAG_COMPARE
        {
            NOT_EQUAL = 0,
            EQUAL = 1,
            LESS_OR_EQUAL = 2,
            GREATER_OR_EQUAL = 3,
            LESS_THAN = 4,
            GREATER_THAN = 5,
        }

        // https://github.com/SpiralFramework/Spiral/blob/f43cfdc845deabaecfc1183a16f77370faf8ec60/osl/src/main/kotlin/info/spiralframework/osl/EnumLinJoinerFlagCheck.kt    public enum DR_COMPARE
        public enum DR_FLAG_JOINER
        {
            AND = 6,
            OR = 7
        }

        public enum DR_ARITHMETIC
        {
            ADD = 1,
            SUBTRACT = 2
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
