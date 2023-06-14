using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.Audio;
using Melanchall.DryWetMidi.Common;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;
    public float songDelayInSeconds = 5f;
    public List<double> timeStamps = new List<double>();
    public List<string> notesName = new List<string>();

    public Melanchall.DryWetMidi.Interaction.Note[] array;

    public string fileLocation = "C:\\Users\\katie\\piano tile\\Assets\\midi\\piano.mid";
    public MidiFile midiFile;

    void Start()
    {
        Instance = this;
        ReadFromFile();
        StartCoroutine(PlaySong(songDelayInSeconds));
    }

    public void ReadFromFile()
    {
        midiFile = MidiFile.Read(fileLocation);
        var notes = midiFile.GetNotes();
        array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        AddStamps(array, timeStamps);
        //AddNames(array, notesName);
    }

    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    private IEnumerator PlaySong(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }

    private void AddStamps(Melanchall.DryWetMidi.Interaction.Note[] array, List<double> timeStamps)
    {
        foreach (Melanchall.DryWetMidi.Interaction.Note note in array)
        {
            var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, midiFile.GetTempoMap());
            double seconds = ((double)metricTimeSpan.Minutes * 60f + (double)metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            timeStamps.Add(seconds);
        }
    }

    /*private void AddNames(Melanchall.DryWetMidi.Interaction.Note[] array, List<string> notesName)
    {
        foreach (Melanchall.DryWetMidi.Interaction.Note note in array)
        {
            string noteName = GetNoteName(note.NoteNumber);
            notesName.Add(noteName); ;
        }
    }

    private string GetNoteName(int noteNumber)
    {
        int octave = (noteNumber / 12) - 1;
        int noteIndex = noteNumber % 12;

        string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        string noteName = noteNames[noteIndex];

        return noteName + octave.ToString();
    }*/
}


