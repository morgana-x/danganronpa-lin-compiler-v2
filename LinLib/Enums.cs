using LinLib.LIN;

#pragma warning disable 1591

namespace LinLib;

public static class Enums
{
    public enum Dr1Bgm
    {
        BgmOpening = 0,
        BgmMenuStart = 1,
        BgmReset = 255
    }

    public enum Dr1Char
    {
        ChrMakoto = 0,
        ChrKiyotaka = 1,
        ChrByakuya = 2,
        ChrMondo = 3,
        ChrLeon = 4,
        ChrHifumi = 5,
        ChrYasuhiro = 6,
        ChrMaizono = 7,
        ChrKirigiri = 8,
        ChrAsahina = 9,
        ChrTouko = 10,
        ChrOgami = 11,
        ChrCeles = 12,
        ChrJunkoMukuro = 13,
        ChrChihiro = 14,
        ChrMonokuma = 15,
        ChrJunkoEnoshima = 16,
        ChrAlterego = 17,
        ChrGenocider = 18,
        ChrHeadmaster = 19,
        ChrMakotoMom = 20,
        ChrMakotoDad = 21,
        ChrMakotoSister = 22,
        ChrKiyotakaMondo = 23,
        ChrDaiya = 24,
        ChrNarrator = 26,
        ChrUsami = 27,
        ChrUnknown = 30,
        ChrSystem = 31
    }

    public enum Dr1Item
    {
        ItemMineralWater,
        ItemColaCola,
        ItemCivetCoffee,
        ItemRoseHipTea,
        ItemSeaSalt,
        ItemPotatoChips,
        ItemPrismaticHardtack,
        ItemBlackCroissant,
        ItemSonicCupANoodle,
        ItemRoyalCurry,
        ItemRation,
        ItemFlotationDonut,
        ItemOverflowingLunchBox,
        ItemSunflowerSeeds,
        ItemBirdsWeed,
        ItemKittenHairClip,
        ItemEverlastingBracelet,
        ItemLoveStatusRing,
        ItemZolesDiamond,
        ItemHopePeaksRing,
        ItemBlueberryPerfume,
        ItemScarabBroochy,
        ItemGodOfWarCharm,
        ItemMacsGloves,
        ItemGlasses,
        ItemGSick,
        ItemRollerSlipper,
        ItemRedScarf,
        ItemLeafCovering,
        ItemTornekosPants,
        ItemBunnyEarmuffs,
        ItemFreshBindings,
        ItemJimmyDecayTshirt,
        ItemEmperorsThong,
        ItemHandBray,
        ItemWaterlover,
        ItemDemonAngelPrinessFigure,
        ItemAstralBoyDoll,
        ItemSheers,
        ItemLayeringSheers,
        ItemQualityChinchillaCover,
        ItemKirlinCamera,
        ItemAdorableReactionsCollection,
        ItemTumbleWeed,
        ItemUnendingDandelion,
        ItemRoseInVitroy,
        ItemCherryBlossom,
        ItemSchoolCrest = 92,
        ItemDespairBat = 93,
        ItemCrazyDiamond = 94,
        ItemSuperRoboJustice = 95,
        ItemLunarJump = 96,
        ItemDreamIslandRocket = 97,
        ItemMonokumaHairtie = 98,
        ItemEasterEgg = 99
    }

    public enum Dr1Skill
    {
        SkillInfluenceAttentive = 0,
        SkillInfluenceEnvious = 1,
        SkillFocusExtraordinary = 2,
        SkillFocusMenacing = 3,
        SkillLostInThought = 4,
        SkillCharisma = 5,
        SkillCoolComposed = 6,
        SkillTranquility = 7,
        SkillDownshift = 8,
        SkillUpshift = 9,
        SkillRobotJock = 10,
        SkillTriggerHappy = 11,
        SkillCrystalPrediction = 12,
        SkillCheatCode = 13,
        SkillAlgorithm = 14,
        SkillKineticDepth = 15,
        SkillSteelPatience = 16,
        SkillNeuralLiberation = 17,
        SkillDelusion = 18,
        SkillBreathing = 19,
        SkillMelodiousVoice = 20,
        SkillVocabulary = 21,
        SkillAmbidex = 22,
        SkillHandiwork = 23,
        SkillTrance = 24,
        SkillObservation = 25,
        SkillRun = 26,
        SkillRaise = 27,
        SkillHope = 40,
        SkillSpMaxPlus1 = 41,
        SkillSpMaxPlus2 = 42,
        SkillSpMaxPlus3 = 43,
        SkillSpMax99 = 44
    }

    public enum Dr2Bgm
    {
        BgmOpening = 0,
        BgmMenuStart = 1,
        BgmBeautifulRuin = 2,
        BgmBeautifulRuinSummerSalt = 3,
        BgmIkoroshia = 4,
        BgmEkoroshia = 5,
        BgmReBeautifulMorning = 6,
        BgmBeautifulDaysPiano = 7,
        BgmTropicalDespair = 8,
        BgmReset = 255
    }

    public enum Dr2Char
    {
        ChrHajime = 0,
        ChrKomaeda = 1,
        ChrByakuya = 2,
        ChrGundam = 3,
        ChrKazuichi = 4,
        ChrTeruteru = 5,
        ChrNekomaru = 6,
        ChrFuyuhiku = 7,
        ChrAkane = 8,
        ChrChiaki = 9,
        ChrSonia = 10,
        ChrHiyiko = 11,
        ChrMahiru = 12,
        ChrMikan = 13,
        ChrIbuki = 14,
        ChrPeko = 15,
        ChrMonokuma = 16,
        ChrMonomi = 17,
        ChrJunko = 18,
        ChrMechamaru = 19,
        ChrMakoto = 20,
        ChrKyoko = 21,
        ChrByakuyaReal = 22,
        ChrTeruteruMom = 23,
        ChrAlterego = 24,
        ChrMinimaru = 25,
        ChrMonokumaAndMonomi = 26,

        ChrUnknown = 30,
        ChrSystem = 31,

        ChrUsami = 39,
        ChrSparklingJustice = 40,

        ChrJunkoBig = 48,

        ChrGirlA = 50,
        ChrGirlB = 51,
        ChrGirlC = 52,
        ChrGirlD = 53,
        ChrGirlE = 54,
        ChrGuyF = 55,

        ChrUnknown2 = 56
    }

    public enum Dr2Item
    {
    }

    public enum Dr2Skill
    {
    }

    public enum DrArithmetic
    {
        Add = 1,
        Subtract = 2
    }

    public enum DrCamDir
    {
        CamFarleft,
        CamLeft,
        CamCenter,
        CamRight,
        CamFarright
    }


    public enum DrChapter
    {
        ChapterPrologue,
        Chapter1,
        Chapter2,
        Chapter3,
        Chapter4,
        Chapter5,
        Chapter6,
        Chapter99 = 99
    }

    public enum DrColour
    {
        ColBlackSpecial,
        ColBlack,
        ColWhite,
        ColRed
    }

    public enum DrFade
    {
        FadeIn,
        FadeOut
    }

    public enum DrFilter
    {
        FilterNone,
        FilterSepia
    }

    public enum DrFlag
    {
        FlagSystem = 0,
        FlagMapUnlock = 1,
        FlagObjInvestigated = 13,
        FlagMapInvestigated = 14,
        FlagChrInvestigated = 15,
        FlagChrDead = 16
    }

    // https://github.com/SpiralFramework/Spiral/blob/f43cfdc845deabaecfc1183a16f77370faf8ec60/osl/src/main/kotlin/info/spiralframework/osl/EnumLinFlagCheck.kt#L3
    public enum DrFlagCompare
    {
        NotEqual = 0,
        Equal = 1,
        LessOrEqual = 2,
        GreaterOrEqual = 3,
        LessThan = 4,
        GreaterThan = 5
    }

    // https://github.com/SpiralFramework/Spiral/blob/f43cfdc845deabaecfc1183a16f77370faf8ec60/osl/src/main/kotlin/info/spiralframework/osl/EnumLinJoinerFlagCheck.kt    public enum DR_COMPARE
    public enum DrFlagJoiner
    {
        And = 6,
        Or = 7
    }

    public enum DrFlagSystem
    {
        HandbookEnabled = 4,
        HandbookMapEnabled = 5,
        HandbookTruthbulletEnabled = 6,
        HandbookSaveEnabled = 7,
        HandbookTruthbulletKnown = 19,
        RoomExitEnabled = 12
    }


    public enum DrSpriteState
    {
        Sprite3D,
        SpriteShow,
        SpriteShowDelay,
        SpriteHide2,
        SpriteHide
    }


    public enum DrTime
    {
        TimeDay = 0,
        TimeNight = 1,
        TimeMorning = 2,
        TimeMidnight = 3,
        TimeUnknown = 4,
        TimeUnknown2 = 255
    }

    public enum DrUi
    {
        UiTextbox = 1,
        UiName = 2,
        UiHud = 3,
        UiMinimap = 5,
        UiBgBlack = 6,
        UiTextboxOnly = 7,
        UiClasstrial = 8,
        UiBustup = 9,
        UiBgMovie = 11,
        UiSave = 12,
        UiRumble = 13,
        UiCamPan = 14,
        UiCamLook = 15,
        UiInvestigate = 16,
        UiChooseOption = 18,
        UiChoosePresent = 19,
        UiBleeptext = 23,
        UiCamZoom = 25,
        UiCamChar = 26,
        UiCamSubarea = 27,
        UiPanictalkaction = 33,
        UiChooseEvidence = 35,
        UiChoosePerson = 37,
        UiMonomonomachine = 41,
        UiVendingmachine = 44,
        UiIslandmode = 50,
        UiMinimal = 51,
        UiLogicdive = 71,
        UiSplitscreen = 72
    }


    public static Type GetCharEnum(Game game)
    {
        return game == Game.Danganronpa2 ? typeof(Dr2Char) : typeof(Dr1Char);
    }

    public static Type GetBgmEnum(Game game)
    {
        return game == Game.Danganronpa2 ? typeof(Dr2Bgm) : typeof(Dr1Bgm);
    }

    public static Type GetSkillEnum(Game game)
    {
        return game == Game.Danganronpa2 ? typeof(Dr2Skill) : typeof(Dr1Skill);
    }

    public static Type GetPresentEnum(Game game)
    {
        return game == Game.Danganronpa2 ? typeof(Dr2Item) : typeof(Dr1Item);
    }
}