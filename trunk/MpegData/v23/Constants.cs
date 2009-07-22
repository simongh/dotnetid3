using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    public enum TimeStampFormat
    {
        MpegFrames = 1,
        Milliseconds = 2
    }

    public enum AdjustmentDirection
    {
        Increase = 1,
        Decrease = 0
    }

    public enum TimingCodeType
    {
        Padding = 0,
        EndOfInitialSilence = 0x01,
        IntroStart = 0x02,
        MainPartStart = 0x03,
        OutroStart = 0x04,
        OutroEnd = 0x05,
        VerseStart = 0x06,
        RefrainStart = 0x07,
        InterludeStart = 0x08,
        ThemeStart = 0x09,
        VariationStart = 0x0a,
        KeyChange = 0x0b,
        TimeChange = 0x0c,
        MomentaryUnwantedNoise = 0x0d,
        SustainedNoise = 0x0e,
        SustainedNoiseEnd = 0x0f,
        IntroEnd = 0x10,
        MainPartEnd = 0x11,
        VerseEnd = 0x12,
        RefrainEnd = 0x13,
        ThemeEnd = 0x14,
        UserEvent1 = 0xe0,
        UserEvent2 = 0xe1,
        UserEvent3 = 0xe2,
        UserEvent4 = 0xe3,
        UserEvent5 = 0xe4,
        UserEvent6 = 0xe5,
        UserEvent7 = 0xe6,
        UserEvent8 = 0xe7,
        UserEvent9 = 0xe8,
        UserEvent10 = 0xe9,
        UserEvent11 = 0xea,
        UserEvent12 = 0xeb,
        UserEvent13 = 0xec,
        UserEvent14 = 0xed,
        UserEvent15 = 0xee,
        UserEvent16 = 0xef,
        AudioEnd = 0xfd,
        AudioFileEnds = 0xfe,
        More = 0xff
    }

    public enum UrlLinkType
    {
        Commercial,
        Copyright,
        AudioFile,
        Artist,
        AudioSource,
        InternetRadioHome,
        Payment,
        Publisher
    }

    public enum TextEncoding
    {
        Ascii = 0,
        Unicode = 1
    }

    public enum TextContentType
    {
        Other = 0,
        Lyrics = 1,
        TextTranscription = 2,
        Movement = 3,
        Events = 4,
        Chord = 5,
        Trivia = 6
    }

    public static class Constants
    {
    }
}
