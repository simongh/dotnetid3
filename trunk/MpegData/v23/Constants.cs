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

    public static class Constants
    {
        public static System.Collections.ObjectModel.ReadOnlyCollection<string> GetGenres()
        {
            List<string> result = new List<string>();

            result.Add("Blues");
            result.Add("Classic Rock");
            result.Add("Country");
            result.Add("Dance");
            result.Add("Disco");
            result.Add("Funk");
            result.Add("Grunge");
            result.Add("Hip-Hop");
            result.Add("Jazz");
            result.Add("Metal");
            result.Add("New Age");
            result.Add("Oldies");
            result.Add("Other");
            result.Add("Pop");
            result.Add("R&B");
            result.Add("Rap");
            result.Add("Reggae");
            result.Add("Rock");
            result.Add("Techno");
            result.Add("Industrial");
            result.Add("Alternative");
            result.Add("Ska");
            result.Add("Death Metal");
            result.Add("Pranks");
            result.Add("Soundtrack");
            result.Add("Euro-Techno");
            result.Add("Ambient");
            result.Add("Trip-Hop");
            result.Add("Vocal");
            result.Add("Jazz+Funk");
            result.Add("Fusion");
            result.Add("Trance");
            result.Add("Classical");
            result.Add("Instrumental");
            result.Add("Acid");
            result.Add("House");
            result.Add("Game");
            result.Add("Sound Clip");
            result.Add("Gospel");
            result.Add("Noise");
            result.Add("AlternRock");
            result.Add("Bass");
            result.Add("Soul");
            result.Add("Punk");
            result.Add("Space");
            result.Add("Meditative");
            result.Add("Instrumental Pop");
            result.Add("Instrumental Rock");
            result.Add("Ethnic");
            result.Add("Gothic");
            result.Add("Darkwave");
            result.Add("Techno-Industrial");
            result.Add("Electronic");
            result.Add("Pop-Folk");
            result.Add("Eurodance");
            result.Add("Dream");
            result.Add("Southern Rock");
            result.Add("Comedy");
            result.Add("Cult");
            result.Add("Gangsta");
            result.Add("Top 40");
            result.Add("Christian Rap");
            result.Add("Pop/Funk");
            result.Add("Jungle");
            result.Add("Native American");
            result.Add("Cabaret");
            result.Add("New Wave");
            result.Add("Psychadelic");
            result.Add("Rave");
            result.Add("Showtunes");
            result.Add("Trailer");
            result.Add("Lo-Fi");
            result.Add("Tribal");
            result.Add("Acid Punk");
            result.Add("Acid Jazz");
            result.Add("Polka");
            result.Add("Retro");
            result.Add("Musical");
            result.Add("Rock & Roll");
            result.Add("Hard Rock");
            result.Add("Folk");
            result.Add("Folk-Rock");
            result.Add("National Folk");
            result.Add("Swing");
            result.Add("Fast Fusion");
            result.Add("Bebob");
            result.Add("Latin");
            result.Add("Revival");
            result.Add("Celtic");
            result.Add("Bluegrass");
            result.Add("Avantgarde");
            result.Add("Gothic Rock");
            result.Add("Progressive Rock");
            result.Add("Psychedelic Rock");
            result.Add("Symphonic Rock");
            result.Add("Slow Rock");
            result.Add("Big Band");
            result.Add("Chorus");
            result.Add("Easy Listening");
            result.Add("Acoustic");
            result.Add("Humour");
            result.Add("Speech");
            result.Add("Chanson");
            result.Add("Opera");
            result.Add("Chamber Music");
            result.Add("Sonata");
            result.Add("Symphony");
            result.Add("Booty Bass");
            result.Add("Primus");
            result.Add("Porn Groove");
            result.Add("Satire");
            result.Add("Slow Jam");
            result.Add("Club");
            result.Add("Tango");
            result.Add("Samba");
            result.Add("Folklore");
            result.Add("Ballad");
            result.Add("Power Ballad");
            result.Add("Rhythmic Soul");
            result.Add("Freestyle");
            result.Add("Duet");
            result.Add("Punk Rock");
            result.Add("Drum Solo");
            result.Add("A capella");
            result.Add("Euro-House");
            result.Add("Dance Hall");

            return result.AsReadOnly();
        }
    }
}
